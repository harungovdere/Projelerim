using Dapper;
using FiloKiralama_Api.Dtos.SecondHandSalesDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.SecondHandSalesRepository
{
    public class SecondHandSalesRepository:ISecondHandSalesRepository
    {
        private readonly Context _context;

        public SecondHandSalesRepository(Context context)
        {
            _context = context;

        }

        public async void CreateSecondHandSales(CreateSecondHandSalesDto createSecondHandSalesDto)
        {

            string query = "INSERT INTO IKINCIEL_SATIS (AracID,KullaniciID,SatisTarihi) VALUES (@AracID,@KullaniciID,@SatisTarihi)";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", createSecondHandSalesDto.AracID);
            parameters.Add("@KullaniciID", createSecondHandSalesDto.KullaniciID);
            parameters.Add("@SatisTarihi", createSecondHandSalesDto.SatisTarihi);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultSecondHandSalesDto> GetSecondHandSales(int id)
        {
            string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi,D.Durum,F.Fiyat FROM  IKINCIEL_FIYATLAR F INNER JOIN ARACLAR A ON A.AracID=F.AracID INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum WHERE F.AracID=@AracID";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultSecondHandSalesDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ResultSecondHandSalesDto>> GetAllSecondHandSales()
        {
            string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi,D.Durum,F.Fiyat FROM  ARACLAR A  LEFT OUTER JOIN IKINCIEL_FIYATLAR F ON A.AracID=F.AracID INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu  INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum WHERE D.DurumID=5 ORDER BY A.Plaka";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSecondHandSalesDto>(query);
                return values.ToList();
            }
        }

        
    }
}
