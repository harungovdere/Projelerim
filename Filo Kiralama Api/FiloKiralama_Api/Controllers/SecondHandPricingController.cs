using FiloKiralama_Api.Dtos.SecondHandPricingDtos;
using FiloKiralama_Api.Repositories.SecondHandPricingRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondHandPricingController : ControllerBase
    {
        
        private readonly ISecondHandPricingRepository _secondHandPricingRepository;
        public SecondHandPricingController(ISecondHandPricingRepository secondHandPricingRepository)
        {
            _secondHandPricingRepository = secondHandPricingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SecondHandPricingList()
        {
            var values = await _secondHandPricingRepository.GetAllSecondHandPricing();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSecondHandPricing(CreateSecondHandPricingDto createSecondHandPricing)
        {
            _secondHandPricingRepository.CreateSecondHandPricing(createSecondHandPricing);
            return Ok("Fiyat başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            _secondHandPricingRepository.DeleteSecondHandPricing(id);
            return Ok("Fiyat başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSecondHandPricing(UpdateSecondHandPricingDto updateSecondHandPricing)
        {
            _secondHandPricingRepository.UpdateSecondHandPricing(updateSecondHandPricing);
            return Ok("Fiyat başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecondHandPricing(int id)
        {
            var value = await _secondHandPricingRepository.GetSecondHandPricing(id);
            return Ok(value);
        }
    }
}
