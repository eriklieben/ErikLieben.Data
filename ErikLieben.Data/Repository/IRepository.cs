// ***********************************************************************
// <copyright file="IRepository.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T">The data object</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Naming", 
        "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Repository is a better known word, adding collection at the end would confuse")]
    public interface IRepository<T> : IEnumerable<T>
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

        /// <summary>
        /// Finds the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="fetchingStrategy">The fetching strategy.</param>
        /// <returns>The IEnumerable&lt;T&gt; collection containing the found results for the specification with the fetching strategy.</returns>
        IEnumerable<T> Find(ISpecification<T> specification, IFetchingStrategy<T> fetchingStrategy);

        /// <summary>
        /// Finds the first or default.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="fetchingStrategy">The fetching strategy.</param>
        /// <returns>The first object found of T for the specification with the fetching strategy.</returns>
        T FindFirstOrDefault(ISpecification<T> specification, IFetchingStrategy<T> fetchingStrategy);
    }
}
