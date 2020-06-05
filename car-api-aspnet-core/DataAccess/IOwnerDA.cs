using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using car_api_aspnet_core.Interfaces;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.DataAccess
{
    public interface IOwnerDA
    {
        Task<IEnumerable<Owner>> GetAll();
        Task<IOwnerResponse> Get(int id);
        Task<IOwnerResponse> Add(Owner owner);
    }
}