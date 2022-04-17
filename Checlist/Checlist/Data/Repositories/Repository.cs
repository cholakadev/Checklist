namespace Checlist.Data.Repositories
{
    using Checlist.Data.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext DbContext { get; }

        protected DbSet<TEntity> Entities { get; }

        public Repository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.Entities = dbContext.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            this.Entities.Add(entity);

            return this.DbContext.SaveChangesAsync();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
            => this.Entities.ToListAsync();
    }
}
