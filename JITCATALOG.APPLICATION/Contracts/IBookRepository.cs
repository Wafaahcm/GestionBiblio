using JITCATALOG.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Contracts
{
    public interface IBookRepository : IBaseRepository <Livre>
    {
        Task<IEnumerable<Livre>> GetAllBookAsync(bool includeCategory);
        Task<Livre> GetBookByIdAsync(int id, bool includeCategory);
    }
}
