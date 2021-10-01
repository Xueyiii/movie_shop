using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);

        Task<UserLoginResponseModel> ValidateUser(string email, string password);
    }
}