namespace ErikLieben.Data.Repository
{
    using System.Linq;

    public interface IFetchingStrategy<T>
    {
        IQueryable<T> Apply(IQueryable<T> queryable);
    }
}
