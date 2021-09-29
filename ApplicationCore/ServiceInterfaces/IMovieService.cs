using System;
using System.Collections.Generic;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        //models
        IEnumerable<MovieCardResponseModel> Get30HighestGrossingMovies();
        MovieDetailsResponseModel GetMovieById(int id);
        IEnumerable<MovieCardResponseModel> GetMoviesByGenre(int genreId);

    }
}
