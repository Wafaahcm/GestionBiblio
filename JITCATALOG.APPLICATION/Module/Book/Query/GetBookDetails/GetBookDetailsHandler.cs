using AutoMapper;
using JITCATALOG.APPLICATION.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Query.GetBookDetails
{
    public class GetBookDetailsHandler : IRequestHandler<GetBookDetailsQuery, GetBookDetailsViewModel>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookDetailsHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;   
        }

        public async Task<GetBookDetailsViewModel> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var livre = await _bookRepository.GetBookByIdAsync(request.Id, true);

            return _mapper.Map<GetBookDetailsViewModel>(livre);
        }
    }
}
