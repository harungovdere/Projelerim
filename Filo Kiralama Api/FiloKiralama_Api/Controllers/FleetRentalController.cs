
using FiloKiralama_Api.Dtos.FleetRentalDtos;
using FiloKiralama_Api.Repositories.FleetRentalRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetRentalController : ControllerBase
    {
        private readonly IFleetRentalRepository _fleetRentalRepository;

        public FleetRentalController(IFleetRentalRepository fleetRentalRepository)
        {
            _fleetRentalRepository = fleetRentalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> FleetRentalList()
        {
            var values = await _fleetRentalRepository.GetAllFleetRental();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFleetRental(CreateFleetRentalDto createFleetRentalDto)
        {
            _fleetRentalRepository.CreateFleetRental(createFleetRentalDto);
            return Ok("Filo başarılı bir şekilde eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFleetRental(int id)
        {
            var value = await _fleetRentalRepository.GetFleetRental(id);
            return Ok(value);
        }
    }
}
