using FiloKiralama_Api.Dtos.RentalCarReservedDtos;
using FiloKiralama_Api.Repositories.RentalCarReservedRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalCarReservedController : ControllerBase
    {
        private readonly IRentalCarReservedRepository _repository;
        public RentalCarReservedController(IRentalCarReservedRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRentalCarReserved(CreateRentalCarReservedDto createRentalCarReservedDto)
        {
            _repository.CreateRentalCarReserved(createRentalCarReservedDto);
            return Ok("Araç rezerve başarılı bir şekilde yapıldı.");
        }

        [HttpGet]
        public async Task<IActionResult> RentalCarReservedList()
        {
            var values = await _repository.RentalCarReservedList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalCarReserved(int id)
        {
            var value = await _repository.GetRentalCarReserved(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRentalCarReserved(UpdateRentalCarReservedDto updateRentalCarReservedDto)
        {
            _repository.UpdateRentalCarReserved(updateRentalCarReservedDto);
            return Ok("Araç rezerve başarılı bir şekilde güncellendi");
        }
    }
}
