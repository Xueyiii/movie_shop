using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repository;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<MovieCardResponseModel> Get30HighestGrossingMovies()
        {
            var movies = _movieRepository.Get30HighestGrossingMovies();
            var movieCardResponseModel = new List<MovieCardResponseModel>();

            //mapping entities to models data so that services always return models not entities
            foreach (var movie in movies)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl });
            }

            // return list of movieresponse models
            return movieCardResponseModel;
        }

        public MovieDetailsResponseModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);
            var movieDetailsResponseModel = new MovieDetailsResponseModel();

            movieDetailsResponseModel.Id = movie.Id;
            movieDetailsResponseModel.PosterUrl = movie.PosterUrl;
            movieDetailsResponseModel.Title = movie.Title;
            movieDetailsResponseModel.Revenue = movie.Revenue;
            movieDetailsResponseModel.Tagline = movie.Tagline;
            movieDetailsResponseModel.RunTime = movie.RunTime;
            movieDetailsResponseModel.ReleaseDate = movie.ReleaseDate;
            movieDetailsResponseModel.Overview = movie.Overview;
            movieDetailsResponseModel.Price = movie.Price;
            movieDetailsResponseModel.Budget = movie.Budget;
            
            movieDetailsResponseModel.Genres = new List<Genre>();
            
            foreach (var movieGenre in movie.Genres)
            {
                movieDetailsResponseModel.Genres.Add(new Genre{Id = movieGenre.Genre.Id, Name = movieGenre.Genre.Name});
            }
            
            movieDetailsResponseModel.Casts = new List<Cast>();
            foreach (var movieCast in movie.Casts)
            {
                movieDetailsResponseModel.Casts.Add(new Cast{Id = movieCast.Cast.Id, Name = movieCast.Cast.Name, ProfilePath = movieCast.Cast.ProfilePath});
            }
            

            return movieDetailsResponseModel;

        }

        public IEnumerable<MovieCardResponseModel> GetMoviesByGenre(int genreId)
        {
            var movies = _movieRepository.GetMoviesByGenre(genreId);
            var movieCardResponseModel = new List<MovieCardResponseModel>();
            
            foreach (var movie in movies)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, 
                    Title = movie.Title, Revenue = movie.Revenue});
            }

            return movieCardResponseModel;
        }
    }
}

// Movjjjj a = getMovieById("123");
// List<String> names = new List<>();
// foreach (var genre in a.Genres) {
//names.add(genre.name);
// }