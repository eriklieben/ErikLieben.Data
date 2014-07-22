namespace ErikLieben.Data.Repository
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWorkAsync Create<T>() where T : class;

        IUnitOfWorkAsync CreateAsync<T>() where T : class;
    }
}
