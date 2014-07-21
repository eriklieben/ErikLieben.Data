namespace ErikLieben.Data.Repository
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

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

        Task<int> SubmitChangesAsync();

        Task<int> SubmitChangesAsync(CancellationToken token);

        IEnumerable<T> FindAll();

        IEnumerable<T> Find(ISpecification<T> specification);

        [SuppressMessage(
            "Microsoft.Design",
            "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "Async method")]
        Task<IEnumerable<T>> FindAsync(ISpecification<T> specification, CancellationToken token);
    }
}
