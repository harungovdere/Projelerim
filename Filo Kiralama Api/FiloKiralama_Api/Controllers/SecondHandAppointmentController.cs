using FiloKiralama_Api.Dtos.SecondHandAppointmentDtos;
using FiloKiralama_Api.Repositories.SecondHandAppointmentRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondHandAppointmentController : ControllerBase
    {
        private readonly ISecondHandAppointmentRepository _repository;
        public SecondHandAppointmentController(ISecondHandAppointmentRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> SecondHandAppointmentList()
        {
            var values = await _repository.GetAllSecondHandAppointment();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSecondHandAppointment(CreateSecondHandAppointmentDto createSecondHandAppointmentDto)
        {
            _repository.CreateSecondHandAppointment(createSecondHandAppointmentDto);
            return Ok("İkinci el randevu başarılı bir şekilde yapıldı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSecondHandAppointment(UpdateSecondHandAppointmentDto updateSecondHandAppointmentDto)
        {
            _repository.UpdateSecondHandAppointment(updateSecondHandAppointmentDto);
            return Ok("İkinci el randevu başarılı bir şekilde güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecondHandAppointment(int id)
        {
            _repository.DeleteSecondHandAppointment(id);
            return Ok("İkinci el randevu başarılı bir şekilde silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecondHandAppointment(int id)
        {
            var value = await _repository.GetSecondHandAppointment(id);
            return Ok(value);
        }
    }
}
