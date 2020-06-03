using System.Collections.Generic;
using System.Threading.Tasks;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.DataAccess
{
    public interface ICarDA
    {
        Task<IEnumerable<Car>> GetAll();
        Task<Car> Get(int id);
        Task<int> Add(Car car);
    }
}