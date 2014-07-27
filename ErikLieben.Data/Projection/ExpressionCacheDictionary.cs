// ***********************************************************************
// <copyright file="ExpressionCacheDictionary.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Projection
{
    using System.Collections.Concurrent;
    using System.Linq.Expressions;

    /// <summary>
    /// Concurrent dictionary to store expressions.
    /// </summary>
    public class ExpressionCacheDictionary
        : ConcurrentDictionary<string, Expression>, IExpressionCache
    {
    }
}
