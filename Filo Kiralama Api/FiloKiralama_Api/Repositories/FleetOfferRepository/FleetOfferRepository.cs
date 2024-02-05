using Dapper;
using FiloKiralama_Api.Dtos.FleetOffer;
using FiloKiralama_Api.Dtos.FleetOfferDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.FleetOffer
{
    public class FleetOfferRepository:IFleetOfferRepository
    {
        private readonly Context _context;

        public FleetOfferRepository(Context context)
        {
            _context = context;

        }

        public async void CreateOffer(CreateSendAnOfferDto createSendAnOfferDto)
        {

            string query = "INSERT INTO FILO_KIRALAMA_TEKLIFLER (TalepID,AylikKiraFiyati,YillikKiraFiyati) VALUES (@TalepID,@AylikKiraFiyati,@YillikKiraFiyati)";
            var parameters = new DynamicParameters();
            parameters.Add("@TalepID", createSendAnOfferDto.FiloTalepID);
            parameters.Add("@AylikKiraFiyati", createSendAnOfferDto.AylikKiraFiyati);
            parameters.Add("@YillikKiraFiyati", createSendAnOfferDto.YillikKiraFiyati);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultFleetOfferDto>> GetAllOffer()
        {
            string query = "SELECT K.*,T.*,F.FirmaUnvani,M.MarkaAdi,N.TipAdi FROM FILO_KIRALAMA_TEKLIFLER K INNER JOIN FILO_KIRALAMA_TALEPLERI T ON T.FiloTalepID=K.TalepID INNER JOIN FILO_MUSTERILER F ON F.FiloMusteriID=T.MusteriID INNER JOIN MARKALAR M ON M.MarkaKodu=T.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=T.TipKodu AND M.MarkaKodu=N.MarkaKodu LEFT OUTER JOIN FILO_KIRALANAN_ARACLAR B ON B.TeklifID=K.TeklifID WHERE B.FiloID IS NULL ORDER BY K.TeklifID DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultFleetOfferDto>(query);
                return values.ToList();
            }
        }

        public async Task<ResultFleetOfferDto> GetFleetOffer(int id)
        {
            string query = "SELECT K.*,T.*,F.FirmaUnvani,M.MarkaAdi,N.TipAdi FROM FILO_KIRALAMA_TEKLIFLER K INNER JOIN FILO_KIRALAMA_TALEPLERI T ON T.FiloTalepID=K.TalepID INNER JOIN FILO_MUSTERILER F ON F.FiloMusteriID=T.MusteriID INNER JOIN MARKALAR M ON M.MarkaKodu=T.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=T.TipKodu AND M.MarkaKodu=N.MarkaKodu WHERE K.TeklifID=@TeklifID ORDER BY K.TeklifID DESC";
            var parameters = new DynamicParameters();
            parameters.Add("@TeklifID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultFleetOfferDto>(query, parameters);
                return values;
            }
        }
    }
}
