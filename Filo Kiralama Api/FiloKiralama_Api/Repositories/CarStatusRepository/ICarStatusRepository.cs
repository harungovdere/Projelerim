using FiloKiralama_Api.Dtos.CarDtos;
using FiloKiralama_Api.Dtos.CarStatusDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.CarStatusRepository
{
    public interface ICarStatusRepository
    {
        //Task<List<ResultCarDto>> SecondHandCarsList();
        //Task<List<ResultCarDto>> RentCarsList();
        void UpdateStatus(UpdateStatusDto updateStatusDto);
        Task<List<ResultTransactionsDto>> StatusList(int id);

    }
}
