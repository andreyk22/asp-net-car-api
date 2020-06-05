using System.Collections.Generic;
using System.Threading.Tasks;
using car_api_aspnet_core.DataAccess;
using car_api_aspnet_core.Interfaces;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.Domain
{
    public class CarDomain : ICarDomain
    {
        private readonly ICarDA _carDa;
        public CarDomain(ICarDA carDa)
        {
            _carDa = carDa;
        }
        public Task<IEnumerable<ICarResponse>> GetAll()
        {
            return _carDa.GetAll();
        }

        public Task<ICarResponse> Get(int id)
        {
            return _carDa.Get(id);
        }

        public Task<ICarResponse> Add(Car car)
        {
            return _carDa.Add(car);
        }
    }
}