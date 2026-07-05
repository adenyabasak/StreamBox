using Microsoft.AspNetCore.Mvc;
using StreamBoxApi.Models;
using StreamBoxApi.Repositories;

namespace StreamBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Tüm kategorileri getir
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var values = await _categoryRepository.GetAllCategories();
            return Ok(values);
        }

        // Id'ye göre kategori getir
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value = await _categoryRepository.GetCategoryById(id);

            if (value == null)
            {
                return NotFound("Kategori bulunamadı.");
            }

            return Ok(value);
        }

        // Yeni kategori ekle
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await _categoryRepository.CreateCategory(category);

            return Ok("Kategori başarıyla eklendi.");
        }

        // Kategori güncelle
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            await _categoryRepository.UpdateCategory(category);

            return Ok("Kategori başarıyla güncellendi.");
        }

        // Kategori sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);

            return Ok("Kategori başarıyla silindi.");
        }
    }
}