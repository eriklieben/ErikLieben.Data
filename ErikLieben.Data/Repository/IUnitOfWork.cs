﻿// ***********************************************************************
// <copyright file="IUnitOfWork.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Repository
{
    using System;

    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits the work.
        /// </summary>
        /// <returns>The number of items committed.</returns>
        int Commit();
    }
}
