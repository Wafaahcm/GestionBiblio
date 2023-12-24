using AutoMapper;
using JITCATALOG.APPLICATION.Contracts;
using JITCATALOG.APPLICATION.Contracts.Book.Commands.Create;
using JITCATALOG.DOMAIN.Models;
using MediatR;


namespace JITCATALOG.APPLICATION.Features.Book.Commands.Create
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookHandler(IBookRepository bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Livre livre = _mapper.Map<Livre>(request);

            CreateBookValidator validator = new CreateBookValidator();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                throw new Exception("Book is not valid");
            }

            livre = await _bookRepository.Add(livre);

            return livre.Id;
        }
    }
}
