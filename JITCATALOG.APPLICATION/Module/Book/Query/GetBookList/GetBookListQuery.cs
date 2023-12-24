using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Query.GetBookList
{
    public class GetBookListQuery : IRequest<List<GetBookListViewModel>>
    {
    }
}
