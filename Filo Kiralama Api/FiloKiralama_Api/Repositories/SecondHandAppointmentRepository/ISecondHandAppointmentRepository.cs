using FiloKiralama_Api.Dtos.SecondHandAppointmentDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace FiloKiralama_Api.Repositories.SecondHandAppointmentRepository
{
    public interface ISecondHandAppointmentRepository
    {
        void CreateSecondHandAppointment(CreateSecondHandAppointmentDto createSecondHandAppointmentDto);
        Task<List<ResultSecondHandAppointmentDto>> GetAllSecondHandAppointment();
        void UpdateSecondHandAppointment(UpdateSecondHandAppointmentDto updateSecondHandAppointmentDto);
        Task<ResultSecondHandAppointmentDto> GetSecondHandAppointment(int id);
        void DeleteSecondHandAppointment(int id);
    }
}
