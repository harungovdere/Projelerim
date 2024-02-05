using FiloKiralama_Api.Dtos.SecondHandSalesDtos;
using FiloKiralama_Api.Repositories.SecondHandSalesRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondHandSalesController : ControllerBase
    {
        private readonly ISecondHandSalesRepository _secondHandSalesRepository;
        public SecondHandSalesController(ISecondHandSalesRepository secondHandSalesRepository)
        {
            _secondHandSalesRepository = secondHandSalesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSecondHandSales(CreateSecondHandSalesDto createSecondHandSalesDto)
        {
            _secondHandSalesRepository.CreateSecondHandSales(createSecondHandSalesDto);
            return Ok("Satış başarılı bir şekilde eklendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSecondHandSales(int id)
        {
            var value = await _secondHandSalesRepository.GetSecondHandSales(id);
            return Ok(value);
        }

        [HttpGet]
        public async Task<IActionResult> AllSecondHandSales()
        {
            var values = await _secondHandSalesRepository.GetAllSecondHandSales();
            return Ok(values);
        }
    }
}
