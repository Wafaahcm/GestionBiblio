using AutoMapper;
using JITCATALOG.APPLICATION.Contracts.Book.Commands.Create;
using JITCATALOG.APPLICATION.Features.Book.Commands.Update;
using JITCATALOG.APPLICATION.Module.Book.Commands.Delete;
using JITCATALOG.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Livre, GetPostsListViewModel>().ReverseMap();
            //CreateMap<Catalog, CatalogDto>().ReverseMap();
            CreateMap<Livre, CreateBookCommand>().ReverseMap();
            CreateMap<Livre, UpdateBookCommand>().ReverseMap();
            CreateMap<Livre, DeleteBookCommand>().ReverseMap();
        }
    }
}
