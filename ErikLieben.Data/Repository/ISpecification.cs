// ***********************************************************************
// <copyright file="ISpecification.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    /// Specification pattern
    /// </summary>
    /// <typeparam name="T">Type to specify a specification for</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the predicate for this specification.
        /// </summary>
        /// <value>The predicate.</value>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "Caller doesn't have to cope with nested generics, he is just passing a lambda expression")]
        Expression<Func<T, bool>> Predicate { get; }

        /// <summary>
        /// Determines whether the item is satisfied by the defined specification.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if the item is satisfied by the specification; otherwise, <c>false</c>.</returns>
        bool IsSatisfiedBy(T item);
    }
}
