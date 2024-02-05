using Dapper;
using FiloKiralama_Api.Dtos;
using FiloKiralama_Api.Dtos.CarDtos;
using FiloKiralama_Api.Dtos.CarImageDtos;
using FiloKiralama_Api.Models;
using FiloKiralama_Api.Models.DapperContext;
using FiloKiralama_Api.Repositories.CarImageRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private readonly ICarImageRepository _carImageRepository;
        //private readonly IProductRepository _productRepo;
        public CarImageController(ICarImageRepository cp)
        {
            _carImageRepository = cp;
            //this._productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> CarImageList()
        {
            var values = await _carImageRepository.AllCarImage();
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            _carImageRepository.DeleteImage(id);
            return Ok("Resim bilgisi başarılı bir şekilde silindi");
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCarImage(string imageFileName)
        //{
        //    _carImageRepository.DeleteCarImage(imageFileName);
        //    return Ok("Resim Api Uploads klasöründen başarılı bir şekilde silindi");
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateImage(UpdateImageDto updateImageDto)
        {
            _carImageRepository.UpdateImage(updateImageDto);
            return Ok("Resim bilgisi başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarImage(int id)
        {
            var value = await _carImageRepository.GetImage(id);
            return Ok(value);
        }
        [HttpPost]
        //public IActionResult Add([FromForm] CreateImageDto createImageDto)
        public async Task<IActionResult> Add(CreateImageDto createImageDto)
        {
            //var status = new Status();
            //if (!ModelState.IsValid)
            //{
            //    status.StatusCode = 0;
            //    status.Message = "Please pass the valid data";
            //    return Ok(status);
            //}
            /*
            if (createImageDto.File != null)
            {
                var fileResult = _carImageRepository.SaveCarImage(createImageDto.File);
                _carImageRepository.CreateImage(createImageDto);
                
                if (fileResult.Item1 == 1)
                {
                    createImageDto.FileName = fileResult.Item2; // getting name of image
                }*/
                //var productResult = _carImageRepository.Add(createImageDto);
                //if (productResult)
                //{
                //    status.StatusCode = 1;
                //    status.Message = "Added successfully";
                //}
                //else
                //{
                //    status.StatusCode = 0;
                //    status.Message = "Error on adding product";

                //}
            //}
            _carImageRepository.CreateImage(createImageDto);
            return Ok("Resim başarılı bir şekilde eklendi");

        }
    }
}
