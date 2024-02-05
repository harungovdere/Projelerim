using Dapper;
using FiloKiralama_Api.Dtos.InsuranceDtos;
using FiloKiralama_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.InsuranceRepository
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly Context _context;

        public InsuranceRepository(Context context)
        {
            _context = context;
        }
        public async void CreateInsurance(CreateInsuranceDto createInsuranceDto)
        {
            string query = "insert into POLICELER (PoliceTuru,Plaka,BrutPrim,BaslangicTarihi,BitisTarihi) VALUES (@PoliceTuru,@Plaka,@BrutPrim,@BaslangicTarihi,@BitisTarihi)";
            var parameters = new DynamicParameters();
            parameters.Add("@PoliceTuru", createInsuranceDto.PoliceTuru);
            parameters.Add("@Plaka", createInsuranceDto.Plaka);
            parameters.Add("@BrutPrim", createInsuranceDto.BrutPrim);
            parameters.Add("@BaslangicTarihi", createInsuranceDto.BaslangicTarihi);
            parameters.Add("@BitisTarihi", createInsuranceDto.BitisTarihi);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteInsurance(int id)
        {
            string query = "DELETE FROM POLICELER WHERE PoliceID=@PoliceID";
            var parameters = new DynamicParameters();
            parameters.Add("@PoliceID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultInsuranceDto>> GetAllInsuranceAsync()
        {
            string query = "SELECT P.PoliceID,PT.PoliceTuruID,PT.PoliceTuruAdi,P.Plaka,P.BrutPrim,P.BaslangicTarihi,P.BitisTarihi FROM POLICELER P INNER JOIN POLICE_TURLERI PT ON PT.PoliceTuruID = P.PoliceTuru";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInsuranceDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetByIDInsuranceDto> GetInsurance(int id)
        {
            string query = "SELECT P.PoliceID,P.PoliceTuru,PT.PoliceTuruAdi,P.Plaka,P.BrutPrim,P.BaslangicTarihi,P.BitisTarihi FROM POLICELER P INNER JOIN POLICE_TURLERI PT ON PT.PoliceTuruID = P.PoliceTuru WHERE P.PoliceID =@PoliceID";
            var parameters = new DynamicParameters();
            parameters.Add("@PoliceID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDInsuranceDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateInsurance(UpdateInsuranceDto updateInsuranceDto)
        {
            string query = "UPDATE POLICELER SET PoliceTuru=@PoliceTuru,Plaka=@Plaka,BrutPrim=@BrutPrim,BaslangicTarihi=@BaslangicTarihi,BitisTarihi=@BitisTarihi WHERE PoliceID=@PoliceID";
            var parameters = new DynamicParameters();

            parameters.Add("@PoliceTuru", updateInsuranceDto.PoliceTuru);
            parameters.Add("@Plaka", updateInsuranceDto.Plaka);
            parameters.Add("@BrutPrim", updateInsuranceDto.BrutPrim);
            parameters.Add("@BaslangicTarihi", updateInsuranceDto.BaslangicTarihi);
            parameters.Add("@BitisTarihi", updateInsuranceDto.BitisTarihi);
            parameters.Add("@PoliceID", updateInsuranceDto.PoliceID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
