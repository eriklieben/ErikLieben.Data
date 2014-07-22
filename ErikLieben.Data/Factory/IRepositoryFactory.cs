namespace ErikLieben.Data.Factory
{
    using Repository;

    public interface IRepositoryFactory
    {
        IRepository<T> Create<T>(IUnitOfWork uow) where T : class;

        IRepository<T> Create<T>(IUnitOfWorkAsync uow) where T : class;
    }
}
