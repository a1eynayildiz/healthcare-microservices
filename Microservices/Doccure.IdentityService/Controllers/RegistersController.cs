using Microsoft.AspNetCore.Mvc;

namespace Doccure.IdentityService.Controllers
{
    public class RegistersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
