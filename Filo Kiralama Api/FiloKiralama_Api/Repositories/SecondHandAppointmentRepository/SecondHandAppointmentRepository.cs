using FiloKiralama_Api.Models.DapperContext;
using Dapper;
using FiloKiralama_Api.Dtos.SecondHandAppointmentDtos;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace FiloKiralama_Api.Repositories.SecondHandAppointmentRepository
{
    public class SecondHandAppointmentRepository : ISecondHandAppointmentRepository
    {
        private readonly Context _context;
        public SecondHandAppointmentRepository(Context context)
        {
            _context = context;
        }

        public async void CreateSecondHandAppointment(CreateSecondHandAppointmentDto createSecondHandAppointmentDto)
        {
            string query = "INSERT INTO IKINCIEL_RANDEVU (KullaniciID,AracID,RandevuTarihi,RandevuSaati) VALUES (@KullaniciID,@AracID,@RandevuTarihi,@RandevuSaati)";
            var parameters = new DynamicParameters();
            parameters.Add("@KullaniciID", createSecondHandAppointmentDto.KullaniciID);
            parameters.Add("@AracID", createSecondHandAppointmentDto.AracID);
            parameters.Add("@RandevuTarihi", createSecondHandAppointmentDto.RandevuTarihi);
            parameters.Add("@RandevuSaati", createSecondHandAppointmentDto.RandevuSaati);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultSecondHandAppointmentDto>> GetAllSecondHandAppointment()
        {
            string query = "SELECT R.*,K.Ad,K.Soyad,K.Email,K.CepTel,A.Plaka,CASE WHEN R.Durum=1 THEN 'AKTİF' ELSE 'İPTAL' END AS Durum FROM IKINCIEL_RANDEVU R INNER JOIN ARACLAR A ON A.AracID=R.AracID INNER JOIN KULLANICILAR K ON R.KullaniciID=K.KullaniciID WHERE R.RandevuTarihi >= CONVERT(VARCHAR,GETDATE(),23) ORDER BY R.RandevuID DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSecondHandAppointmentDto>(query);
                return values.ToList();
            }
        }

        public async void UpdateSecondHandAppointment(UpdateSecondHandAppointmentDto updateSecondHandAppointmentDto)
        {
            string query = "UPDATE IKINCIEL_RANDEVU SET KullaniciID=@KullaniciID,AracID=@AracID,RandevuTarihi=@RandevuTarihi,RandevuSaati=@RandevuSaati WHERE RandevuID=@RandevuID";
            var parameters = new DynamicParameters();

            parameters.Add("@KullaniciID", updateSecondHandAppointmentDto.KullaniciID);
            parameters.Add("@AracID", updateSecondHandAppointmentDto.AracID);
            parameters.Add("@RandevuTarihi", updateSecondHandAppointmentDto.RandevuTarihi);
            parameters.Add("@RandevuSaati", updateSecondHandAppointmentDto.RandevuSaati);
            parameters.Add("@RandevuID", updateSecondHandAppointmentDto.RandevuID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async void DeleteSecondHandAppointment(int id)
        {
            string query = "DELETE FROM IKINCIEL_RANDEVU WHERE RandevuID=@RandevuID";
            var parameters = new DynamicParameters();
            parameters.Add("@RandevuID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<ResultSecondHandAppointmentDto> GetSecondHandAppointment(int id)
        {
            string query = "SELECT R.*,K.Ad,K.Soyad,K.Email,K.CepTel,A.Plaka FROM IKINCIEL_RANDEVU R INNER JOIN ARACLAR A ON A.AracID=R.AracID INNER JOIN KULLANICILAR K ON R.KullaniciID=K.KullaniciID  WHERE RandevuID=@RandevuID";
            var parameters = new DynamicParameters();
            parameters.Add("@RandevuID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultSecondHandAppointmentDto>(query, parameters);
                return values;
            }
        }

    }
}
