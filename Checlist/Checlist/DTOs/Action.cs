namespace Checlist.DTOs
{
    using System;

    public class Action
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public string Date { get; set; }
    }
}
