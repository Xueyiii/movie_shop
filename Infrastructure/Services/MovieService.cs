using System;
using System.Collections.Generic;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repository;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public IEnumerable<MovieCardResponseModel> Get30HighestGossingMovies()
        {
            var repo = new MovieRepository();

            var movies = repo.Get30HighestGossingMovies();
            var movieCardResponseModel = new List<MovieCardResponseModel>();

            //mapping entities to models data so that services always return models not entities
            foreach (var movie in movies)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PostURL = movie.PosterUrl });
            }

            // return list of movieresponse models
            return movieCardResponseModel;
        }
    }
}
