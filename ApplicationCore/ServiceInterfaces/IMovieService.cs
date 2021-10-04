using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        //models
        Task<IEnumerable<MovieCardResponseModel>> Get30HighestGrossingMovies();
        Task<MovieDetailsResponseModel> GetMovieById(int id);
        IEnumerable<MovieCardResponseModel> GetMoviesByGenre(int genreId);
        
    }
}
