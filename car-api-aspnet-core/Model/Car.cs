namespace car_api_aspnet_core.Model
{
    public class Car
    {
        public int Id { get; set; }
        
        public string Make { get; set; } 
        
        public string Model { get; set; } 
        
        public string Color { get; set; } 
        
        public string Price { get; set; } 
        
        public int Year { get; set; }
        
        public int Available { get; set; }
    }
}