namespace ErikLieben.Data.Projection
{
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
    }
}