namespace Checlist.Services.Contracts
{
    using Checlist.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Action = Models.Action;

    public interface IActionService
    {
        Task AddAsync(string name, DateTime date, User user);

        List<Action> GetAllActions(Guid userId);
    }
}
