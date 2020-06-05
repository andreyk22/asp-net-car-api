using System.ComponentModel.DataAnnotations;

namespace car_api_aspnet_core.Model
{
    public class Car
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "Make field can not exceed 20 characters.")]
        public string Make { get; set; } 
        
        [Required]
        [StringLength(20, ErrorMessage = "Model field can not exceed 20 characters.")]
        public string Model { get; set; } 
        
        [StringLength(15, ErrorMessage = "Color field can not exceed 15 characters.")]
        public string Color { get; set; } 
        
        [Required]
        public string Price { get; set; } 
        
        public int Year { get; set; }
        
        [Required]
        [Range(0, 1)]
        public int Available { get; set; }
        
        [Required]
        public int OwnerId { get; set; }
        
    }
}