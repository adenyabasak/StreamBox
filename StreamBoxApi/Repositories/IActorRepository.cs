using StreamBoxApi.Models;

namespace StreamBoxApi.Repositories
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAll();
        Task<Actor> GetById(int id);
        Task Create(Actor actor);
        Task Update(Actor actor);
        Task Delete(int id);
    }
}