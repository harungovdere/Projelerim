using Dapper;
using FiloKiralama_Api.Dtos.MemberTransactionsDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.MemberTransactionsRepository
{
    public class MemberTransactionsRepository:IMemberTransactions
    {
        private readonly Context _context;

        public MemberTransactionsRepository(Context context)
        {
            _context = context;

        }

        public async Task<List<ResultMemberTransactionsDto>> GetMemberTransactions(int islem,int id)
        {
            if (islem == 1)
            {
                //Kiralık Araç Rezerveler
                string query = "SELECT K.*,L.Ad,L.Soyad,L.CepTel,L.Email,M.MarkaAdi,N.TipAdi FROM KIRALIK_ARAC_REZERVE K INNER JOIN MODELLER N ON K.TipID=N.ModelTipID INNER JOIN MARKALAR M ON N.MarkaID=M.MarkaID INNER JOIN KULLANICILAR L ON K.KullaniciID=L.KullaniciID WHERE K.KullaniciID=@KullaniciID AND K.Durum=1 AND K.TeslimAlmaTarihi >= CONVERT(VARCHAR,GETDATE(),23) ORDER BY K.RezerveID DESC";
                var parameters = new DynamicParameters();
                parameters.Add("@KullaniciID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultMemberTransactionsDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if(islem == 2)
            {
                //Kiralanan Araçlar
                string query = "SELECT G.ID,G.KullaniciID,CONCAT(K.Ad,' ',K.Soyad) AS Kullanici,A.Plaka,M.MarkaAdi,N.TipAdi,R.ToplamGunSayisi,R.GunlukKira,R.ToplamTutar,G.KiraBaslangicTarihi,G.KiraBitisTarihi,R.TeslimEtmeKonumu,R.TeslimEtmeSaati,CASE WHEN A.DURUM=3 THEN 'KULLANIMDA' ELSE 'TESLİM EDİLDİ' END AS Durum FROM GUNLUK_KIRALANAN_ARACLAR G INNER JOIN KIRALIK_ARAC_REZERVE R ON R.RezerveID=G.RezerveID INNER JOIN KULLANICILAR K ON K.KullaniciID=G.KullaniciID INNER JOIN ARACLAR A ON A.AracID=G.AracID INNER JOIN MARKALAR M ON M.MarkaKodu=A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu=A.TipKodu AND M.MarkaKodu=N.MarkaKodu WHERE A.Durum=3 AND K.KullaniciID=@KullaniciID ORDER BY G.ID DESC";
                var parameters = new DynamicParameters();
                parameters.Add("@KullaniciID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultMemberTransactionsDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if(islem == 3)
            {
                //İkinci El Randevular
                string query = "SELECT R.*,CONCAT(K.Ad,' ',K.Soyad) AS [RandevuSahibi],K.Email,K.CepTel,A.Plaka,M.MarkaAdi,N.TipAdi,A.ModelYili FROM IKINCIEL_RANDEVU R INNER JOIN ARACLAR A ON A.AracID=R.AracID INNER JOIN KULLANICILAR K ON R.KullaniciID=K.KullaniciID INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu WHERE R.KullaniciID=@KullaniciID AND R.Durum=1 AND R.RandevuTarihi >= CONVERT(VARCHAR,GETDATE(),23) ORDER BY R.RandevuID DESC";
                var parameters = new DynamicParameters();
                parameters.Add("@KullaniciID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultMemberTransactionsDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if(islem == 4)
            {
                //Satın Alınan Araçlar
                string query = "SELECT S.SatisID,A.AracID,CONCAT(K.Ad,' ',K.Soyad) AS Kullanici,A.Plaka,M.MarkaAdi,N.TipAdi,A.ModelYili,K.Ad,K.Soyad,D.Durum,F.Fiyat,S.SatisTarihi FROM  ARACLAR A  LEFT OUTER JOIN IKINCIEL_FIYATLAR F ON A.AracID=F.AracID INNER JOIN IKINCIEL_SATIS S ON S.AracID=A.AracID INNER JOIN KULLANICILAR K ON K.KullaniciID=S.KullaniciID INNER JOIN MARKALAR M ON M.MarkaKodu = A.MarkaKodu INNER JOIN MODELLER N ON N.TipKodu = A.TipKodu AND M.MarkaKodu = N.MarkaKodu  INNER JOIN ARAC_DURUM D ON D.DurumID=A.Durum WHERE D.DurumID=7 AND S.KullaniciID=@KullaniciID ORDER BY S.SatisID DESC";
                var parameters = new DynamicParameters();
                parameters.Add("@KullaniciID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultMemberTransactionsDto>(query, parameters);
                    return values.ToList();
                }
            }
            else if (islem == 5)
            {
                //Kiralık Araç Rezerveler İptal
                string query = "UPDATE KIRALIK_ARAC_REZERVE SET Durum=0 WHERE RezerveID=@RezerveID";
                var parameters = new DynamicParameters();
                parameters.Add("@RezerveID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultMemberTransactionsDto>(query, parameters);
                    return values.ToList();
                }
            }
            else
            {
                //İkinci El Randevular İptal
                string query = "UPDATE IKINCIEL_RANDEVU SET Durum=0 WHERE RandevuID=@RandevuID";
                var parameters = new DynamicParameters();
                parameters.Add("@RandevuID", id);
                using (var connection = _context.CreateConnection())
                {
                    var values = await connection.QueryAsync<ResultMemberTransactionsDto>(query, parameters);
                    return values.ToList();
                }
            }
        }
    }
}
