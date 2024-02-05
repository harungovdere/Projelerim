using FiloKiralama_Api.Dtos.CarReturnDtos;
using FiloKiralama_Api.Repositories.CarReturnRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReturnController : ControllerBase
    {
        private readonly ICarReturnRepository _carReturnRepository;

        public CarReturnController(ICarReturnRepository carReturnRepository)
        {
            _carReturnRepository = carReturnRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CarReturn(CreateCarReturnDto createCarReturnDto)
        {
            _carReturnRepository.CreateCarReturn(createCarReturnDto);
            return Ok("Araç dönüşü başarılı bir şekilde yapıldı");
        }
    }
}
