using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IAdminService
    {
        Task<bool> CreateMovie(MovieDetailsRequestModel movieDetailsRequestModel);
    }
}