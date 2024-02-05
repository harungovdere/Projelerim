using Dapper;
using FiloKiralama_Api.Dtos.FleetRentalDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.FleetRentalRepository
{
    public class FleetRentalRepository:IFleetRentalRepository
    {
        private readonly Context _context;

        public FleetRentalRepository(Context context)
        {
            _context = context;

        }

        public async void CreateFleetRental(CreateFleetRentalDto createFleetRentalDto)
        {

            string query = "INSERT INTO FILO_KIRALANAN_ARACLAR (TeklifID,KiraBaslangicTarihi,KiraBitisTarihi,AracID) VALUES (@TeklifID,@KiraBaslangicTarihi,@KiraBitisTarihi,@AracID)";
            var parameters = new DynamicParameters();
            parameters.Add("@TeklifID", createFleetRentalDto.TeklifID);
            parameters.Add("@AracID", createFleetRentalDto.AracID);
            parameters.Add("@KiraBaslangicTarihi", createFleetRentalDto.KiraBaslangicTarihi);
            parameters.Add("@KiraBitisTarihi", createFleetRentalDto.KiraBitisTarihi);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task<List<ResultFleetRentalDto>> GetAllFleetRental()
        {
            string query = "SELECT B.FiloID,S.FirmaUnvani,A.Plaka,M.MarkaAdi,N.TipAdi,B.KiraBaslangicTarihi,B.KiraBitisTarihi,K.AylikKiraFiyati,K.YillikKiraFiyati,T.KiralamaSuresi,T.YillikKM FROM FILO_KIRALANAN_ARACLAR B INNER JOIN FILO_KIRALAMA_TEKLIFLER K ON K.TeklifID=B.TeklifID INNER JOIN FILO_KIRALAMA_TALEPLERI T ON T.FiloTalepID=K.TalepID INNER JOIN FILO_MUSTERILER S ON S.FiloMusteriID=t.MusteriID INNER JOIN MARKALAR M ON M.MarkaKodu=T.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=T.TipKodu AND M.MarkaKodu=N.MarkaKodu INNER JOIN ARACLAR A ON A.AracID=B.AracID WHERE A.Durum=1 ORDER BY B.FiloID DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultFleetRentalDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultFleetRentalDto> GetFleetRental(int id)
        {
            string query = "SELECT B.FiloID AS FiloID,S.FirmaUnvani AS FirmaUnvani,A.Plaka AS Plaka,B.KiraBaslangicTarihi AS KiraBaslangicTarihi,B.KiraBitisTarihi AS KiraBitisTarihi,K.AylikKiraFiyati AS AylikKiraFiyati,K.YillikKiraFiyati AS YillikKiraFiyati,T.KiralamaSuresi AS KiralamaSuresi,T.YillikKM AS YillikKM FROM FILO_KIRALANAN_ARACLAR B INNER JOIN FILO_KIRALAMA_TEKLIFLER K ON K.TeklifID=B.TeklifID INNER JOIN FILO_KIRALAMA_TALEPLERI T ON T.FiloTalepID=K.TalepID INNER JOIN FILO_MUSTERILER S ON S.FiloMusteriID=T.MusteriID INNER JOIN MARKALAR M ON M.MarkaKodu=T.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=T.TipKodu AND M.MarkaKodu=N.MarkaKodu INNER JOIN ARACLAR A ON A.AracID=B.AracID WHERE B.FiloID=@FiloID ORDER BY B.FiloID DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@FiloID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultFleetRentalDto>(query, parameters);
                return values;
            }
        }
    }
}
