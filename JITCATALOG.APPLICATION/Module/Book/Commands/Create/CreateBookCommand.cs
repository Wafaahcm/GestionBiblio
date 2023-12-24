using JITCATALOG.DOMAIN.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Contracts.Book.Commands.Create
{
    public class CreateBookCommand : IRequest<int>
    {
        public string? Isbn { get; set; }

        public string? Titre { get; set; }

        public DateTime? DatePublication { get; set; }

        public int? NombrePage { get; set; }

        public int? EditeurId { get; set; }

        public int? AuteurId { get; set; }

        public string? Couverture { get; set; }

        public string? Langue { get; set; }

        public int? GenreId { get; set; }
    }
}
