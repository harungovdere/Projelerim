using Dapper;
using FiloKiralama_Api.Dtos.ModelsDtos;
using FiloKiralama_Api.Models.DapperContext;
using FiloKiralama_Api.Repositories.BrandsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.ModelsRepository
{
    public class ModelRepository:IModelRepository
    {
        private readonly Context _context;

        public ModelRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultModelDto>> GetAllModelAsync()
        {
            string query = "SELECT * FROM MODELLER ORDER BY TipAdi";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultModelDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<GetByIDModelDto>> GetModel(int id)
        {
            string query = "SELECT M.TipID,M.TipKodu,M.TipAdi,N.MarkaID,N.MarkaKodu,N.MarkaAdi FROM MODELLER M INNER JOIN MARKALAR N ON M.MarkaID = N.MarkaID WHERE N.MarkaKodu = @MarkaKodu";
            var parameters = new DynamicParameters();
            parameters.Add("@MarkaKodu", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetByIDModelDto>(query, parameters);
                return values.ToList();
            }
        }

       
    }
}
