using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository: IAsyncRepository<Movie>
    {
        //IEnumerable<Movie> Get30HighestGrossingMovies();
        Task<IEnumerable<Movie>> Get30HighestGrossingMovies();
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1);
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1);
        Task<IEnumerable<Movie>> GetAllMovies(int pageSize = 30, int page = 1);
    }
}
