using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<MovieCardResponseModel>>  Get30HighestGrossingMovies()
        {
            // list of movie entites 
            var movies = await _movieRepository.Get30HighestGrossingMovies();
            //var movies = _movieRepository.Get30HighestGrossingMovies();
            var movieCardResponseModel = new List<MovieCardResponseModel>();

            //mapping entities to models data so that services always return models not entities
            foreach (var movie in movies)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl });
            }

            // return list of movieresponse models
            return movieCardResponseModel;
        }

        public async Task<MovieDetailsResponseModel> GetMovieById(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
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
            
            foreach (var movieGenre in movie.Genres)
            {
                movieDetailsResponseModel.Genres.Add(new GenreModel{Id = movieGenre.Genre.Id, Name = movieGenre.Genre.Name});
            }
            
            foreach (var movieCast in movie.Casts)
            {
                movieDetailsResponseModel.Casts.Add(new CastModel{Id = movieCast.Cast.Id, Name = movieCast.Cast.Name, 
                    ProfilePath = movieCast.Cast.ProfilePath, Character = movieCast.Character, Gender = movieCast.Cast.Gender,
                    TmdbUrl = movieCast.Cast.TmdbUrl
                });
            }

            foreach (var trailer in movie.Trailers)
            {
                movieDetailsResponseModel.Trailers.Add(new TrailerModel
                {
                    Id = trailer.Id, Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl, MovieId = trailer.MovieId
                });
            }

            return movieDetailsResponseModel;

        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId);
            var movieCardResponseModel = new List<MovieCardResponseModel>();
            
            foreach (var movie in movies)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, 
                    Title = movie.Title, Revenue = movie.Revenue});
            }

            return movieCardResponseModel;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetTopRatedMovies();

            var movieCardResponseModel = new List<MovieCardResponseModel>();
            
            foreach (var movie in movies)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel
                {
                    Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title
                });
            }
            
            return movieCardResponseModel;
        }

        public async Task<IEnumerable<ReviewModel>> GetReviewById(int id, int pageSize = 30, int page = 1)
        {
            var reviews = await _movieRepository.GetMovieReviews(id, pageSize, page);
            var reviewsModel = new List<ReviewModel>();

            foreach (var review in reviews)
            {
                reviewsModel.Add(new ReviewModel
                {
                    MovieId = review.MovieId, UserId = review.UserId, Rating = review.Rating,
                    ReviewText = review.ReviewText, Name = review.User.FirstName + " " + review.User.LastName
                });
            }
            return reviewsModel;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetMoviesByPagination(int pageSize = 30, int pageIndex = 1, string title = "")
        {
            var movies = await _movieRepository.GetAllMovies(pageSize, pageIndex);
            var movieCardResponseModel = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title});
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