using Microsoft.AspNetCore.Mvc;
using StreamBoxApi.Models;
using StreamBoxApi.Repositories;

namespace StreamBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;

        public ActorsController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var values = await _actorRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var value = await _actorRepository.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(Actor actor)
        {
            await _actorRepository.Create(actor);
            return Ok("Oyuncu başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateActor(Actor actor)
        {
            await _actorRepository.Update(actor);
            return Ok("Oyuncu başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            await _actorRepository.Delete(id);
            return Ok("Oyuncu başarıyla silindi.");
        }
    }
}