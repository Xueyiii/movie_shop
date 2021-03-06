using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        /*public IActionResult GetTopRevenueMovies()
        {
            //var movieService = new MovieService();
            var movies = _movieService.Get30HighestGrossingMovies();
            return View(movies);
        }*/

        public async Task<IActionResult> Details(int id)
        {
            var movieDetailsResponseModel = await _movieService.GetMovieById(id);
            return View(movieDetailsResponseModel);
        }
        
        
    }
}