using FiloKiralama_Api.Repositories.MemberTransactionsRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberTransactionsController : ControllerBase
    {
        private readonly IMemberTransactions _memberTransactions;

        public MemberTransactionsController(IMemberTransactions memberTransactions)
        {
            _memberTransactions = memberTransactions;
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberTransactions(int islem,int id)
        {
            var value = await _memberTransactions.GetMemberTransactions(islem,id);
            return Ok(value);
        }
    }
}
