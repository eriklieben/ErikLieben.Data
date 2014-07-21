namespace ErikLieben.Data.Repository
{
    using System.Collections.Generic;

    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Add(T item);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        void Delete(T item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item to update.</param>
        void Update(T item);

        IEnumerable<T> Find(ISpecification<T> specification, IFetchingStrategy<T> fetchingStrategy);
    }
}
