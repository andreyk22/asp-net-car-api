using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using car_api_aspnet_core.Interfaces;

namespace car_api_aspnet_core.Model
{
    public class Owner
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "First name field can not exceed 50 characters.")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Last name field can not exceed 50 characters.")]
        public string LastName { get; set; }
        
        [Range(18, 99)]
        public int Age { get; set; }
        
        [StringLength(100, ErrorMessage = "Address field can not exceed 100 characters.")]
        public string Address { get; set; }
    }
}