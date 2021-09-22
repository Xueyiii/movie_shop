using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // it will look inside view folder => folder name with same name as control name and
            // look for view with same name as action method name.

            // Display top revenue movies
            // get model data
            var movieService = new MovieService();
            var movies = movieService.Get30HighestGossingMovies();
            // models
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
