using Dapper;
using FiloKiralama_Api.Dtos.BrandsDtos;
using FiloKiralama_Api.Models.DapperContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.BrandsRepository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly Context _context;

        public BrandRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
            string query = "SELECT * FROM MARKALAR ORDER BY MarkaAdi";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBrandDto>(query);
                return values.ToList();
            }
        }
    }
}
