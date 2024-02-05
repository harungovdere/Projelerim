using FiloKiralama_Api.Dtos.SecondHandSalesDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.SecondHandSalesRepository
{
    public interface ISecondHandSalesRepository
    {
        void CreateSecondHandSales(CreateSecondHandSalesDto createSecondHandSalesDto);
        Task<ResultSecondHandSalesDto> GetSecondHandSales(int id);
        Task<List<ResultSecondHandSalesDto>> GetAllSecondHandSales();
        

    }
}
