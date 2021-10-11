using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repository;

namespace Infrastructure.Services
{
    public class AdminService:IAdminService
    {
        private readonly AdminService _adminService;
        private readonly MovieRepository _movieRepository;
        private readonly CastRepository _castRepository;
        public AdminService(AdminService adminService, MovieRepository movieRepository, CastRepository castRepository)
        {
            _adminService = adminService;
            _movieRepository = movieRepository;
            _castRepository = castRepository;
        }
        public async Task<bool> CreateMovie(MovieDetailsRequestModel movieDetailsRequestModel)
        {

            var movie = new Movie()
            {
                Id = movieDetailsRequestModel.Id, Title = movieDetailsRequestModel.Title,
                PosterUrl = movieDetailsRequestModel.PosterUrl,
                BackdropUrl = movieDetailsRequestModel.BackdropUrl, Rating = movieDetailsRequestModel.Rating,
                Budget = movieDetailsRequestModel.Budget,
                Overview = movieDetailsRequestModel.Overview, Tagline = movieDetailsRequestModel.Tagline,
                Revenue = movieDetailsRequestModel.Revenue,
                ImdbUrl = movieDetailsRequestModel.ImdbUrl, TmdbUrl = movieDetailsRequestModel.TmdbUrl,
                ReleaseDate = DateTime.Now,
                RunTime = movieDetailsRequestModel.RunTime, Price = movieDetailsRequestModel.Price
            };

            var addMovie = await _movieRepository.AddAsync(movie);
            var cast = new Cast();
            foreach (var casts in movieDetailsRequestModel.Casts)
            {
                cast.Id = casts.Id;
                cast.Name = casts.Name;
                cast.Gender = casts.Gender;
                cast.ProfilePath = casts.ProfilePath;
                cast.TmdbUrl = casts.TmdbUrl;
            }

            var addMovieGenre = await _castRepository.AddAsync(cast);

            return movie.Id > 0;
        }
    }
}