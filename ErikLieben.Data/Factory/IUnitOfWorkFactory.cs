// ***********************************************************************
// <copyright file="IUnitOfWorkFactory.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Factory
{
    using Repository;

    /// <summary>
    ///  Interface for classes that are able to create unit of work objects
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates the unit of work.
        /// </summary>
        /// <typeparam name="T">data object</typeparam>
        /// <returns>IUnitOfWorkAsync for the given data object.</returns>
        IUnitOfWorkAsync Create<T>() where T : class;

        /// <summary>
        /// Creates the asynchronous unit of work.
        /// </summary>
        /// <typeparam name="T">data object</typeparam>
        /// <returns>IUnitOfWorkAsync for the given data object.</returns>
        IUnitOfWorkAsync CreateAsync<T>() where T : class;
    }
}
