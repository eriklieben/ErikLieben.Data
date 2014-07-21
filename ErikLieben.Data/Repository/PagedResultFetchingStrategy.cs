namespace ErikLieben.Data.Repository
{
    using System.Linq;

    public class PagedResultFetchingStrategy<T> : IFetchingStrategy<T>
    {
        private readonly int take;
        private readonly int skip;

        public PagedResultFetchingStrategy(int page, int pageSize)
        {
            if (page < 1)
            {
                this.skip = 0;
            }
            else
            {
                this.skip = page * pageSize;
            }

            this.take = pageSize;
        }

        public IQueryable<T> Apply(IQueryable<T> queryable)
        {
            return queryable
                .Skip(this.skip)
                .Take(this.take);
        }
    }
}
