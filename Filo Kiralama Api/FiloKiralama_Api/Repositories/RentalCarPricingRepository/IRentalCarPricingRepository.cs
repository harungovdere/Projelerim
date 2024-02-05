using FiloKiralama_Api.Dtos.RentalCarPricingDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.RentalCarPricingRepository
{
    public interface IRentalCarPricingRepository
    {
        void CreateRentalCarPricing(CreateRentalCarPricingDto createRentalCarPricingDto);
        void UpdateRentalCarPricing(UpdateRentalCarPricingDto updateRentalCarPricingDto);
        Task<List<ResultRentalCarPricingDto>> GetAllRentalCarPricing();
        void DeleteRentalCarPricing(int id);
        Task<ResultRentalCarPricingDto> GetRentalCarPricing(int id);
    }
}
