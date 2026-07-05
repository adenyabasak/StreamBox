using Microsoft.AspNetCore.Mvc;
using StreamBoxApi.Models;
using StreamBoxApi.Repositories;

namespace StreamBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var values = await _movieRepository.GetAll();
            return Ok(values);
        }


        [HttpGet("MoviesWithCategory")]
        public async Task<IActionResult> GetMoviesWithCategory()
        {
            var values = await _movieRepository.GetMoviesWithCategory();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var value = await _movieRepository.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(Movie movie)
        {
            await _movieRepository.Create(movie);
            return Ok("Film başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Movie movie)
        {
            await _movieRepository.Update(movie);
            return Ok("Film başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieRepository.Delete(id);
            return Ok("Film başarıyla silindi.");
        }
    }
}