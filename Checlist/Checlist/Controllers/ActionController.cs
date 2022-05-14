namespace Checlist.Controllers
{
    using Checlist.Models;
    using Checlist.Business.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Checlist.Domain.Enums;

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

            var actions = this._actionService
                .GetAllActions(user.Id);

            var states = Enum.GetValues(typeof(ActionState));
            var selectListStates = new SelectList(states);

            ViewBag.Actions = actions;
            ViewBag.States = selectListStates;

            return View(actions);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string name, DateTime date)
        {
            var user = await this.GetCurrentUser();

            await this._actionService.AddAsync(name, date, user);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm][Required] Guid actionId, ActionState state)
        {
            await this._actionService.UpdateAsync(actionId, state);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm][Required] Guid actionId)
        {
            await this._actionService.DeleteAsync(actionId);

            return RedirectToAction("Index");
        }
    }
}
