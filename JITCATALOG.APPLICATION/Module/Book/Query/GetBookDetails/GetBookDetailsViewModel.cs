using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Query.GetBookDetails
{
    public class GetBookDetailsViewModel
    {
        public int Id { get; set; }

        public string? Isbn { get; set; }

        public string? Titre { get; set; }

        public DateTime? DatePublication { get; set; }

        public int? NombrePage { get; set; }

        public int EditeurId { get; set; }

        public int AuteurId { get; set; }

        public string? Couverture { get; set; }

        public string? Langue { get; set; }

        public int GenreId { get; set; }
    }
}
