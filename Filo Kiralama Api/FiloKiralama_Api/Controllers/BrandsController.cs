using FiloKiralama_Api.Repositories.BrandsRepository;
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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandsRepository;

        public BrandsController(IBrandRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> BrandsList()
        {
        

        var values = await _brandsRepository.GetAllBrandsAsync();
            return Ok(values);
        }
    }
}
