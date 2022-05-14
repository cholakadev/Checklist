namespace Checlist.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Checlist.Data.Contracts;
    using Checlist.Models;
    using Checlist.Business.Contracts;
    using Action = Domain.DomainModels.Action.Action;
    using Checlist.Domain.Enums;
    using Checlist.Domain.DomainModels.Action;

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
                State = ActionState.Todo,
                User = user,
                UserId = user.Id
            };

            await this._repository.AddAsync(action);
        }

        public async Task UpdateAsync(Guid actionId, ActionState state)
        {
            var action = this._repository.GetActionById(actionId);
            action.State = state;

            await this._repository.UpdateAsync(action);
        }

        public List<Action> GetAllActions(Guid userId)
        {
            var userActions = this._repository
                .GetAllUserActionsAsync(userId);

            var actions = new List<Action>();

            userActions.ForEach(x => actions.Add(x.ToModel()));

            actions = actions
                .OrderBy(a => (int)a.State)
                .ThenBy(a => a.Date)
                .ThenBy(a => a.Name)
                .ToList();

            return actions;
        }

        public Task DeleteAsync(Guid actionId)
            => this._repository.DeleteAsync(actionId);
    }
}
