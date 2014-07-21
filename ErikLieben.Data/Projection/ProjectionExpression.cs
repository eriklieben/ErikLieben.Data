namespace ErikLieben.Data.Projection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public class ProjectionExpression<TSource>
    {
        private static IExpressionCache ExpressionCache;

        private readonly IQueryable<TSource> source;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionExpression{TSource}"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public ProjectionExpression(IQueryable<TSource> source)
            : this(source, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionExpression{TSource}" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="cache">The cache.</param>
        public ProjectionExpression(IQueryable<TSource> source, IExpressionCache cache)
        {
            this.source = source;
            if (ExpressionCache == null && cache == null)
            {
                ExpressionCache = new ExpressionCacheDictionary();
            }
            else if (ExpressionCache == null)
            {
                ExpressionCache = cache;
            }
        }

        /// <summary>
        /// Map the source to the destination type
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination to map to</typeparam>
        /// <returns>The object mapped as destination object</returns>
        public IQueryable<TDestination> To<TDestination>()
        {
            var queryExpression = GetCachedExpression<TDestination>() ?? BuildExpression<TDestination>();

            return this.source.Select(queryExpression);
        }

        private static Expression<Func<TSource, TDestination>> GetCachedExpression<TDestination>()
        {
            var key = GetCacheKey<TDestination>();

            Expression expression;
            return ExpressionCache.TryGetValue(key, out expression) ? expression as Expression<Func<TSource, TDestination>> : null;
        }

        private static Expression<Func<TSource, TDestination>> BuildExpression<TDestination>()
        {
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties().Where(dest => dest.CanWrite);
            var parameterExpression = Expression.Parameter(typeof(TSource), "src");

            var bindings = destinationProperties
                                .Select(destinationProperty => BuildBinding(parameterExpression, destinationProperty, sourceProperties))
                                .Where(binding => binding != null);

            var expression = Expression.Lambda<Func<TSource, TDestination>>(Expression.MemberInit(Expression.New(typeof(TDestination)), bindings), parameterExpression);

            var key = GetCacheKey<TDestination>();

            ExpressionCache.TryAdd(key, expression);

            return expression;
        }

        private static MemberAssignment BuildBinding(Expression parameterExpression, MemberInfo destinationProperty, IEnumerable<PropertyInfo> sourceProperties)
        {
            object obj = destinationProperty.GetCustomAttributes(true).FirstOrDefault(p => p.GetType().Name == "MappingPathAttribute");
            string[] sections;
            if (obj != null)
            {
                string path = ((MappingPathAttribute)obj).Path;
                sections = path.Split('.');
            }
            else
            {
                sections = SplitCamelCase(destinationProperty.Name);
            }

            return ResolveProperty(
                parameterExpression,
                destinationProperty,
                sections[0],
                1,
                sourceProperties,
                sections);
        }

        /// <summary>
        ///   <para>
        /// Attempt to find the first property that matches with a depth-first recursive search.
        /// This will yield a path along the shortest property names.
        ///   </para>
        ///   <para>
        /// If sections = {"Bar", "Two"} it will match Foo.Bar, and then the child
        /// Bar.Two.  Failing that, it will  continue to Foo.BarTwo
        ///   </para>
        /// </summary>
        /// <param name="parameterExpression">The parameter expression.</param>
        /// <param name="destinationProperty">The destination property.</param>
        /// <param name="currentName">The current property name being looked for</param>
        /// <param name="currentIndex">The current index in the sections collection</param>
        /// <param name="properties">Collection of properties on the source object</param>
        /// <param name="sections">collection of name sections, split by camel case</param>
        /// <returns></returns>
        private static MemberAssignment ResolveProperty(
            Expression parameterExpression,
            MemberInfo destinationProperty,
            string currentName,
            int currentIndex,
            IEnumerable<PropertyInfo> properties,
            string[] sections)
        {
            // Check if any of the current properties match in name
            var property = properties.FirstOrDefault(src => src.Name == currentName);

            // If we're at the end of the sections, attempt to bind, or nothing found
            if (currentIndex == sections.Length)
            {
                return (property != null) ?
                    Expression.Bind(destinationProperty, Expression.Property(parameterExpression, property)) :
                    null;
            }

            // The property exists and there are still sections left - look into the child
            if (property != null)
            {
                // We found a property with currentName, so move to the next section
                // Examine the remaining sections on child properties
                var result = ResolveProperty(
                    Expression.Property(parameterExpression, property),
                    destinationProperty,
                    sections[currentIndex],
                    currentIndex + 1,             // proceed to the next section index
                    property.PropertyType.GetProperties(),
                    sections);

                // If we found a property on the child, return it.  Otherwise continue searching
                if (result != null)
                {
                    return result;
                }
            }

            // currentName doesn't exist, so add the next section and keep searching
            return ResolveProperty(
                    parameterExpression,
                    destinationProperty,
                    currentName + sections[currentIndex],
                    currentIndex + 1,             // proceed to the next section index
                    properties,
                    sections);
        }


        private static string GetCacheKey<TDestination>()
        {
            return string.Concat(typeof(TSource).FullName, typeof(TDestination).FullName);
        }

        private static string[] SplitCamelCase(string input)
        {
            return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim().Split(' ');
        }
    }
}
