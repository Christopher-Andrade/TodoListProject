using Microsoft.AspNetCore.Mvc;

namespace SportsEvents.Web.Controllers
{
    public class ReactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
