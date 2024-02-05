using System.Collections.Generic;
using System.Threading.Tasks;
using FiloKiralama_Api.Dtos.CarDtos;

namespace FiloKiralama_Api.Repositories
{
    public interface ICarRepository
    {
        Task<List<ResultCarDto>> GetAllCarAsync();
        void CreateCar(CreateCarDto createCarDto);
        void DeleteCar(int id);
        void UpdateCar(UpdateCarDto updateCarDto);

        Task<GetByIDCarDto> GetCar(int id);

    }
}
