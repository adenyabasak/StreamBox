using Microsoft.AspNetCore.Mvc;
using StreamBoxApi.Models;
using StreamBoxApi.Repositories;

namespace StreamBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly IMovieActorRepository _movieActorRepository;

        public MovieActorsController(IMovieActorRepository movieActorRepository)
        {
            _movieActorRepository = movieActorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovieActors()
        {
            var values = await _movieActorRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieActorById(int id)
        {
            var value = await _movieActorRepository.GetById(id);
            return Ok(value);
        }

        [HttpGet("MovieActorsWithDetails")]
        public async Task<IActionResult> GetMovieActorsWithDetails()
        {
            var values = await _movieActorRepository.GetMovieActorsWithDetails();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieActor(MovieActor movieActor)
        {
            await _movieActorRepository.Create(movieActor);
            return Ok("Film - Oyuncu eşleştirmesi başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovieActor(MovieActor movieActor)
        {
            await _movieActorRepository.Update(movieActor);
            return Ok("Film - Oyuncu eşleştirmesi başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieActor(int id)
        {
            await _movieActorRepository.Delete(id);
            return Ok("Film - Oyuncu eşleştirmesi başarıyla silindi.");
        }
    }
}