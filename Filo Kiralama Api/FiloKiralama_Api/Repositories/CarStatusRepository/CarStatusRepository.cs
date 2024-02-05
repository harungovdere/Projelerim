using Dapper;
using FiloKiralama_Api.Dtos.CarStatusDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.CarStatusRepository
{
    public class CarStatusRepository : ICarStatusRepository
    {
        private readonly Context _context;

        public CarStatusRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultTransactionsDto>> StatusList(int id)
        {
            if (id == 1)
            {
                string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,F.KiraBaslangicTarihi,F.KiraBitisTarihi,D.Durum,D.DurumID FROM ARACLAR A INNER JOIN MARKALAR M ON M.MarkaKodu=A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=A.TipKodu AND M.MarkaKodu=N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum INNER JOIN FILO_KIRALANAN_ARACLAR F ON F.AracID=A.AracID WHERE A.Durum=1 UNION ALL SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,G.KiraBaslangicTarihi,G.KiraBitisTarihi,D.Durum,D.DurumID FROM ARACLAR A INNER JOIN MARKALAR M ON M.MarkaKodu=A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=A.TipKodu AND M.MarkaKodu=N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum INNER JOIN GUNLUK_KIRALANAN_ARACLAR G ON G.AracID=A.AracID WHERE A.Durum=3 ORDER BY KiraBitisTarihi";

                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultTransactionsDto>(query);
                    return values.ToList();

                }
            }
            else if(id==2)
            {
                string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.KM,D.Durum,D.DurumID,H.DonusTarihi FROM ARACLAR A INNER JOIN MARKALAR M ON M.MarkaKodu=A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=A.TipKodu AND M.MarkaKodu=N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum INNER JOIN ARAC_DONUSLERI H ON A.AracID=H.AracID WHERE A.Durum=9";

                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultTransactionsDto>(query);
                    return values.ToList();

                }
            }
            else if (id == 5)
            {
                string query = "SELECT A.AracID,A.Plaka,A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,A.ModelYili,A.KM,A.Renk,A.Sanziman,A.YakitTipi,D.Durum,R.DosyaAdi,I.Fiyat FROM  ARACLAR A INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum LEFT OUTER JOIN MODELLER_RESIM R ON R.MarkaKodu=A.MarkaKodu AND R.TipKodu=A.TipKodu LEFT OUTER JOIN IKINCIEL_FIYATLAR I ON A.AracID=I.AracID  WHERE A.DURUM=5 AND (I.Fiyat!='' AND I.Fiyat IS NOT NULL) ORDER BY TipAdi";

                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultTransactionsDto>(query);
                    return values.ToList();

                }
            }
            else
            {
                string query = "SELECT DISTINCT A.MarkaKodu,M.MarkaAdi,A.TipKodu,N.TipAdi,N.ModelTipID,A.ModelYili,A.Sanziman,A.YakitTipi,D.Durum,R.DosyaAdi,G.GunlukKiraFiyat FROM ARACLAR A  INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum LEFT OUTER JOIN MODELLER_RESIM R ON R.MarkaKodu=A.MarkaKodu AND R.TipKodu=A.TipKodu LEFT OUTER JOIN GUNLUK_KIRA_FIYATLAR G ON N.ModelTipID=G.ModelTipID WHERE D.DurumID=4 AND G.GunlukKiraFiyat IS NOT NULL ORDER BY M.MarkaAdi";
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultTransactionsDto>(query);
                    return values.ToList();
                }
            }

        }


        public async void UpdateStatus(UpdateStatusDto updateStatusDto)
        {
            string query = "UPDATE ARACLAR SET Durum=@Durum WHERE AracID=@AracID";
            var parameters = new DynamicParameters();

            parameters.Add("@AracID", updateStatusDto.AracID);
            parameters.Add("@Durum", updateStatusDto.Durum);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }



    }
}
