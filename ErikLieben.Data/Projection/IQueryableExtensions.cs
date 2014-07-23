namespace ErikLieben.Data.Projection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides projection mapping from an IQueryable source to a target type.
    /// </summary>
    public static class IQueryableExtensions
    {
        public static ProjectionExpression<TSource> Project<TSource>(this IQueryable<TSource> source)
        {
            return new ProjectionExpression<TSource>(source);
        }

        public static ProjectionExpression<TSource> Project<TSource>(this IEnumerable<TSource> source)
        {
            var result = source as IQueryable<TSource>;
            if (result == null)
            {
                throw new ArgumentException("source is not IQueryable<TSource>");
            }

            return new ProjectionExpression<TSource>(result);
        }
    }
}