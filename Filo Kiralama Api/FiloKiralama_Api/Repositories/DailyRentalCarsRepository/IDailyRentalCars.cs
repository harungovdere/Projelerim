using FiloKiralama_Api.Dtos.DailyRentalCarsDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.DailyRentalCarsRepository
{
    public interface IDailyRentalCars
    {
        void CreateDailyRental(CreateDailyRentalCarsDto createDailyRentalCarsDto);
        Task<List<ResultDailyRentalCarsDto>> GetAllDailyRentalCars();
    }
}
