namespace Checlist.Controllers
{
    using Checlist.Models;
    using Checlist.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ActionController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IActionService _actionService;

        public ActionController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IActionService actionService
        )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._actionService = actionService;
        }

        private async Task<User> GetCurrentUser()
            => await _userManager.GetUserAsync(HttpContext.User);

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await this.GetCurrentUser();

            var actions = this._actionService.GetAllActions(user.Id);

            ViewBag.Actions = actions;

            return View(actions);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string name, DateTime date)
        {
            var user = await this.GetCurrentUser();

            await this._actionService.AddAsync(name, date, user);

            return RedirectToAction("Index");
        }
    }
}
