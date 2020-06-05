using System.Threading.Tasks;
using car_api_aspnet_core.Domain;
using car_api_aspnet_core.Model;
using Microsoft.AspNetCore.Mvc;

namespace car_api_aspnet_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : Controller
    {
        private readonly IOwnerDomain _ownerDomain;

        public OwnerController(IOwnerDomain ownerDomain)
        {
            _ownerDomain = ownerDomain;
        }
        // GET
        public async Task<ActionResult> Get()
        {
            var result = await _ownerDomain.GetAll();
            if (result == null)
            {
                return NotFound(); 
            }

            return Ok(result);
        }
        
        /*
         * Get owner by id
         */
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _ownerDomain.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        /*
         * Create a new owner
         */
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Owner owner)
        {
            var result = await _ownerDomain.Add(owner);
            return Ok(result);

        }
    }
}