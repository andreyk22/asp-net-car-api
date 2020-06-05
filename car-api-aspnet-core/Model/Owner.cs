using System.Collections;
using System.Collections.Generic;
using car_api_aspnet_core.Interfaces;

namespace car_api_aspnet_core.Model
{
    public class Owner
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int Age { get; set; }

        public string Address { get; set; }
    }
}