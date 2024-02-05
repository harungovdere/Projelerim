using FiloKiralama_Api.Dtos.FleetRentalRequestDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace FiloKiralama_Api.Repositories.FleetRentalRequestRepository
{
    public interface IFleetRentalRequestRepository
    {
        void CreateFleetRentalRequest(CreateFleetRentalRequestDto createFleetRentalRequestDto);

        Task<List<ResultFleetRentalRequestDto>> GetAllFleetRentalRequest();
        Task<ResultFleetRentalRequestDto> GetFleetRentalRequest(int id);
    }
}
