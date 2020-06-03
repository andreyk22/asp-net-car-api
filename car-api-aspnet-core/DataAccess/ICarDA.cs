using System.Collections.Generic;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.DataAccess
{
    public interface ICarDA
    {
        public List<int> GetAll()
        {
            return new List<int>(){ 10, 20, 30, 40 };
        }
    }
}