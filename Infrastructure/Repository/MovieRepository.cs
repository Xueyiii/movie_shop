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

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1)
        {
            var totalMoviesCountByGenre =
                await _dbContext.MovieGenres.Where(g => g.GenreId == genreId).CountAsync();
            if (totalMoviesCountByGenre == 0) throw new Exception("NO Movies found for this genre");
            
            var movies = await _dbContext.MovieGenres.Where(mg => mg.GenreId == genreId).Include(mg=> mg.Movie)
                .Select(mg=> new Movie
                {
                    Id = mg.GenreId,
                    PosterUrl = mg.Movie.PosterUrl,
                    Title = mg.Movie.Title,
                    ReleaseDate = mg.Movie.ReleaseDate
                })
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            var moveis = await _dbContext.Reviews.Include(r => r.Movie).GroupBy(r => new
            {
                Id = r.MovieId,
                r.Movie.PosterUrl,
                r.Movie.Title,
                r.Movie.ReleaseDate
            }).OrderByDescending(g => g.Average(r => r.Rating)).Select(m => new Movie
                {
                    Id = m.Key.Id,
                    PosterUrl = m.Key.PosterUrl,
                    Title = m.Key.Title,
                    ReleaseDate = m.Key.ReleaseDate,
                    Rating = m.Average(r => r.Rating)
                })
                .Take(50).ToListAsync();

            return moveis;
        }

        public async Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).Include(r => r.User).Select(r =>
                new Review
                {
                    UserId = r.UserId,
                    MovieId = r.MovieId,
                    ReviewText = r.ReviewText,
                    Rating = r.Rating,
                    Movie = new Movie
                    {
                        Id = r.Movie.Id,
                        Title = r.Movie.Title
                    },
                    User = new User
                    {
                        Id = r.User.Id,
                        FirstName = r.User.FirstName,
                        LastName = r.User.LastName
                    }
                }).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            return reviews;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies(int pageSize = 30, int page = 1)
        {
            var movies = await _dbContext.Movies.Skip(pageSize * (page - 1)).Take(pageSize)
                .ToListAsync();
            return movies;
        }
    }
}
