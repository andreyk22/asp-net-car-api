using System.Collections.Generic;

namespace car_api_aspnet_core.DataAccess
{
    public class CarDA : ICarDA
    {
        public List<int> GetAll()
        {
            return new List<int>(){ 10, 20, 30, 40 };
        }
    }
}