using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

using Microsoft.EntityFrameworkCore;

namespace FiloKiralama_Api.Models.DapperContext
{   
        public class Context
        {
            private readonly IConfiguration _configuration;
            private readonly string _connectionString;

            public Context(IConfiguration configuration)
            {
                _configuration = configuration;
                _connectionString = _configuration.GetConnectionString("connection");
            }
            public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        //public Context(DbContextOptions<Context> options):base(options) { } //eklendi

        }
}
