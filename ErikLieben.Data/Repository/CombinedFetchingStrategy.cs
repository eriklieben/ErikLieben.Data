// ***********************************************************************
// <copyright file="CombinedFetchingStrategy.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System.Linq;

    /// <summary>
    /// Fetching strategy that combines multiple fetching strategies
    /// </summary>
    /// <typeparam name="T">Data object</typeparam>
    public class CombinedFetchingStrategy<T> : IFetchingStrategy<T>
    {
        /// <summary>
        /// The strategies
        /// </summary>
        private readonly IFetchingStrategy<T>[] strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedFetchingStrategy{T}"/> class.
        /// </summary>
        /// <param name="strategies">The strategies.</param>
        public CombinedFetchingStrategy(params IFetchingStrategy<T>[] strategies)
        {
            this.strategies = strategies;
        }

        /// <summary>
        /// Applies the specified fetching strategy to the queryable.
        /// </summary>
        /// <param name="queryable">The queryable to apply the fetching strategy to.</param>
        /// <returns>The IQueryable&lt;T&gt; with the applied fetching strategy.</returns>
        public IQueryable<T> Apply(IQueryable<T> queryable)
        {
            return this.strategies.Aggregate(queryable, (current, strategy) => strategy.Apply(current));
        }
    }
}
