using System.Collections;
using System.Collections.Generic;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.Interfaces
{
    public class IOwnerResponse
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int Age { get; set; }

        public string Address { get; set; }
        public List<Car> Cars { get; set; }
    }
}
