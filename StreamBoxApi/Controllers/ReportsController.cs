using Microsoft.AspNetCore.Mvc;
using StreamBoxApi.Repositories;

namespace StreamBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("MovieCount")]
        public async Task<IActionResult> GetMovieCount()
        {
            return Ok(await _reportRepository.GetMovieCount());
        }

        [HttpGet("CategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            return Ok(await _reportRepository.GetCategoryCount());
        }

        [HttpGet("ActorCount")]
        public async Task<IActionResult> GetActorCount()
        {
            return Ok(await _reportRepository.GetActorCount());
        }

        [HttpGet("MovieCountByCategory")]
        public async Task<IActionResult> GetMovieCountByCategory()
        {
            return Ok(await _reportRepository.GetMovieCountByCategory());
        }

        [HttpGet("ActorCountByCountry")]
        public async Task<IActionResult> GetActorCountByCountry()
        {
            return Ok(await _reportRepository.GetActorCountByCountry());
        }

        [HttpGet("MovieCategoryList")]
        public async Task<IActionResult> GetMovieCategoryList()
        {
            return Ok(await _reportRepository.GetMovieCategoryList());
        }

        [HttpGet("MovieActorList")]
        public async Task<IActionResult> GetMovieActorList()
        {
            return Ok(await _reportRepository.GetMovieActorList());
        }

        [HttpGet("OldestMovie")]
        public async Task<IActionResult> GetOldestMovie()
        {
            return Ok(await _reportRepository.GetOldestMovie());
        }

        [HttpGet("NewestMovie")]
        public async Task<IActionResult> GetNewestMovie()
        {
            return Ok(await _reportRepository.GetNewestMovie());
        }

        [HttpGet("MovieActorCount")]
        public async Task<IActionResult> GetMovieActorCount()
        {
            return Ok(await _reportRepository.GetMovieActorCount());
        }
    }
}