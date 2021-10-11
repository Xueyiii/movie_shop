using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopAPI.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // api/movies/toprevenue
        [Route("toprevenue")]
        [HttpGet]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            // along with data you also need to return HTTP status code.
            var movies = await _movieService.Get30HighestGrossingMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }

            // 200 OK
            return Ok(movies);
            // Serialization => convert object to another type of object. (C# to JSON; C# to XML using XMLSerilizer)
            // DeSerilization => JSON to C#

            // .NET Core 3.1 or less = JSON.NET => 3rd party library.
            // New: => System.Text.Json 
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _movieService.GetReviewById(id);
            return Ok(reviews);
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies([FromQuery] int pageSize = 30, [FromQuery] int page = 1,
            string title = "")
        {
            var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
            return Ok(movies);
        }
        
        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId, [FromQuery] int pageSize = 30, [FromQuery] int pageIndex = 1)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId,pageSize, pageIndex);
            return Ok(movies);
        }
    }

}
