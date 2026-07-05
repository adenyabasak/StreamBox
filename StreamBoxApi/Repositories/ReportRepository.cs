using Dapper;
using StreamBoxApi.Data;
using StreamBoxApi.Dtos;

namespace StreamBoxApi.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DapperContext _context;

        public ReportRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> GetMovieCount()
        {
            string query = "SELECT COUNT(*) FROM Movies";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query);
        }

        public async Task<int> GetCategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Categories";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query);
        }

        public async Task<int> GetActorCount()
        {
            string query = "SELECT COUNT(*) FROM Actors";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(query);
        }

        public async Task<List<ReportCountDto>> GetMovieCountByCategory()
        {
            string query = @"
                SELECT 
                    c.CategoryName AS Name,
                    COUNT(m.MovieId) AS Count
                FROM Categories c
                LEFT JOIN Movies m ON c.CategoryId = m.CategoryId
                GROUP BY c.CategoryName";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ReportCountDto>(query);
            return values.ToList();
        }

        public async Task<List<ReportCountDto>> GetActorCountByCountry()
        {
            string query = @"
                SELECT 
                    Country AS Name,
                    COUNT(*) AS Count
                FROM Actors
                GROUP BY Country";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ReportCountDto>(query);
            return values.ToList();
        }

        public async Task<List<ReportMovieDto>> GetMovieCategoryList()
        {
            string query = @"
                SELECT 
                    m.Title,
                    m.ReleaseYear,
                    c.CategoryName
                FROM Movies m
                INNER JOIN Categories c ON m.CategoryId = c.CategoryId";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ReportMovieDto>(query);
            return values.ToList();
        }

        public async Task<List<ReportActorMovieDto>> GetMovieActorList()
        {
            string query = @"
                SELECT
                    m.Title AS MovieTitle,
                    a.ActorName
                FROM MovieActors ma
                INNER JOIN Movies m ON ma.MovieId = m.MovieId
                INNER JOIN Actors a ON ma.ActorId = a.ActorId";

            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ReportActorMovieDto>(query);
            return values.ToList();
        }

        public async Task<ReportMovieDto> GetOldestMovie()
        {
            string query = @"
                SELECT TOP 1
                    m.Title,
                    m.ReleaseYear,
                    c.CategoryName
                FROM Movies m
                INNER JOIN Categories c ON m.CategoryId = c.CategoryId
                ORDER BY m.ReleaseYear ASC";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ReportMovieDto>(query);
        }

        public async Task<ReportMovieDto> GetNewestMovie()
        {
            string query = @"
                SELECT TOP 1
                    m.Title,
                    m.ReleaseYear,
                    c.CategoryName
                FROM Movies m
                INNER JOIN Categories c ON m.CategoryId = c.CategoryId
                ORDER BY m.ReleaseYear DESC";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ReportMovieDto>(query);
        }

        public async Task<int> GetMovieActorCount()
        {
            string query = "SELECT COUNT(*) FROM MovieActors";

            using var connection = _context.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(query);
        }
    }
}