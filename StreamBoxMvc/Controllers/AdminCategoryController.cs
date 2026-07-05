using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreamBoxMvc.Models;
using System.Text;

namespace StreamBoxMvc.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly HttpClient _client;

        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            var response = _client.GetAsync("https://localhost:7064/api/Categories").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var values = JsonConvert.DeserializeObject<List<Category>>(json);
                return View(values);
            }

            return View(new List<Category>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync("https://localhost:7064/api/Categories", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            _client.DeleteAsync($"https://localhost:7064/api/Categories/{id}").Wait();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var response = _client.GetAsync($"https://localhost:7064/api/Categories/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var value = JsonConvert.DeserializeObject<Category>(json);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            var json = JsonConvert.SerializeObject(category);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PutAsync("https://localhost:7064/api/Categories", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(category);
        }
    }
}