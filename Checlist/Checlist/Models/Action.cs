namespace Checlist.Models
{
    using Checlist.DTOs;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Action
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ActionState State { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
