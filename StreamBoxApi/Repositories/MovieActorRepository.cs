using Dapper;
using StreamBoxApi.Data;
using StreamBoxApi.Dtos;
using StreamBoxApi.Models;

namespace StreamBoxApi.Repositories
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private readonly DapperContext _context;

        public MovieActorRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<MovieActor>> GetAll()
        {
            string query = "SELECT * FROM MovieActors";

            using var connection = _context.CreateConnection();

            var values = await connection.QueryAsync<MovieActor>(query);

            return values.ToList();
        }

        public async Task<MovieActor> GetById(int id)
        {
            string query = "SELECT * FROM MovieActors WHERE MovieActorId=@Id";

            using var connection = _context.CreateConnection();

            var value = await connection.QueryFirstOrDefaultAsync<MovieActor>(query, new
            {
                Id = id
            });

            return value;
        }

        public async Task Create(MovieActor movieActor)
        {
            string query = @"INSERT INTO MovieActors(MovieId,ActorId)
                             VALUES(@MovieId,@ActorId)";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, movieActor);
        }


        public async Task Update(MovieActor movieActor)
        {
            string query = @"UPDATE MovieActors 
                     SET MovieId = @MovieId,
                         ActorId = @ActorId
                     WHERE MovieActorId = @MovieActorId";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, movieActor);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM MovieActors WHERE MovieActorId=@Id";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(query, new
            {
                Id = id
            });
        }

        public async Task<List<MovieActorListDto>> GetMovieActorsWithDetails()
        {
            string query = @"
                SELECT
                    ma.MovieActorId,
                    m.Title AS MovieTitle,
                    a.ActorName
                FROM MovieActors ma
                INNER JOIN Movies m
                    ON ma.MovieId = m.MovieId
                INNER JOIN Actors a
                    ON ma.ActorId = a.ActorId";

            using var connection = _context.CreateConnection();

            var values = await connection.QueryAsync<MovieActorListDto>(query);

            return values.ToList();
        }
    }
}