using FiloKiralama_Api.Dtos.MemberTransactionsDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiloKiralama_Api.Repositories.MemberTransactionsRepository
{
    public interface IMemberTransactions
    {
        Task<List<ResultMemberTransactionsDto>> GetMemberTransactions(int islem,int id);
    }
}
