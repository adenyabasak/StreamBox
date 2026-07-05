using Dapper;
using StreamBoxApi.Data;
using StreamBoxApi.Models;

namespace StreamBoxApi.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly DapperContext _context;

        public ActorRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetAll()
        {
            string query = "SELECT * FROM Actors";
            using var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<Actor>(query);
            return values.ToList();
        }

        public async Task<Actor> GetById(int id)
        {
            string query = "SELECT * FROM Actors WHERE ActorId=@Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Actor>(query, new { Id = id });
        }

        public async Task Create(Actor actor)
        {
            string query = @"INSERT INTO Actors(ActorName, Age, Country)
                             VALUES(@ActorName, @Age, @Country)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, actor);
        }

        public async Task Update(Actor actor)
        {
            string query = @"UPDATE Actors
                             SET ActorName=@ActorName,
                                 Age=@Age,
                                 Country=@Country
                             WHERE ActorId=@ActorId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, actor);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Actors WHERE ActorId=@Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}