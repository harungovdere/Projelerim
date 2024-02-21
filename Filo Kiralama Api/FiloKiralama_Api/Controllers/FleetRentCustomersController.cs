using FiloKiralama_Api.Dtos.FleetRentCustomersDtos;
using FiloKiralama_Api.Repositories.FleetRentCustomersRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetRentCustomersController : ControllerBase
    {
        private readonly IFleetRentCustomersRepository _fleetRentCustomersRepository;

        public FleetRentCustomersController(IFleetRentCustomersRepository fleetRentCustomersRepository)
        {
            _fleetRentCustomersRepository = fleetRentCustomersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFleetCustomer(CreateFleetRentCustomersDto createFleetRentCustomersDto)
        {
            _fleetRentCustomersRepository.CreateFleetCustomer(createFleetRentCustomersDto);
            return Ok("Filo müşteri kaydı başarılı bir şekilde yapıldı.");
        }

        [HttpGet]
        public async Task<IActionResult> FleetCustomerList()
        {
            var values = await _fleetRentCustomersRepository.GetAllFleetCustomers();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFleetCustomer(string id)
        {
            var value = await _fleetRentCustomersRepository.GetFleetCustomer(id);
            return Ok(value);
        }
    }
}
