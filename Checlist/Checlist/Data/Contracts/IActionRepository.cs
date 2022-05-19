namespace Checlist.Data.Contracts
{
    using Action = Models.Action;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IActionRepository : IRepository<Action>
    {
        List<Action> GetAllUserActionsAsync(Guid userId);
        Task<Action> GetActionById(Guid actionId);
        Task UpdateAsync(Action action);
        Task DeleteAsync(Guid actionId);
    }
}
