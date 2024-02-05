using FiloKiralama_Api.Dtos.SoldCarsDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.SoldCarsRepository
{
    public interface ISoldCarsRepository
    {
        Task<List<ResultSoldCarsDto>> SoldCarsList();
    }
}
