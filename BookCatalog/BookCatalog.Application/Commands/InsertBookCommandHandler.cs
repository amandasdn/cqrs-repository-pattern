using MediatR;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommandHandler : IRequestHandler<InsertBookCommand, Guid>
    {
        public Task<Guid> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
