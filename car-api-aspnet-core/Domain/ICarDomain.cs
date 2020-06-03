using System.Collections.Generic;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.Domain
{
    public interface ICarDomain
    {
        List<int> GetAll();
    }
}