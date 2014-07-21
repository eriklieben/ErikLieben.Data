namespace ErikLieben.Data.Repository
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
