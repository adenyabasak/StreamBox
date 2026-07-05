using Dapper;
using StreamBoxApi.Data;
using StreamBoxApi.Dtos;
using StreamBoxApi.Models;

namespace StreamBoxApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DapperContext _context;

        public MovieRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAll()
        {
            string query = "SELECT * FROM Movies";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<Movie>(query);
            return values.ToList();
        }

        public async Task<Movie> GetById(int id)
        {
            string query = "SELECT * FROM Movies WHERE MovieId=@Id";
            using var connection = _context.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<Movie>(query, new { Id = id });
            return value;
        }

        public async Task Create(Movie movie)
        {
            string query = @"INSERT INTO Movies(Title, Description, ImageUrl, ReleaseYear, CategoryId)
                             VALUES(@Title, @Description, @ImageUrl, @ReleaseYear, @CategoryId)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, movie);
        }

        public async Task Update(Movie movie)
        {
            string query = @"UPDATE Movies
                             SET Title=@Title,
                                 Description=@Description,
                                 ImageUrl=@ImageUrl,
                                 ReleaseYear=@ReleaseYear,
                                 CategoryId=@CategoryId
                             WHERE MovieId=@MovieId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, movie);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Movies WHERE MovieId=@Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<List<MovieListDto>> GetMoviesWithCategory()
        {
            string query = @"
                SELECT 
                    m.MovieId,
                    m.Title,
                    c.CategoryName,
                    m.ReleaseYear,
                    m.ImageUrl
                FROM Movies m
                INNER JOIN Categories c ON m.CategoryId = c.CategoryId";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<MovieListDto>(query);
            return values.ToList();
        }
    }
}