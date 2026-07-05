using Microsoft.AspNetCore.Mvc;

namespace StreamBoxMvc.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}