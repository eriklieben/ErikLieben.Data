// ***********************************************************************
// <copyright file="IUnitOfWorkAsync.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface IUnitOfWorkAsync
    /// </summary>
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        /// <summary>
        /// Commits the work asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of items committed.</returns>
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
