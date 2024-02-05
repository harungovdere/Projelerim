using FiloKiralama_Api.Dtos.BrandsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.BrandsRepository
{
    public interface IBrandRepository
    {
        Task<List<ResultBrandDto>> GetAllBrandsAsync();

    }
}
