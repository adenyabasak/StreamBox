using Microsoft.AspNetCore.Mvc;
using StreamBoxMvc.Models;

namespace StreamBoxMvc.Controllers
{
    public class AccountController : Controller
    {
        private static List<AppUser> users = new List<AppUser>
        {
            new AppUser
            {
                Username = "admin",
                Password = "1234",
                Role = "Admin"
            },

            new AppUser
            {
                Username = "user",
                Password = "1234",
                Role = "User"
            }
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = users.FirstOrDefault(x =>
                x.Username == model.Username &&
                x.Password == model.Password);

            if (user == null)
            {
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
                return View(model);
            }

            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);

            if (user.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "Movie");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var exists = users.Any(x => x.Username == model.Username);

            if (exists)
            {
                ViewBag.Error = "Bu kullanıcı adı zaten kayıtlı.";
                return View(model);
            }

            users.Add(new AppUser
            {
                Username = model.Username,
                Password = model.Password,
                Role = "User"
            });

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Movie");
        }
    }
}