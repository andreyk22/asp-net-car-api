using System.Collections.Generic;
using car_api_aspnet_core.DataAccess;

namespace car_api_aspnet_core.Domain
{
    public class CarDomain : ICarDomain
    {
        CarDA _carDa = null;
        public CarDomain(CarDA carDa)
        {
            _carDa = carDa;
        }
        public List<int> GetAll()
        {
            return _carDa.GetAll();
        }
    }
}