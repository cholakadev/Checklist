﻿namespace Checlist.Data.Repositories
{
    using Checlist.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public ApplicationDbContext DbContext { get; }

        protected DbSet<TEntity> Entities { get; }

        public Repository(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.Entities = dbContext.Set<TEntity>();
        }

        public void AddAsync(TEntity entity)
        {
            this.Entities.Add(entity);

            this.DbContext.SaveChangesAsync();
        }
    }
}
