using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Commands.Update
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string? Isbn { get; set; }

        public string? Titre { get; set; }

        public DateTime? DatePublication { get; set; }

        public int? NombrePage { get; set; }

        public string? Couverture { get; set; }

        public string? Langue { get; set; }


    }
}
