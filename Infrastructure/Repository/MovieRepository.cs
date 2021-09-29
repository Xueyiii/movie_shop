using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;       

        public MovieRepository(MovieShopDbContext dbContext)
        {
            _movieShopDbContext = dbContext;
        }
        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            // go to database and get data using LINQ with EF
            var movies = _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            // var movies = from m in _movieShopDbContext.Movies
            //     join mg in _movieShopDbContext.MovieGenres
            //         on m.Id equals mg.MovieId
            //     join g in _movieShopDbContext.Genres on mg.GenreId equals g.Id
            //     select new { } ;
            var movies = _movieShopDbContext.Movies.Include(m => m.Genres).ThenInclude(mg=> mg.Genre).
                Include(m=> m.Casts).ThenInclude(mc=> mc.Cast).FirstOrDefault(m=>m.Id==id);
            return movies;
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            var movies = _movieShopDbContext.Movies.Include(m => m.Genres).Where(m => m.Id == genreId).ToList();
            return movies;
        }
    }
}
