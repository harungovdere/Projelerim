using Dapper;
using FiloKiralama_Api.Dtos.CarDtos;
using FiloKiralama_Api.Dtos.ModelYearDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.ModelYearRepository
{
    public class ModelYearRepository : IModelYearRepository
    {
        private readonly Context _context;

        public ModelYearRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<GetByIDModelYearDto>> GetModelYear(int MarkaID, int TipID)
        {
            string query = "SELECT Y.MarkaKodu,N.MarkaAdi,Y.TipKodu,M.TipAdi,Y.ModelYili FROM  MODEL_YILLARI Y INNER JOIN MODELLER M ON M.MarkaKodu=Y.MarkaKodu and M.TipKodu=Y.TipKodu INNER JOIN MARKALAR N ON N.MarkaKodu=Y.MarkaKodu WHERE Y.TipKodu=@TipKodu AND Y.MarkaKodu=@MarkaKodu";
            var parameters = new DynamicParameters();
            parameters.Add("@MarkaKodu", MarkaID);
            parameters.Add("@TipKodu", TipID);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIDModelYearDto>(query,parameters);
                return values.ToList();

                //var values = await connection.QueryAsync<ResultCarDto>(query);
                //return values.ToList();
                //var values = await connection.QueryFirstOrDefaultAsync<GetByIDCarDto>(query, parameters);
                //return values;
            }

        }
    }
}
