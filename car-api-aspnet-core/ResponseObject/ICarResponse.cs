using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.Interfaces
{
    public class ICarResponse
    {
        public int Id { get; set; }
        
        public string Make { get; set; } 
        
        public string Model { get; set; } 
        
        public string Color { get; set; } 
        
        public string Price { get; set; } 
        
        public int Year { get; set; }
        
        public int Available { get; set; }
        public Owner Owner { get; set; }
    }
}