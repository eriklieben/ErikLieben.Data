namespace ErikLieben.Data.Mapping
{
    /// <summary>
    /// Interface used for mapping
    /// </summary>
    /// <typeparam name="TSource">The type of the Source to map from.</typeparam>
    /// <typeparam name="TTarget">The type of the Target to map to.</typeparam>
    public interface IMapper<in TSource, out TTarget> where TTarget : new()
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source type.</param>
        /// <returns>The mapped target type</returns>
        TTarget Map(TSource source);
    }
}