using FiloKiralama_Api.Dtos.InsuranceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.InsuranceRepository
{
    public interface IInsuranceRepository
    {
        Task<List<ResultInsuranceDto>> GetAllInsuranceAsync();
        void CreateInsurance(CreateInsuranceDto createInsuranceDto);
        void DeleteInsurance(int id);
        void UpdateInsurance(UpdateInsuranceDto updateInsuranceDto);

        Task<GetByIDInsuranceDto> GetInsurance(int id);
    }
}
