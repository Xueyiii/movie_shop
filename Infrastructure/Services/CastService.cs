using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repository;

namespace Infrastructure.Services
{
    public class CastService: ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<CastModel> GetCastById(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            if (cast == null)
            {
                throw new Exception("No cast found!");
            }

            var castModel = new CastModel
            {
                Id = cast.Id,
                Gender = cast.Gender,
                Name = cast.Name,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
                Movies = cast.Movies.Select(mc => new MovieCardResponseModel()
                {
                    Id = mc.MovieId, 
                    PosterUrl = mc.Movie.PosterUrl, 
                    Title = mc.Movie.Title,
                })
            };
            return castModel;
        }
        
    }
}