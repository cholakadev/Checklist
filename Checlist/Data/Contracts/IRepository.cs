namespace Checlist.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync();
    }
}
