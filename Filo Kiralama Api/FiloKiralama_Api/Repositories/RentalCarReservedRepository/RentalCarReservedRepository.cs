using Dapper;
using FiloKiralama_Api.Dtos.RentalCarReservedDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.RentalCarReservedRepository
{
    public class RentalCarReservedRepository:IRentalCarReservedRepository
    {
        private readonly Context _context;
        public RentalCarReservedRepository(Context context)
        {
            _context = context;
        }
        public async void CreateRentalCarReserved(CreateRentalCarReservedDto createRentalCarReservedDto)
        {
            string query = "INSERT INTO KIRALIK_ARAC_REZERVE (TipID,KullaniciID,TeslimAlmaKonumu,TeslimEtmeKonumu,TeslimAlmaTarihi,TeslimEtmeTarihi,TeslimAlmaSaati,TeslimEtmeSaati,GunlukKira,ToplamGunSayisi,ToplamTutar) VALUES (@TipID,@KullaniciID,@TeslimAlmaKonumu,@TeslimEtmeKonumu,@TeslimAlmaTarihi,@TeslimEtmeTarihi,@TeslimAlmaSaati,@TeslimEtmeSaati,@GunlukKira,@ToplamGunSayisi,@ToplamTutar)";
            var parameters = new DynamicParameters();

            parameters.Add("@TipID", createRentalCarReservedDto.TipID);
            parameters.Add("@KullaniciID", createRentalCarReservedDto.KullaniciID);
            parameters.Add("@TeslimAlmaKonumu", createRentalCarReservedDto.TeslimAlmaKonumu);
            parameters.Add("@TeslimEtmeKonumu", createRentalCarReservedDto.TeslimEtmeKonumu);
            parameters.Add("@TeslimAlmaTarihi", createRentalCarReservedDto.TeslimAlmaTarihi);
            parameters.Add("@TeslimEtmeTarihi", createRentalCarReservedDto.TeslimEtmeTarihi);
            parameters.Add("@TeslimAlmaSaati", createRentalCarReservedDto.TeslimAlmaSaati);
            parameters.Add("@TeslimEtmeSaati", createRentalCarReservedDto.TeslimEtmeSaati);
            parameters.Add("@GunlukKira", createRentalCarReservedDto.GunlukKira);
            parameters.Add("@ToplamGunSayisi", createRentalCarReservedDto.ToplamGunSayisi);
            parameters.Add("@ToplamTutar", createRentalCarReservedDto.ToplamTutar);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
        public async void UpdateRentalCarReserved(UpdateRentalCarReservedDto updateRentalCarReservedDto)
        {
            string query = "UPDATE KIRALIK_ARAC_REZERVE SET TipID=@TipID,KullaniciID=@KullaniciID,TeslimAlmaKonumu=@TeslimAlmaKonumu,TeslimEtmeKonumu=@TeslimEtmeKonumu,TeslimAlmaTarihi=@TeslimAlmaTarihi,TeslimEtmeTarihi=@TeslimEtmeTarihi,TeslimAlmaSaati=@TeslimAlmaSaati,TeslimEtmeSaati=@TeslimEtmeSaati,GunlukKira=@GunlukKira,ToplamGunSayisi=@ToplamGunSayisi,ToplamTutar=@ToplamTutar WHERE RezerveID=@RezerveID";
            var parameters = new DynamicParameters();

            parameters.Add("@RezerveID", updateRentalCarReservedDto.RezerveID);
            parameters.Add("@TipID", updateRentalCarReservedDto.TipID);
            parameters.Add("@KullaniciID", updateRentalCarReservedDto.KullaniciID);
            parameters.Add("@TeslimAlmaKonumu", updateRentalCarReservedDto.TeslimAlmaKonumu);
            parameters.Add("@TeslimEtmeKonumu", updateRentalCarReservedDto.TeslimEtmeKonumu);
            parameters.Add("@TeslimAlmaTarihi", updateRentalCarReservedDto.TeslimAlmaTarihi);
            parameters.Add("@TeslimEtmeTarihi", updateRentalCarReservedDto.TeslimEtmeTarihi);
            parameters.Add("@TeslimAlmaSaati", updateRentalCarReservedDto.TeslimAlmaSaati);
            parameters.Add("@TeslimEtmeSaati", updateRentalCarReservedDto.TeslimEtmeSaati);
            parameters.Add("@GunlukKira", updateRentalCarReservedDto.GunlukKira);
            parameters.Add("@ToplamGunSayisi", updateRentalCarReservedDto.ToplamGunSayisi);
            parameters.Add("@ToplamTutar", updateRentalCarReservedDto.ToplamTutar);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultRentalCarReservedDto>> RentalCarReservedList()
        {
            string query = "SELECT DISTINCT K.*,L.Ad,L.Soyad,L.CepTel,L.Email,M.MarkaAdi,N.TipAdi,G.RezerveID,CASE WHEN K.Durum=1 THEN 'AKTİF' ELSE 'İPTAL' END AS Durum FROM KIRALIK_ARAC_REZERVE K INNER JOIN MODELLER N ON K.TipID=N.ModelTipID INNER JOIN MARKALAR M ON N.MarkaID=M.MarkaID INNER JOIN KULLANICILAR L ON K.KullaniciID=L.KullaniciID LEFT OUTER JOIN GUNLUK_KIRALANAN_ARACLAR G ON K.RezerveID=G.RezerveID WHERE (G.RezerveID IS NULL OR G.RezerveID='') AND K.TeslimAlmaTarihi >= CONVERT(VARCHAR,GETDATE(),23)";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultRentalCarReservedDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultRentalCarReservedDto> GetRentalCarReserved(int id)
        {
            string query = "SELECT K.*,L.Ad,L.Soyad,L.CepTel,L.Email,M.MarkaAdi,N.TipAdi FROM KIRALIK_ARAC_REZERVE K INNER JOIN MODELLER N ON K.TipID=N.ModelTipID INNER JOIN MARKALAR M ON N.MarkaID=M.MarkaID INNER JOIN KULLANICILAR L ON K.KullaniciID=L.KullaniciID  WHERE RezerveID=@RezerveID";
            var parameters = new DynamicParameters();
            parameters.Add("@RezerveID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultRentalCarReservedDto>(query, parameters);
                return values;
            }
        }


    }
}
