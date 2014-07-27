// ***********************************************************************
// <copyright file="IExpressionCache.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Projection
{
    using System.Linq.Expressions;

    /// <summary>
    /// Interface IExpressionCache
    /// </summary>
    public interface IExpressionCache
    {
        /// <summary>
        /// Gets the total count of objects cached.
        /// </summary>
        /// <value>The count.</value>
        int Count
        {
            get;
        }

        /// <summary>
        /// Tries the add the expression with the given key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if it was able to add, <c>false</c> otherwise.</returns>
        bool TryAdd(string key, Expression value);

        /// <summary>
        /// Tries the get the expression with the given key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if it was able to get the value, <c>false</c> otherwise.</returns>
        bool TryGetValue(string key, out Expression value);

        /// <summary>
        /// Determines whether the cache contains key the given key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key exists; otherwise, <c>false</c>.</returns>
        bool ContainsKey(string key);
    }
}