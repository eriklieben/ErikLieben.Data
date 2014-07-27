// ***********************************************************************
// <copyright file="SortedFetchingStrategy.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Fetching strategy for sorted results.
    /// </summary>
    /// <typeparam name="T">The data object</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    public class SortedFetchingStrategy<T, TKey> : IFetchingStrategy<T>
    {
        /// <summary>
        /// The sorting expression
        /// </summary>
        private readonly Expression<Func<T, TKey>> expression;
        
        /// <summary>
        /// The direction to sort in
        /// </summary>
        private readonly SortDirection direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortedFetchingStrategy{T, TKey}"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="direction">The direction.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design", 
            "CA1006:DoNotNestGenericTypesInMemberSignatures", 
            Justification = "It's the linq sorting expression")]
        public SortedFetchingStrategy(Expression<Func<T, TKey>> expression, SortDirection direction)
        {
            this.expression = expression;
            this.direction = direction;
        }

        /// <summary>
        /// Applies the specified queryable.
        /// </summary>
        /// <param name="queryable">The queryable.</param>
        /// <returns>The IQueryable&lt;T&gt; with the strategy applied.</returns>
        public IQueryable<T> Apply(IQueryable<T> queryable)
        {
            return (this.direction == SortDirection.Ascending) ? 
                queryable.OrderBy(this.expression) : 
                queryable.OrderByDescending(this.expression);
        }
    }
}
