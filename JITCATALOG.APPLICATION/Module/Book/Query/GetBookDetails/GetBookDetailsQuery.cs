using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Query.GetBookDetails
{
    public class GetBookDetailsQuery : IRequest<GetBookDetailsViewModel>
    {
            public int Id { get; set; }
    }
}
