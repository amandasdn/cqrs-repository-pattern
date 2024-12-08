using AutoMapper;
using BookCatalog.Application.DTOs;
using BookCatalog.Application.Notification;
using BookCatalog.Domain.Interfaces;
using MediatR;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommandHandler(IBookRepository bookRepository, IMapper mapper, IMediator mediator)
        : IRequestHandler<InsertBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository = bookRepository
            ?? throw new ArgumentNullException(nameof(bookRepository));

        private readonly IMapper _mapper = mapper
            ?? throw new ArgumentNullException(nameof(mapper));

        private readonly IMediator _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        public async Task<BookDto> Handle(InsertBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity = request.ToEntity();

            var createdBookId = await _bookRepository.Add(bookEntity);

            bookEntity.Id = createdBookId;

            var bookCreated = new BookCreatedNotification(bookEntity.Id, bookEntity.Title);
            await _mediator.Publish(bookCreated, cancellationToken);

            return _mapper.Map<BookDto>(bookEntity);
        }
    }
}
