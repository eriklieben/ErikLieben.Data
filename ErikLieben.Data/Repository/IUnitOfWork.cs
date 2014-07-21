namespace ErikLieben.Data.Repository
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
