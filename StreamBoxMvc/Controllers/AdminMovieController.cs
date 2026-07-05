using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreamBoxMvc.Models;
using System.Text;

namespace StreamBoxMvc.Controllers
{
    public class AdminMovieController : Controller
    {
        private readonly HttpClient _client;

        public AdminMovieController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            var response = _client.GetAsync("https://localhost:7064/api/Movies").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var values = JsonConvert.DeserializeObject<List<Movie>>(json);

                return View(values);
            }

            return View(new List<Movie>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var json = JsonConvert.SerializeObject(movie);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync("https://localhost:7064/api/Movies", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var response = _client.DeleteAsync($"https://localhost:7064/api/Movies/{id}").Result;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var response = _client.GetAsync($"https://localhost:7064/api/Movies/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var value = JsonConvert.DeserializeObject<Movie>(json);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Movie movie)
        {
            var json = JsonConvert.SerializeObject(movie);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PutAsync("https://localhost:7064/api/Movies", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(movie);
        }
    }
}