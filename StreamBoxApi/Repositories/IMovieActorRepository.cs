using StreamBoxApi.Dtos;
using StreamBoxApi.Models;

namespace StreamBoxApi.Repositories
{
    public interface IMovieActorRepository
    {
        Task<List<MovieActor>> GetAll();

        Task<MovieActor> GetById(int id);

        Task Create(MovieActor movieActor);

        Task Update(MovieActor movieActor);

        Task Delete(int id);

        Task<List<MovieActorListDto>> GetMovieActorsWithDetails();
    }
}