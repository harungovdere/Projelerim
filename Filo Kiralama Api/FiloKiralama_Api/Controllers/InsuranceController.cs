using FiloKiralama_Api.Dtos.InsuranceDtos;
using FiloKiralama_Api.Repositories.InsuranceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceController(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> InsuranceList()
        {
            var values = await _insuranceRepository.GetAllInsuranceAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInsurance(CreateInsuranceDto createInsuranceDto)
        {
            _insuranceRepository.CreateInsurance(createInsuranceDto);
            return Ok("Araç başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurance(int id)
        {
            _insuranceRepository.DeleteInsurance(id);
            return Ok("Araç başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInsurance(UpdateInsuranceDto updateInsuranceDto)
        {
            _insuranceRepository.UpdateInsurance(updateInsuranceDto);
            return Ok("Araç başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsurance(int id)
        {
            var value = await _insuranceRepository.GetInsurance(id);
            return Ok(value);
        }
    }
}
