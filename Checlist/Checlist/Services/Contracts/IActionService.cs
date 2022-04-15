namespace Checlist.Services.Contracts
{
    using Checlist.Models;
    using System;

    public interface IActionService
    {
        void AddAsync(string name, DateTime date, User user);
    }
}
