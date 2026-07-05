using Dapper;
using StreamBoxApi.Data;
using StreamBoxApi.Models;

namespace StreamBoxApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            string query = "SELECT * FROM Categories";

            using var connection = _context.CreateConnection();

            var values = await connection.QueryAsync<Category>(query);

            return values.ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            string query = "SELECT * FROM Categories WHERE CategoryId=@Id";

            using var connection = _context.CreateConnection();

            var value = await connection.QueryFirstOrDefaultAsync<Category>(query, new
            {
                Id = id
            });

            return value;
        }

        public async Task CreateCategory(Category category)
        {
            string query = @"INSERT INTO Categories(CategoryName)
                             VALUES(@CategoryName)";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, category);
        }

        public async Task UpdateCategory(Category category)
        {
            string query = @"UPDATE Categories
                             SET CategoryName=@CategoryName
                             WHERE CategoryId=@CategoryId";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, category);
        }

        public async Task DeleteCategory(int id)
        {
            string query = "DELETE FROM Categories WHERE CategoryId=@Id";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, new
            {
                Id = id
            });
        }
    }
}