// ***********************************************************************
// <copyright file="IFetchingStrategy.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System.Linq;

    /// <summary>
    /// Interface to define a fetching strategy
    /// </summary>
    /// <typeparam name="T">The data object</typeparam>
    public interface IFetchingStrategy<T>
    {
        /// <summary>
        /// Applies the fetching strategy to the specified queryable.
        /// </summary>
        /// <param name="queryable">The queryable.</param>
        /// <returns>The IQueryable&lt;T&gt; with the specified fetching strategy applied.</returns>
        IQueryable<T> Apply(IQueryable<T> queryable);
    }
}
