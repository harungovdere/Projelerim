using Dapper;
using FiloKiralama_Api.Dtos.DailyRentalCarsDtos;
using FiloKiralama_Api.Dtos.MemberTransactionsDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.DailyRentalCarsRepository
{
    public class DailyRentalCarsRepository:IDailyRentalCars
    {
        private readonly Context _context;

        public DailyRentalCarsRepository(Context context)
        {
            _context = context;

        }

        public async void CreateDailyRental(CreateDailyRentalCarsDto createDailyRentalCarsDto)
        {

            string query = "INSERT INTO GUNLUK_KIRALANAN_ARACLAR (AracID,KullaniciID,RezerveID,KiraBaslangicTarihi,KiraBitisTarihi) VALUES (@AracID,@KullaniciID,@RezerveID,@KiraBaslangicTarihi,@KiraBitisTarihi)";
            var parameters = new DynamicParameters();
            parameters.Add("@AracID", createDailyRentalCarsDto.AracID);
            parameters.Add("@KullaniciID", createDailyRentalCarsDto.KullaniciID);
            parameters.Add("@RezerveID", createDailyRentalCarsDto.RezerveID);
            parameters.Add("@KiraBaslangicTarihi", createDailyRentalCarsDto.KiraBaslangicTarihi);
            parameters.Add("@KiraBitisTarihi", createDailyRentalCarsDto.KiraBitisTarihi);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

            string query2 = "UPDATE KIRALIK_ARAC_REZERVE SET Durum=2 WHERE RezerveID=@RezerveID";
            var parameters2 = new DynamicParameters();
            parameters2.Add("@RezerveID", createDailyRentalCarsDto.RezerveID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query2, parameters2);
            }
        }

        public async Task<List<ResultDailyRentalCarsDto>> GetAllDailyRentalCars()
        {
            string query = "SELECT G.ID,CONCAT(K.Ad,' ',K.Soyad) AS Kullanici,A.Plaka,M.MarkaAdi,N.TipAdi,R.ToplamGunSayisi,R.GunlukKira,R.ToplamTutar,G.KiraBaslangicTarihi,G.KiraBitisTarihi FROM GUNLUK_KIRALANAN_ARACLAR G INNER JOIN KIRALIK_ARAC_REZERVE R ON R.RezerveID=G.RezerveID INNER JOIN KULLANICILAR K ON K.KullaniciID=G.KullaniciID INNER JOIN ARACLAR A ON A.AracID=G.AracID INNER JOIN MARKALAR M ON M.MarkaKodu=A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=A.TipKodu AND M.MarkaKodu=N.MarkaKodu WHERE A.Durum=3 ORDER BY G.ID DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDailyRentalCarsDto>(query);
                return values.ToList();
            }
        }
    }
}
