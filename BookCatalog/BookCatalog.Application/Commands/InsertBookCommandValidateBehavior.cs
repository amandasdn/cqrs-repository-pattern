using MediatR;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommandValidateBehavior : IPipelineBehavior<InsertBookCommand, Guid>
    {
        public async Task<Guid> Handle(InsertBookCommand request, RequestHandlerDelegate<Guid> next, CancellationToken cancellationToken)
        {
            return await next();
        }
    }
}
