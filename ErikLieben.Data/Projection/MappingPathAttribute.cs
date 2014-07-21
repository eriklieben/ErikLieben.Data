namespace ErikLieben.Data.Projection
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MappingPathAttribute : Attribute
    {
        public MappingPathAttribute()
        {
            this.Path = string.Empty;
        }

        public string Path
        {
            get;
            set;
        }
    }
}
