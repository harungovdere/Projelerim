using FiloKiralama_Api.Dtos.FleetRentalRequestDtos;
using FiloKiralama_Api.Repositories.FleetRentalRequestRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetRentalRequest : ControllerBase
    {
        private readonly IFleetRentalRequestRepository _repository;
        public FleetRentalRequest(IFleetRentalRequestRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateFleetRentalRequest(CreateFleetRentalRequestDto createFleetRentalRequestDto)
        {
            _repository.CreateFleetRentalRequest(createFleetRentalRequestDto);
            return Ok("Filo kiralama talebi başarılı bir şekilde yapıldı.");
        }

        [HttpGet]
        public async Task<IActionResult> FleetRentalRequestList()
        {
            var values = await _repository.GetAllFleetRentalRequest();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFleetRentalRequest(int id)
        {
            var value = await _repository.GetFleetRentalRequest(id);
            return Ok(value);
        }
    }
}
