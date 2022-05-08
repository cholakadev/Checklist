namespace Checlist.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Checlist.Data.Contracts;
    using Checlist.DTOs;
    using Checlist.Models;
    using Checlist.Services.Contracts;
    using Action = DTOs.Action;

    public class ActionService : IActionService
    {
        private readonly IActionRepository _repository;

        public ActionService(IActionRepository repository)
        {
            this._repository = repository;
        }

        public async Task AddAsync(string name, DateTime date, User user)
        {
            var action = new Models.Action()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Date = date,
                Done = false,
                User = user,
                UserId = user.Id
            };

            await this._repository.AddAsync(action);
        }

        public List<Action> GetAllActions(Guid userId)
        {
            var userActions = this._repository
                .GetAllUserActionsAsync(userId);

            var actions = new List<Action>();

            foreach (var action in userActions)
            {
                var actionModel = action.ToModel();
                actions.Add(actionModel);
            }

            actions = actions
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Name)
                .ToList();

            return actions;
        }
    }
}
