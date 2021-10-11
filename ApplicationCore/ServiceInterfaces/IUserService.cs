using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);

        Task<UserLoginResponseModel> ValidateUser(string email, string password);

        Task<PurchaseResponseModel> GetPurchaseMoviesByUser(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMoviesByUser(int id);
        Task<IEnumerable<PurchaseRequestModel>> GetPurchaseDetailsByUser(int id);
        Task<MovieReviewsModel> GetReviewsByUser(int id);
       Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequestModel, int userId);
       Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequestModel, int userId);

       Task<bool> AddFavoriteMovie(FavoriteRequestModel favoriteRequestModel, int userId);
       Task UnfavoriteMovie(FavoriteRequestModel favoriteRequestModel);
       Task<bool> IsFavourite(int userId, int movieId);
       
       Task<bool> AddMovieReview(ReviewModel reviewModel, int userId);
       Task UpdateMovieReview(ReviewModel reviewModel);
       Task DeleteMovieReview(int userId, int movieId);
       
       Task<UserRegisterResponseModel> GetUserDetails(int id);

    }
}