using Dapper;
using FiloKiralama_Api.Dtos.SoldCarsDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.SoldCarsRepository
{
    public class SoldCarsRepository:ISoldCarsRepository
    {
        private readonly Context _context;

        public SoldCarsRepository(Context context)
        {
            _context = context;

        }
        public async Task<List<ResultSoldCarsDto>> SoldCarsList()
        {
            string query = "SELECT S.SatisID,A.AracID,A.Plaka,M.MarkaAdi,N.TipAdi,A.ModelYili,K.Ad,K.Soyad,D.Durum,F.Fiyat,S.SatisTarihi FROM  ARACLAR A  LEFT OUTER JOIN IKINCIEL_FIYATLAR F ON A.AracID=F.AracID INNER JOIN IKINCIEL_SATIS S ON S.AracID=A.AracID INNER JOIN KULLANICILAR K ON K.KullaniciID=S.KullaniciID INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu  INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum WHERE D.DurumID=7 ORDER BY S.SatisID DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSoldCarsDto>(query);
                return values.ToList();
            }
        }
    }
}
