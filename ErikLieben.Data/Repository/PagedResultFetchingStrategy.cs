// ***********************************************************************
// <copyright file="PagedResultFetchingStrategy.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System.Linq;

    /// <summary>
    /// Fetching strategy for paged results.
    /// </summary>
    /// <typeparam name="T">The data object</typeparam>
    public class PagedResultFetchingStrategy<T> : IFetchingStrategy<T>
    {
        /// <summary>
        /// The items to take
        /// </summary>
        private readonly int take;
        
        /// <summary>
        /// The items to skip
        /// </summary>
        private readonly int skip;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedResultFetchingStrategy{T}"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public PagedResultFetchingStrategy(int page, int pageSize)
        {
            if (page < 1)
            {
                this.skip = 0;
            }
            else
            {
                this.skip = page * pageSize;
            }

            this.take = pageSize;
        }

        /// <summary>
        /// Applies the specified strategy to the queryable.
        /// </summary>
        /// <param name="queryable">The queryable.</param>
        /// <returns>The IQueryable&lt;T&gt; with the strategy applied.</returns>
        public IQueryable<T> Apply(IQueryable<T> queryable)
        {
            return queryable
                .Skip(this.skip)
                .Take(this.take);
        }
    }
}
