namespace Checlist.Domain.DomainModels.Action
{
    using Checlist.Domain.Enums;
    using System;

    public class Action
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ActionState State { get; set; }
        public string Date { get; set; }
    }
}
