using FiloKiralama_Api.Dtos.FleetRentalDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.FleetRentalRepository
{
    public interface IFleetRentalRepository
    {
        void CreateFleetRental(CreateFleetRentalDto createFleetRentalDto);
        Task<List<ResultFleetRentalDto>> GetAllFleetRental();
        Task<ResultFleetRentalDto> GetFleetRental(int id);
    }
}
