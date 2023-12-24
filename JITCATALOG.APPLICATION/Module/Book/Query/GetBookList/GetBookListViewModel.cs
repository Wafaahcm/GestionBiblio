using JITCATALOG.APPLICATION.Features.Book.Query.GetBookDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Query.GetBookList
{
    public class GetBookListViewModel
    {
        public int Id { get; set; }

        public string? Isbn { get; set; }

        public string? Titre { get; set; }

        public DateTime? DatePublication { get; set; }

        public int? NombrePage { get; set; }

        public EditeurDTO? Editeur { get; set; }


        public AuteurDTO? AuteurId { get; set; }

        public string? Couverture { get; set; }

        public string? Langue { get; set; }

        public GenreDTO? GenreId { get; set; }
    }
}
