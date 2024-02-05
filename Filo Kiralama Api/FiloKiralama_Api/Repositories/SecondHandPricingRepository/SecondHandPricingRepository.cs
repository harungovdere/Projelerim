using Dapper;
using FiloKiralama_Api.Dtos.SecondHandPricingDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.SecondHandPricingRepository
{
    public class SecondHandPricingRepository:ISecondHandPricingRepository
    {
        private readonly Context _context;

        public SecondHandPricingRepository(Context context)
        {
            _context = context;

        }

        public async Task<List<ResultSecondHandPricingDto>> GetAllSecondHandPricing()
        {
            string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi,D.Durum,I.Fiyat FROM  ARACLAR A  LEFT OUTER JOIN IKINCIEL_FIYATLAR I ON A.AracID=I.AracID INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu  INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum WHERE D.DurumID=5 ORDER BY A.Plaka";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSecondHandPricingDto>(query);
                return values.ToList();
            }
        }

        public async void CreateSecondHandPricing(CreateSecondHandPricingDto createSecondHandPricing)
        {

            string query = "INSERT INTO IKINCIEL_FIYATLAR (AracID,Fiyat) VALUES (@AracID,@Fiyat)";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", createSecondHandPricing.AracID);
            parameters.Add("@Fiyat", createSecondHandPricing.Fiyat);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateSecondHandPricing(UpdateSecondHandPricingDto updateSecondHandPricing)
        {
            string query = "UPDATE IKINCIEL_FIYATLAR SET Fiyat=@Fiyat WHERE AracID=@AracID";
            var parameters = new DynamicParameters();

            parameters.Add("@AracID", updateSecondHandPricing.AracID);
            parameters.Add("@Fiyat", updateSecondHandPricing.Fiyat);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteSecondHandPricing(int id)
        {
            string query = "DELETE FROM IKINCIEL_FIYATLAR WHERE AracID=@AracID";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultSecondHandPricingDto> GetSecondHandPricing(int id)
        {
            string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi,D.Durum,I.Fiyat FROM  IKINCIEL_FIYATLAR I INNER JOIN ARACLAR A ON A.AracID=I.AracID INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum WHERE I.AracID=@AracID";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultSecondHandPricingDto>(query, parameters);
                return values;
            }
        }
    }
}
