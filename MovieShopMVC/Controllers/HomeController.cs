using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            // it will look inside view folder => folder name with same name as control name and
            // look for view with same name as action method name.

            // Display top revenue movies
            // get model data
            // var movieService = new MovieService();
            // var movies = movieService.Get30HighestGrossingMovies();
            // models
            var movies = await _movieService.Get30HighestGrossingMovies();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
