using FiloKiralama_Api.Repositories.ModelsRepository;
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
    public class ModelController : ControllerBase
    {
        private readonly IModelRepository _modelRepository;

        public ModelController(IModelRepository  modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ModelList()
        {

            var values = await _modelRepository.GetAllModelAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModel(int id)
        {
            var value = await _modelRepository.GetModel(id);
            return Ok(value);
        }

        
    }
}
