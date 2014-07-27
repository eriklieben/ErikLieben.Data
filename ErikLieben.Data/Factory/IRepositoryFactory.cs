// ***********************************************************************
// <copyright file="IRepositoryFactory.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Factory
{
    using Repository;

    /// <summary>
    ///  Interface for classes that are able to create repository objects using
    ///  the given unit of work.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Creates the repository with the given unit of work
        /// </summary>
        /// <typeparam name="T">data object</typeparam>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns>IRepository&lt;T&gt; that uses the unit of work.</returns>
        IRepository<T> Create<T>(IUnitOfWork unitOfWork) where T : class;

        /// <summary>
        /// Creates the repository with given async unit of work.
        /// </summary>
        /// <typeparam name="T">data object</typeparam>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns>IRepository&lt;T&gt; that uses the unit of work.</returns>
        IRepository<T> Create<T>(IUnitOfWorkAsync unitOfWork) where T : class;
    }
}
