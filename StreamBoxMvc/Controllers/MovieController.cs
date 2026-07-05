using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StreamBoxMvc.Dtos;
using StreamBoxMvc.Models;

namespace StreamBoxMvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient _client;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            var response = _client.GetAsync("https://localhost:7064/api/Movies/MoviesWithCategory").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var values = JsonConvert.DeserializeObject<List<MovieListDto>>(json);

                return View(values);
            }

            return View(new List<MovieListDto>());
        }

        public IActionResult Detail(int id)
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
    }
}