using FiloKiralama_Api.Dtos.RentalCarReservedDtos;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.RentalCarReservedRepository
{
    public interface IRentalCarReservedRepository
    {
        void CreateRentalCarReserved(CreateRentalCarReservedDto createRentalCarReservedDto);
        Task<ResultRentalCarReservedDto> GetRentalCarReserved(int id);
        Task<List<ResultRentalCarReservedDto>> RentalCarReservedList();
        void UpdateRentalCarReserved(UpdateRentalCarReservedDto updateRentalCarReservedDto);
    }
}
