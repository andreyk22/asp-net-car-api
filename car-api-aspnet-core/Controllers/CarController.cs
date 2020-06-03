using Microsoft.AspNetCore.Mvc;
using car_api_aspnet_core.Domain;

namespace car_api_aspnet_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        CarDomain _carDomain = null;
        
        public CarController(CarDomain carDomain)
        {
            _carDomain = carDomain;
        }

        /*
         * Get all cars
         */
        public ActionResult Get()
        {
            return Ok(_carDomain.GetAll());
        }
    }
}