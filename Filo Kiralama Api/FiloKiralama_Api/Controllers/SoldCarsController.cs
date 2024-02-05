using FiloKiralama_Api.Repositories.SoldCarsRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoldCarsController : ControllerBase
    {
        private readonly ISoldCarsRepository _soldCarsRepository;

        public SoldCarsController(ISoldCarsRepository soldCarsRepository)
        {
            _soldCarsRepository = soldCarsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AllSoldCars()
        {
            var values = await _soldCarsRepository.SoldCarsList();
            return Ok(values);
        }
    }
}
