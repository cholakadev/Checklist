using Checlist.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Checlist.Controllers
{
    public abstract class BaseController : Controller
    {
        public Guid UserId
        {
            get
            {
                return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }
    }
}
