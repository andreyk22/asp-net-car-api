using System.Collections.Generic;
using System.Threading.Tasks;
using car_api_aspnet_core.Interfaces;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.DataAccess
{
    public interface ICarDA
    {
        Task<IEnumerable<ICarResponse>> GetAll();
        Task<ICarResponse> Get(int id);
        Task<ICarResponse> Add(Car car);
    }
}