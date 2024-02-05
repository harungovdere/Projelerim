using Dapper;
using FiloKiralama_Api.Dtos.RentalCarPricingDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.RentalCarPricingRepository
{
    public class RentalCarPricingRepository:IRentalCarPricingRepository
    {
        private readonly Context _context;

        public RentalCarPricingRepository(Context context)
        {
            _context = context;

        }

        public async Task<List<ResultRentalCarPricingDto>> GetAllRentalCarPricing()
        {
            string query = "SELECT DISTINCT N.ModelTipID,G.GunlukKiraFiyat,N.TipAdi,N.TipKodu,M.MarkaAdi,M.MarkaKodu,A.Sanziman,A.YakitTipi FROM ARACLAR A INNER JOIN MARKALAR M ON M.MarkaKodu=A.MarkaKodu INNER JOIN MODELLER N ON N.MarkaKodu=A.MarkaKodu AND N.TipKodu=A.TipKodu LEFT OUTER JOIN GUNLUK_KIRA_FIYATLAR G ON G.ModelTipID=N.ModelTipID WHERE A.Durum=4";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultRentalCarPricingDto>(query);
                return values.ToList();
            }
        }

        public async void CreateRentalCarPricing(CreateRentalCarPricingDto createRentalCarPricingDto)
        {

            string query = "INSERT INTO GUNLUK_KIRA_FIYATLAR (ModelTipID,GunlukKiraFiyat) VALUES (@ModelTipID,@GunlukKiraFiyat)";
            var parameters = new DynamicParameters();
            parameters.Add("@ModelTipID", createRentalCarPricingDto.ModelTipID);
            parameters.Add("@GunlukKiraFiyat", createRentalCarPricingDto.GunlukKiraFiyat);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateRentalCarPricing(UpdateRentalCarPricingDto updateRentalCarPricingDto)
        {
            string query = "UPDATE GUNLUK_KIRA_FIYATLAR SET GunlukKiraFiyat=@GunlukKiraFiyat WHERE ModelTipID=@ModelTipID";
            var parameters = new DynamicParameters();

            parameters.Add("@ModelTipID", updateRentalCarPricingDto.ModelTipID);
            parameters.Add("@GunlukKiraFiyat", updateRentalCarPricingDto.GunlukKiraFiyat);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteRentalCarPricing(int id)
        {
            string query = "DELETE FROM GUNLUK_KIRA_FIYATLAR WHERE ModelTipID=@ModelTipID";
            var parameters = new DynamicParameters();
            parameters.Add("@ModelTipID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultRentalCarPricingDto> GetRentalCarPricing(int id)
        {
            string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi,D.Durum,G.GunlukKiraFiyat FROM ARACLAR A  INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum LEFT OUTER JOIN GUNLUK_KIRA_FIYATLAR G ON N.ModelTipID=G.ModelTipID WHERE D.DurumID=4 AND G.ModelTipID=@ModelTipID";
            var parameters = new DynamicParameters();
            parameters.Add("@ModelTipID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultRentalCarPricingDto>(query, parameters);
                return values;
            }
        }
    }
}
