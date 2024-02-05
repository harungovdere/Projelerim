using FiloKiralama_Api.Dtos.ModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.ModelsRepository
{
    public interface IModelRepository
    {
        Task<List<ResultModelDto>> GetAllModelAsync();
        Task<List<GetByIDModelDto>> GetModel(int id);
        //Task<List<GetByIDModelDto>> ModelListe(int MarkaKodu);
    }
}
