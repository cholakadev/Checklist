namespace Checlist.Data.Repositories
{
    using Checlist.Models;

    public class ActionRepository : Repository<Action>
    {

        public ActionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
