// ***********************************************************************
// <copyright file="ProjectionExtensions.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Projection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides projection mapping from a queryable and enumerable sources.
    /// </summary>
    public static class ProjectionExtensions
    {
        /// <summary>
        /// Create a project expression on the source queryable.
        /// </summary>
        /// <typeparam name="TSource">The type of data objects to map.</typeparam>
        /// <param name="source">The repository containing the data objects.</param>
        /// <returns>the ProjectionExpression&lt;TSource&gt;.</returns>
        public static ProjectionExpression<TSource> Project<TSource>(this IQueryable<TSource> source)
        {
            return new ProjectionExpression<TSource>(source);
        }

        /// <summary>
        /// Create a project expression on the source enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of data objects to map.</typeparam>
        /// <param name="source">The repository containing the data objects.</param>
        /// <returns>the ProjectionExpression&lt;TSource&gt;.</returns>
        /// <exception cref="System.ArgumentException">source is not of type IQueryable&lt;TSource&gt;</exception>
        public static ProjectionExpression<TSource> Project<TSource>(this IEnumerable<TSource> source)
        {
            var result = source as IQueryable<TSource>;
            if (result == null)
            {
                throw new ArgumentException("source is not of type IQueryable<TSource>");
            }

            return new ProjectionExpression<TSource>(result);
        }
    }
}