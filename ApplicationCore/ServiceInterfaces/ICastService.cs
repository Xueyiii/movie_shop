using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICastService
    {
        Task<CastModel> GetCastById(int id);
    }
}