namespace Checlist.Services.Contracts
{
    using System;
    using Checlist.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Action = DTOs.Action;

    public interface IActionService
    {
        Task AddAsync(string name, DateTime date, User user);

        List<Action> GetAllActions(Guid userId);
    }
}
