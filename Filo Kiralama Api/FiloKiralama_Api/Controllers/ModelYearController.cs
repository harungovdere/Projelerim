using FiloKiralama_Api.Repositories;
using FiloKiralama_Api.Repositories.ModelYearRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelYearController : Controller
    {
        private readonly IModelYearRepository _modelYearRepository;

        public ModelYearController(IModelYearRepository modelYearRepository)
        {
            _modelYearRepository = modelYearRepository;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetModelYear(int MarkaID,int TipID)
        {
            var value = await _modelYearRepository.GetModelYear(MarkaID,TipID);
            return Ok(value);
        }
    }
}
