namespace ErikLieben.Data.Repository
{
    using System.Linq;

    public class CombinedFetchingStrategy<T> : IFetchingStrategy<T>
    {
        private readonly IFetchingStrategy<T>[] strategies;

        public CombinedFetchingStrategy(params IFetchingStrategy<T>[] stratergies)
        {
            this.strategies = stratergies;
        }

        public IQueryable<T> Apply(IQueryable<T> queryable)
        {
            foreach(var strategy in this.strategies)
            {
                queryable = strategy.Apply(queryable);
            }

            return queryable;
        }
    }
}
