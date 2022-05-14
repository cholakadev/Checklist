namespace Checlist.Business.Contracts
{
    using System;
    using Checlist.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Action = Domain.DomainModels.Action.Action;
    using Checlist.Domain.Enums;

    public interface IActionService
    {
        Task AddAsync(string name, DateTime date, User user);
        Task UpdateAsync(Guid actionId, ActionState state);
        Task DeleteAsync(Guid actionId);
        List<Action> GetAllActions(Guid userId);
    }
}
