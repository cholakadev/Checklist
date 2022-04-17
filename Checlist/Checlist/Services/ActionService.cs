namespace Checlist.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Checlist.Data.Contracts;
    using Checlist.Models;
    using Checlist.Services.Contracts;

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

        public List<Models.Action> GetAllActions(Guid userId)
            => this._repository.GetAllUserActionsAsync(userId);
    }
}
