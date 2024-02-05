
using FiloKiralama_Api.Dtos.UsersDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.UsersRepository
{
    public interface IUsersRepository
    {
        Task<List<ResultUsersDto>> GetAllUser();
        void CreateUser(CreateUsersDto createUsersDto);
        void DeleteUser(int id);
        void UpdateUser(UpdateUsersDto updateUsersDto);
        Task<GetByIDUsersDto> GetUser(string Email,string Sifre);
        Task<GetByIDUsersDto> GetUser2(int id);

    }
}
