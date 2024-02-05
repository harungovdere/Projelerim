using Dapper;
using FiloKiralama_Api.Dtos.CarReturnDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.CarReturnRepository
{
    public class CarReturnRepository:ICarReturnRepository
    {
        private readonly Context _context;

        public CarReturnRepository(Context context)
        {
            _context = context;

        }

        public async void CreateCarReturn(CreateCarReturnDto createCarReturnDto)
        {

            string query = "INSERT INTO ARAC_DONUSLERI (AracID,KM,DonusTarihi) VALUES (@AracID,@KM,@DonusTarihi)";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", createCarReturnDto.AracID);
            parameters.Add("@KM", createCarReturnDto.KM);
            parameters.Add("@DonusTarihi", createCarReturnDto.DonusTarihi);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        } 
    }
}
