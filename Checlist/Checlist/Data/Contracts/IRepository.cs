namespace Checlist.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void AddAsync(TEntity entity);
    }
}
