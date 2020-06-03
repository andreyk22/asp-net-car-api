using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using car_api_aspnet_core.Domain;
using car_api_aspnet_core.Model;

namespace car_api_aspnet_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ICarDomain _carDomain;
        
        public CarController(ICarDomain carDomain)
        {
            _carDomain = carDomain;
        }

        /*
         * Get all cars
         */
        public async Task<ActionResult> Get()
        {
            var result = await _carDomain.GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /*
         * Get car by id
         */
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _carDomain.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Car car)
        {
            try
            {
                var result = await _carDomain.Add(car);
                return Ok("Rows affected: " + result);
            } catch {
                return BadRequest();
            }
        }
        
    }
}