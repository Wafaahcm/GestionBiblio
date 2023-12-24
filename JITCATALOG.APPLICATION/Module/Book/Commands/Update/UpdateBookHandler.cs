using AutoMapper;
using JITCATALOG.APPLICATION.Contracts;
using JITCATALOG.DOMAIN.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITCATALOG.APPLICATION.Features.Book.Commands.Update
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand,Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IBookRepository bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Livre livre = _mapper.Map<Livre>(request);
            await _bookRepository.Update(livre);
            return Unit.Value;
        }
    }
}
