using FiloKiralama_Api.Dtos.UsersDtos;
using FiloKiralama_Api.Repositories.UsersRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var values = await _usersRepository.GetAllUser();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers(CreateUsersDto createUsersDto)
        {
            _usersRepository.CreateUser(createUsersDto);
            return Ok("Üye başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            _usersRepository.DeleteUser(id);
            return Ok("Üye başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsers(UpdateUsersDto updateUsersDto)
        {
            _usersRepository.UpdateUser(updateUsersDto);
            return Ok("Üye başarılı bir şekilde güncellendi");
        }

        [HttpGet("{Email},{Sifre}")]
        public async Task<IActionResult> GetUser(string Email,string Sifre)
        {
            var value = await _usersRepository.GetUser(Email,Sifre);
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser2(int id)
        {
            var value = await _usersRepository.GetUser2(id);
            return Ok(value);
        }
        
    }
}
