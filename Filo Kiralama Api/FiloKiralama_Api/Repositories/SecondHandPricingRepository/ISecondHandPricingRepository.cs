using FiloKiralama_Api.Dtos.SecondHandPricingDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.SecondHandPricingRepository
{
    public interface ISecondHandPricingRepository
    {
        void CreateSecondHandPricing(CreateSecondHandPricingDto createSecondHandPricing);
        void UpdateSecondHandPricing(UpdateSecondHandPricingDto updateSecondHandPricing);
        Task<List<ResultSecondHandPricingDto>> GetAllSecondHandPricing();
        void DeleteSecondHandPricing(int id);
        Task<ResultSecondHandPricingDto> GetSecondHandPricing(int id);
    }
}
