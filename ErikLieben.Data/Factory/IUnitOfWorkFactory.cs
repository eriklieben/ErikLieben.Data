namespace ErikLieben.Data.Factory
{
    using Repository;

    public interface IUnitOfWorkFactory
    {
        IUnitOfWorkAsync Create<T>() where T : class;

        IUnitOfWorkAsync CreateAsync<T>() where T : class;
    }
}
