namespace Checlist.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser<Guid>
    {
        public List<Action> Actions { get; set; }
    }
}
