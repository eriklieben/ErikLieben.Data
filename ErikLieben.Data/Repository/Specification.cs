namespace ErikLieben.Data.Repository
{
    using System;
    using System.Linq.Expressions;

    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> Predicate
        {
            get;
        }

        public bool IsSatisfiedBy(T item)
        {
            return this.Predicate.Compile().Invoke(item);
        }
    }
}
