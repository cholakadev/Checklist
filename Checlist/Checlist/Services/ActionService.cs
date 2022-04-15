namespace Checlist.Services
{
    using System;
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

        public void AddAsync(string name, DateTime date, User user)
        {
            var action = new Models.Action()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Date = date,
                Done = false,
                User = user
            };

            this._repository.AddAsync(action);
        }
    }
}
