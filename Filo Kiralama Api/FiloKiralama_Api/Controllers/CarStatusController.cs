using FiloKiralama_Api.Dtos.CarStatusDtos;
using FiloKiralama_Api.Repositories.CarStatusRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStatusController : Controller
    {
        private readonly ICarStatusRepository _carStatusRepository;

        public CarStatusController(ICarStatusRepository carStatusRepository)
        {
            _carStatusRepository = carStatusRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StatusList(int id)
        {
            var values = await _carStatusRepository.StatusList(id);
                return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus(UpdateStatusDto updateStatusDto)
        {
            _carStatusRepository.UpdateStatus(updateStatusDto);
            return Ok("Durum başarılı bir şekilde güncellendi");
        }

    }
}
