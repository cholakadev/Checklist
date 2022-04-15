namespace Checlist.Data.Repositories
{
    using Checlist.Data.Contracts;
    using Checlist.Models;

    public class ActionRepository : Repository<Action>, IActionRepository
    {

        public ActionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
