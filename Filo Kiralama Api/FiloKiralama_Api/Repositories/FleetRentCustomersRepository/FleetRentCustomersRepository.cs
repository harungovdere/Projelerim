using Dapper;
using FiloKiralama_Api.Dtos.FleetRentCustomersDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.FleetRentCustomersRepository
{
    public class FleetRentCustomersRepository:IFleetRentCustomersRepository
    {
        private readonly Context _context;
        public FleetRentCustomersRepository(Context context)
        {
            _context = context;
        }

        public async void CreateFleetCustomer(CreateFleetRentCustomersDto createFleetRentCustomersDto)
        {
            string query = "INSERT INTO FILO_MUSTERILER (MusteriTipi,FirmaUnvani,VergiDairesi,VergiNoKimlikNo,EPosta,Telefon) VALUES (@MusteriTipi,@FirmaUnvani,@VergiDairesi,@VergiNoKimlikNo,@EPosta,@Telefon)";
            var parameters = new DynamicParameters();
            //parameters.Add("@FiloTalepTarihi", createFleetRentCustomersDto.FiloTalepTarihi);
            parameters.Add("@MusteriTipi", createFleetRentCustomersDto.MusteriTipi);
            parameters.Add("@FirmaUnvani", createFleetRentCustomersDto.FirmaUnvani);
            parameters.Add("@VergiDairesi", createFleetRentCustomersDto.VergiDairesi);
            parameters.Add("@VergiNoKimlikNo", createFleetRentCustomersDto.VergiNoKimlikNo);
            parameters.Add("@EPosta", createFleetRentCustomersDto.EPosta);
            parameters.Add("@Telefon", createFleetRentCustomersDto.Telefon);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultFleetRentCustomersDto>> GetAllFleetCustomers()
        {
            string query = "SELECT * FROM FILO_MUSTERILER";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultFleetRentCustomersDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultFleetRentCustomersDto> GetFleetCustomer(int id)
        {
            string query = "SELECT * FROM FILO_MUSTERILER  WHERE VergiNoKimlikNo=@VergiNoKimlikNo";
            var parameters = new DynamicParameters();
            parameters.Add("@VergiNoKimlikNo", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultFleetRentCustomersDto>(query, parameters);
                return values;
            }
        }
    }
}
