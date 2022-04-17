namespace Checlist.Data.Repositories
{
    using Checlist.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Action = Models.Action;

    public class ActionRepository : Repository<Action>, IActionRepository
    {

        public ActionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public List<Action> GetAllUserActionsAsync(Guid userId)
        {
            var actions = base.GetAllAsync().Result;
            actions.Where(x => x.UserId == userId);
            return actions;
        }
    }
}
