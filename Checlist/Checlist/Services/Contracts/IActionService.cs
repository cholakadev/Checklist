namespace Checlist.Services.Contracts
{
    using System;
    using Checlist.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Action = DTOs.Action;
    using Checlist.DTOs;

    public interface IActionService
    {
        Task AddAsync(string name, DateTime date, User user);
        Task UpdateAsync(Guid actionId, ActionState state);
        List<Action> GetAllActions(Guid userId);
    }
}
