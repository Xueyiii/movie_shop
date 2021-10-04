using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);

        Task<UserLoginResponseModel> ValidateUser(string email, string password);

        Task<IEnumerable<MovieCardResponseModel>> GetPurchaseMoviesByUser(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMoviesByUser(int id);
        Task<IEnumerable<PurchaseRequestModel>> GetPurchaseDetailsByUser(int id);
    }
}