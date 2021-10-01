using System;
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
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
    }
}
