using FiloKiralama_Api.Dtos.CarDtos;
using FiloKiralama_Api.Repositories;
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
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult>CarList()
        {
            var values = await _carRepository.GetAllCarAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            _carRepository.CreateCar(createCarDto);
            return Ok("Araç başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            _carRepository.DeleteCar(id);
            return Ok("Araç başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            _carRepository.UpdateCar(updateCarDto);
            return Ok("Araç başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _carRepository.GetCar(id);
            return Ok(value);
        }
        
    }
}
