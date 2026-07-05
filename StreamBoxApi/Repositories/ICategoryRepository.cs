using StreamBoxApi.Models;

namespace StreamBoxApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();

        Task<Category> GetCategoryById(int id);

        Task CreateCategory(Category category);

        Task UpdateCategory(Category category);

        Task DeleteCategory(int id);
    }
}