using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        //models
        Task<IEnumerable<MovieCardResponseModel>> Get30HighestGrossingMovies();
        Task<MovieDetailsResponseModel> GetMovieById(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1);
        
        Task<IEnumerable<MovieCardResponseModel>> GetTopRatedMovies();
        Task<IEnumerable<ReviewModel>> GetReviewById(int id, int pageSize = 30, int pageIndex = 1);

        Task<IEnumerable<MovieCardResponseModel>> GetMoviesByPagination(int pageSize = 30, int pageIndex = 1,string title = "");

    }
}
