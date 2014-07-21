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
        /// Gets the predicate.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "Caller doesn't have to cope with nested generics, he is just passing a lambda expression")]
        Expression<Func<T, bool>> Predicate { get; }

        bool IsSatisfiedBy(T item);
    }
}
