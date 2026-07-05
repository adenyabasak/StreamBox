using StreamBoxApi.Models;
using StreamBoxApi.Dtos;

namespace StreamBoxApi.Repositories
{
    public interface IMovieRepository
    {


        Task<List<Movie>> GetAll();

        Task<Movie> GetById(int id);

        Task Create(Movie movie);

        Task Update(Movie movie);

        Task Delete(int id);


        Task<List<MovieListDto>> GetMoviesWithCategory();
    }
}