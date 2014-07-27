// ***********************************************************************
// <copyright file="Specification.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Class Specification.
    /// </summary>
    /// <typeparam name="T">The data object</typeparam>
    public abstract class Specification<T> : ISpecification<T>
    {
        /// <summary>
        /// Gets the predicate containing the specification.
        /// </summary>
        /// <value>The predicate.</value>
        public abstract Expression<Func<T, bool>> Predicate
        {
            get;
        }

        /// <summary>
        /// Determines whether the item is satisfied by the specification.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if item is satisfied by the specification; otherwise, <c>false</c>.</returns>
        public bool IsSatisfiedBy(T item)
        {
            return this.Predicate.Compile().Invoke(item);
        }
    }
}
