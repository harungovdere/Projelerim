using FiloKiralama_Api.Dtos.DailyRentalCarsDtos;
using FiloKiralama_Api.Repositories.DailyRentalCarsRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyRentalCarsController : ControllerBase
    {
        private readonly IDailyRentalCars _dailyRentalCars;

        public DailyRentalCarsController(IDailyRentalCars dailyRentalCars)
        {
            _dailyRentalCars = dailyRentalCars;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _dailyRentalCars.GetAllDailyRentalCars();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDailyRental(CreateDailyRentalCarsDto createDailyRentalCarsDto)
        {
            _dailyRentalCars.CreateDailyRental(createDailyRentalCarsDto);
            return Ok("Kiralanan araç başarılı bir şekilde eklendi");
        }
    }
}
