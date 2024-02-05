using Dapper;
using FiloKiralama_Api.Dtos.UsersDtos;
using FiloKiralama_Api.Models.DapperContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.UsersRepository
{
    public class UsersRepository:IUsersRepository
    {
        private readonly Context _context;
        public UsersRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultUsersDto>> GetAllUser()
        {
            string query = "SELECT * FROM KULLANICILAR ORDER BY Role";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultUsersDto>(query);
                return values.ToList();
            }
        }
        public async void CreateUser(CreateUsersDto createUsersDto)
        {
            string query = "INSERT INTO KULLANICILAR(TC,Ad,Soyad,DogumTarihi,Cinsiyet,EhliyetNo,EhliyetSinifi,Email,CepTel,Sifre,Role) VALUES (@TC,@Ad,@Soyad,@DogumTarihi,@Cinsiyet,@EhliyetNo,@EhliyetSinifi,@Email,@CepTel,@Sifre,@Role)";
            var parameters = new DynamicParameters();
            parameters.Add("@TC", createUsersDto.TC);
            parameters.Add("@Ad", createUsersDto.Ad);
            parameters.Add("@Soyad", createUsersDto.Soyad);
            parameters.Add("@DogumTarihi", createUsersDto.DogumTarihi);
            parameters.Add("@Cinsiyet", createUsersDto.Cinsiyet);
            parameters.Add("@EhliyetNo", createUsersDto.EhliyetNo);
            parameters.Add("@EhliyetSinifi", createUsersDto.EhliyetSinifi);
            parameters.Add("@Email", createUsersDto.Email);
            parameters.Add("@CepTel", createUsersDto.CepTel);
            parameters.Add("@Sifre", createUsersDto.Sifre);
            parameters.Add("@Role", createUsersDto.Role);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteUser(int id)
        {
            string query = "DELETE FROM KULLANICILAR WHERE KullaniciID=@KullaniciID";
            var parameters = new DynamicParameters();
            parameters.Add("@KullaniciID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateUser(UpdateUsersDto updateUsersDto)
        {
            if (updateUsersDto.EskiSifre != null && updateUsersDto.YeniSifre != null && updateUsersDto.YeniSifreTekrar != null)
            {
                string query2 = "UPDATE KULLANICILAR SET Sifre=@Sifre WHERE KullaniciID=@KullaniciID";
                var parameters2 = new DynamicParameters();

                parameters2.Add("@KullaniciID", updateUsersDto.KullaniciID);
                parameters2.Add("@Sifre", updateUsersDto.YeniSifre);

                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query2, parameters2);
                }
            }
            else
            {
                string query = "UPDATE KULLANICILAR SET TC=@TC,Ad=@Ad,Soyad=@Soyad,DogumTarihi=@DogumTarihi,Cinsiyet=@Cinsiyet,EhliyetNo=@EhliyetNo,EhliyetSinifi=@EhliyetSinifi,Email=@Email,CepTel=@CepTel,Sifre=@Sifre WHERE KullaniciID=@KullaniciID";
                var parameters = new DynamicParameters();

                parameters.Add("@KullaniciID", updateUsersDto.KullaniciID);
                parameters.Add("@TC", updateUsersDto.TC);
                parameters.Add("@Ad", updateUsersDto.Ad);
                parameters.Add("@Soyad", updateUsersDto.Soyad);
                parameters.Add("@DogumTarihi", updateUsersDto.DogumTarihi);
                parameters.Add("@Cinsiyet", updateUsersDto.Cinsiyet);
                parameters.Add("@EhliyetNo", updateUsersDto.EhliyetNo);
                parameters.Add("@EhliyetSinifi", updateUsersDto.EhliyetSinifi);
                parameters.Add("@Email", updateUsersDto.Email);
                parameters.Add("@CepTel", updateUsersDto.CepTel);
                parameters.Add("@Sifre", updateUsersDto.Sifre);

                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }
            }

        }

        public async Task<GetByIDUsersDto> GetUser(string Email, string Sifre)
        {
            string query = "SELECT * FROM KULLANICILAR  WHERE Email=@Email AND Sifre=@Sifre";
            var parameters = new DynamicParameters();
            parameters.Add("@Email", Email);
            parameters.Add("@Sifre", Sifre);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDUsersDto>(query, parameters);
                return values;
            }
        }

        public async Task<GetByIDUsersDto> GetUser2(int id)
        {
            string query = "SELECT * FROM KULLANICILAR  WHERE KullaniciID=@KullaniciID";
            var parameters = new DynamicParameters();
            parameters.Add("@KullaniciID",id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDUsersDto>(query, parameters);
                return values;
            }
        }

    }
}
