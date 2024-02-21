using FiloKiralama_Api.Dtos.FleetRentCustomersDtos;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace FiloKiralama_Api.Repositories.FleetRentCustomersRepository
{
    public interface IFleetRentCustomersRepository
    {
        void CreateFleetCustomer(CreateFleetRentCustomersDto createFleetRentCustomersDto);
        Task<List<ResultFleetRentCustomersDto>> GetAllFleetCustomers();
        Task<ResultFleetRentCustomersDto> GetFleetCustomer(string id);
    }
}
