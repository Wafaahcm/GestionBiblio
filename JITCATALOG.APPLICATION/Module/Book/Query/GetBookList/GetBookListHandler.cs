using AutoMapper;
using JITCATALOG.APPLICATION.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Query.GetBookList
{
    public class GetBookListHandler : IRequestHandler<GetBookListQuery, List<GetBookListViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListHandler(IBookRepository bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<GetBookListViewModel>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var allLivres = await _bookRepository.GetAllBookAsync(true);

            return _mapper.Map<List<GetBookListViewModel>>(allLivres);
        }
    }
}
