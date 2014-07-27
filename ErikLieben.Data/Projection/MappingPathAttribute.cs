// ***********************************************************************
// <copyright file="MappingPathAttribute.cs" company="Erik Lieben">
//     Copyright (c) Erik Lieben. All rights reserved.
// </copyright>
// ***********************************************************************
namespace ErikLieben.Data.Projection
{
    using System;

    /// <summary>
    /// Mapping path attribute used to define how to map a certain property. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MappingPathAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingPathAttribute"/> class.
        /// </summary>
        public MappingPathAttribute()
        {
            this.Path = string.Empty;
        }

        /// <summary>
        /// Gets or sets the mapping path.
        /// </summary>
        /// <value>The mapping path to use.</value>
        public string Path
        {
            get;
            set;
        }
    }
}
