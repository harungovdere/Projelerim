using FiloKiralama_Api.Dtos.ModelYearDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.ModelYearRepository
{
    public interface IModelYearRepository
    {
        Task<List<GetByIDModelYearDto>> GetModelYear(int MarkaID,int TipID);
    }
}
