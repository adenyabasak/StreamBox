using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreamBoxMvc.Models;
using System.Text;

namespace StreamBoxMvc.Controllers
{
    public class AdminActorController : Controller
    {
        private readonly HttpClient _client;

        public AdminActorController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            var response = _client.GetAsync("https://localhost:7064/api/Actors").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var values = JsonConvert.DeserializeObject<List<Actor>>(json);
                return View(values);
            }

            return View(new List<Actor>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            var json = JsonConvert.SerializeObject(actor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync("https://localhost:7064/api/Actors", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(actor);
        }

        public IActionResult Delete(int id)
        {
            _client.DeleteAsync($"https://localhost:7064/api/Actors/{id}").Wait();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var response = _client.GetAsync($"https://localhost:7064/api/Actors/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var value = JsonConvert.DeserializeObject<Actor>(json);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Actor actor)
        {
            var json = JsonConvert.SerializeObject(actor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PutAsync("https://localhost:7064/api/Actors", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(actor);
        }
    }
}