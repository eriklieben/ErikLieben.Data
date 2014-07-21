namespace ErikLieben.Data.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class SortedFetchingStrategy<T, TKey> : IFetchingStrategy<T>
    {
        private readonly Expression<Func<T, TKey>> expression;
        private readonly SortDirection direction;

        public SortedFetchingStrategy(Expression<Func<T, TKey>> expression, SortDirection direction)
        {
            this.expression = expression;
            this.direction = direction;
        }

        public IQueryable<T> Apply(IQueryable<T> queryable)
        {
            return (this.direction == SortDirection.Ascending) ? 
                queryable.OrderBy(this.expression) : 
                queryable.OrderByDescending(this.expression);
        }
    }

    public enum SortDirection
    {
        Ascending = 0,
        Descending = 1
    }
}
