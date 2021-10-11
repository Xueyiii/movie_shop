using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IPurchaseRepository: IAsyncRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetPurchaseMoviesByUserId(int userId, int pageSize = 30, int pageIndex = 1);
    }
}