using ALATTest.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Repository.Interface
{
    public interface IBank
    {
        Task<BankResponse> GetAllBanks();
    }
}
