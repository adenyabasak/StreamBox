using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StreamBoxMvc.Models;
using System.Text;

namespace StreamBoxMvc.Controllers
{
    public class AdminMovieActorController : Controller
    {
        private readonly HttpClient _client;

        public AdminMovieActorController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            var response = _client.GetAsync("https://localhost:7064/api/MovieActors/MovieActorsWithDetails").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var values = JsonConvert.DeserializeObject<List<MovieActorListDto>>(json);
                return View(values);
            }

            return View(new List<MovieActorListDto>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            GetDropdowns();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieActor movieActor)
        {
            var json = JsonConvert.SerializeObject(movieActor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync("https://localhost:7064/api/MovieActors", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            GetDropdowns();
            return View(movieActor);
        }

        public IActionResult Delete(int id)
        {
            _client.DeleteAsync($"https://localhost:7064/api/MovieActors/{id}").Wait();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var response = _client.GetAsync($"https://localhost:7064/api/MovieActors/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var value = JsonConvert.DeserializeObject<MovieActor>(json);

                GetDropdowns();

                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(MovieActor movieActor)
        {
            var json = JsonConvert.SerializeObject(movieActor);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PutAsync("https://localhost:7064/api/MovieActors", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            GetDropdowns();
            return View(movieActor);
        }

        private void GetDropdowns()
        {
            var movieResponse = _client.GetAsync("https://localhost:7064/api/Movies").Result;

            if (movieResponse.IsSuccessStatusCode)
            {
                var json = movieResponse.Content.ReadAsStringAsync().Result;
                var movies = JsonConvert.DeserializeObject<List<Movie>>(json);

                ViewBag.Movies = movies.Select(x => new SelectListItem
                {
                    Text = x.Title,
                    Value = x.MovieId.ToString()
                }).ToList();
            }

            var actorResponse = _client.GetAsync("https://localhost:7064/api/Actors").Result;

            if (actorResponse.IsSuccessStatusCode)
            {
                var json = actorResponse.Content.ReadAsStringAsync().Result;
                var actors = JsonConvert.DeserializeObject<List<Actor>>(json);

                ViewBag.Actors = actors.Select(x => new SelectListItem
                {
                    Text = x.ActorName,
                    Value = x.ActorId.ToString()
                }).ToList();
            }
        }
    }
}