namespace Checlist.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ActionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
