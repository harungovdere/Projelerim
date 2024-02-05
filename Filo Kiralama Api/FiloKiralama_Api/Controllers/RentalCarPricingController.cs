using FiloKiralama_Api.Dtos.RentalCarPricingDtos;
using FiloKiralama_Api.Repositories.RentalCarPricingRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalCarPricingController : ControllerBase
    {
        private readonly IRentalCarPricingRepository _rentalCarPricingRepository;
        public RentalCarPricingController(IRentalCarPricingRepository rentalCarPricingRepository)
        {
            _rentalCarPricingRepository = rentalCarPricingRepository;
        }
        [HttpGet]
        public async Task<IActionResult> RentalCarPricingList()
        {
            var values = await _rentalCarPricingRepository.GetAllRentalCarPricing();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRentalCarPricing(CreateRentalCarPricingDto createRentalCarPricingDto)
        {
            _rentalCarPricingRepository.CreateRentalCarPricing(createRentalCarPricingDto);
            return Ok("Fiyat başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalCarPricing(int id)
        {
            _rentalCarPricingRepository.DeleteRentalCarPricing(id);
            return Ok("Fiyat başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRentalCarPricing(UpdateRentalCarPricingDto updateRentalCarPricingDto)
        {
            _rentalCarPricingRepository.UpdateRentalCarPricing(updateRentalCarPricingDto);
            return Ok("Fiyat başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalCarPricing(int id)
        {
            var value = await _rentalCarPricingRepository.GetRentalCarPricing(id);
            return Ok(value);
        }
    }
}
