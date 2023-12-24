using JITCATALOG.APPLICATION.Contracts;
using MediatR;


namespace JITCATALOG.APPLICATION.Module.Book.Commands.Delete
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand,int>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.Id);

            await _bookRepository.Remove(book);

            return 1;
        }
    }
}
