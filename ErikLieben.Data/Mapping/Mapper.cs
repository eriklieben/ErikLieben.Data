namespace ErikLieben.Data.Mapping
{
    using System;

    /// <summary>
    /// Static class to perform mappings
    /// </summary>
    public static class Mapper
    {
        /// <summary>
        /// Maps this instance.
        /// </summary>
        /// <typeparam name="TMapper">Type of mapper to use</typeparam>
        /// <typeparam name="TSource">The type of the Source.</typeparam>
        /// <typeparam name="TTarget">The type of the Target.</typeparam>
        /// <param name="source">The source instance to map</param>
        /// <returns>
        /// The mapped instance
        /// </returns>
        public static TTarget Map<TMapper, TSource, TTarget>(TSource source) 
            where TMapper : IMapper<TSource, TTarget> where TTarget : new()
        {
            return Activator.CreateInstance<TMapper>().Map(source);
        }
    }
}
