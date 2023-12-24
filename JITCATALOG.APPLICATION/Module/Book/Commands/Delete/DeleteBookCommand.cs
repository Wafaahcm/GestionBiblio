using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Module.Book.Commands.Delete
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
