using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        private readonly MovieShopDbContext _movieShopDbContext;       

        public MovieRepository(MovieShopDbContext dbContext): base (dbContext)
        {
            // _movieShopDbContext = dbContext;
        }
        // public IEnumerable<Movie> Get30HighestGrossingMovies()
        // {
        //     // go to database and get data using LINQ with EF
        //     var movies = _movieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
        //     return movies;
        // }
        
        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            // async/await go as pair
            // EF , Dapper...they have both async methods and sync method
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            // var movies = from m in _movieShopDbContext.Movies
            //     join mg in _movieShopDbContext.MovieGenres
            //         on m.Id equals mg.MovieId
            //     join g in _movieShopDbContext.Genres on mg.GenreId equals g.Id
            //     select new { } ;
            var movies = await _dbContext.Movies.Include(m => m.Genres).ThenInclude(mg=> mg.Genre).
                Include(m=> m.Casts).ThenInclude(mc=> mc.Cast).Include(m=>m.Trailers).FirstOrDefaultAsync(m=>m.Id==id);
            if (movies == null)
            {
                throw new Exception($"No Movie Found for this {id}");
            }

            var rating = await _dbContext.Reviews.Where(r => r.MovieId == id).AverageAsync(r => r.Rating);
            movies.Rating = rating;
            return movies;
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            var movies = _movieShopDbContext.Movies.Include(m => m.Genres).Where(m => m.Id == genreId).ToList();
            return movies;
        }
        
    }
}
