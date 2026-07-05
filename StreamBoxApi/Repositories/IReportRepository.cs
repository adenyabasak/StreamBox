using StreamBoxApi.Dtos;

namespace StreamBoxApi.Repositories
{
    public interface IReportRepository
    {
        Task<int> GetMovieCount();
        Task<int> GetCategoryCount();
        Task<int> GetActorCount();
        Task<int> GetMovieActorCount();

        Task<List<ReportCountDto>> GetMovieCountByCategory();
        Task<List<ReportCountDto>> GetActorCountByCountry();

        Task<List<ReportMovieDto>> GetMovieCategoryList();
        Task<List<ReportActorMovieDto>> GetMovieActorList();

        Task<ReportMovieDto> GetOldestMovie();
        Task<ReportMovieDto> GetNewestMovie();
    }
}