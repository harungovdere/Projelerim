using FiloKiralama_Api.Dtos.FleetRentalRequestDtos;
using FiloKiralama_Api.Models.DapperContext;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiloKiralama_Api.Dtos.CarDtos;
namespace FiloKiralama_Api.Repositories.FleetRentalRequestRepository
{
    public class FleetRentalRequestRepository : IFleetRentalRequestRepository
    {
        private readonly Context _context;
        public FleetRentalRequestRepository(Context context) 
        {
            _context = context;
        }

        public async void CreateFleetRentalRequest(CreateFleetRentalRequestDto createFleetRentalRequestDto)
        {
            string query = "INSERT INTO FILO_KIRALAMA_TALEPLERI (MusteriID,MarkaKodu,TipKodu,YillikKM,KiralamaSuresi,MevcutAracAdedi,TalepEdilenAracAdedi) VALUES (@MusteriID,@MarkaKodu,@TipKodu,@YillikKM,@KiralamaSuresi,@MevcutAracAdedi,@TalepEdilenAracAdedi)";
            var parameters = new DynamicParameters();
            
            parameters.Add("@MusteriID", createFleetRentalRequestDto.MusteriID);
            parameters.Add("@MarkaKodu", createFleetRentalRequestDto.MarkaKodu);
            parameters.Add("@TipKodu", createFleetRentalRequestDto.TipKodu);
            parameters.Add("@YillikKM", createFleetRentalRequestDto.YillikKM);
            parameters.Add("@KiralamaSuresi", createFleetRentalRequestDto.KiralamaSuresi);
            parameters.Add("@MevcutAracAdedi", createFleetRentalRequestDto.MevcutAracAdedi);
            parameters.Add("@TalepEdilenAracAdedi", createFleetRentalRequestDto.TalepEdilenAracAdedi);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultFleetRentalRequestDto>> GetAllFleetRentalRequest()
        {
            string query = "SELECT T.*,F.*,M.*,N.*,K.TeklifID FROM FILO_KIRALAMA_TALEPLERI T INNER JOIN FILO_MUSTERILER F ON F.FiloMusteriID=T.MusteriID INNER JOIN MARKALAR M ON M.MarkaKodu=T.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=T.TipKodu AND M.MarkaKodu=N.MarkaKodu LEFT OUTER JOIN FILO_KIRALAMA_TEKLIFLER K ON T.FiloTalepID=K.TalepID WHERE K.TeklifID IS NULL ORDER BY T.FiloTalepID DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultFleetRentalRequestDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultFleetRentalRequestDto> GetFleetRentalRequest(int id)
        {
            string query = "SELECT T.*,F.*,M.*,N.*,K.TeklifID FROM FILO_KIRALAMA_TALEPLERI T INNER JOIN FILO_MUSTERILER F ON F.FiloMusteriID=T.MusteriID INNER JOIN MARKALAR M ON M.MarkaKodu=T.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=T.TipKodu AND M.MarkaKodu=N.MarkaKodu LEFT OUTER JOIN FILO_KIRALAMA_TEKLIFLER K ON T.FiloTalepID=K.TalepID WHERE K.TeklifID IS NULL AND T.FiloTalepID=@FiloTalepID ORDER BY T.FiloTalepID DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@FiloTalepID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultFleetRentalRequestDto>(query, parameters);
                return values;
            }
        }
    }
}
