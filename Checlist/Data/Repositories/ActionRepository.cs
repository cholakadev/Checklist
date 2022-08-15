namespace Checlist.Data.Repositories
{
    using Checlist.Data.Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Action = Models.Action;

    public class ActionRepository : Repository<Action>, IActionRepository
    {

        public ActionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task DeleteAsync(Guid actionId)
        {
            var action = this.Entities.Find(actionId);
            this.Entities.Remove(action);

            return this.DbContext.SaveChangesAsync();
        }

        public Task<Action> GetActionById(Guid actionId)
            => this.Entities.FirstOrDefaultAsync(x => x.Id == actionId);

        public List<Action> GetAllUserActionsAsync(Guid userId)
        {
            var actions = base.GetAllAsync().Result;
            actions = actions
                .Where(x => x.UserId == userId)
                .ToList();

            return actions;
        }

        public Task UpdateAsync(Action action)
        {
            this.Entities.Update(action);

            return this.DbContext.SaveChangesAsync();
        }
    }
}
