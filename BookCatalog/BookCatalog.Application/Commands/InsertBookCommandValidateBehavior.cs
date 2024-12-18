﻿using BookCatalog.Application.DTOs;
using BookCatalog.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Data;

namespace BookCatalog.Application.Commands
{
    public class InsertBookCommandValidateBehavior(IBookRepository bookRepository,IValidator<InsertBookCommand> validator)
        : IPipelineBehavior<InsertBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository = bookRepository
            ?? throw new ArgumentNullException(nameof(bookRepository));

        private readonly IValidator<InsertBookCommand> _validator = validator
            ?? throw new ArgumentNullException(nameof(validator));

        public async Task<BookDto> Handle(InsertBookCommand request, RequestHandlerDelegate<BookDto> next, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var booksWithSameName = await _bookRepository.GetBookByTitleName(request.Title);

            var bookExists = booksWithSameName
                .Any(x =>
                    x.PublishDate.Date == request.PublishDate.Date &&
                    x.Author == request.Author &&
                    x.Genre == request.Genre
                );

            if (bookExists)
            {
                throw new DuplicateNameException($"Book {request.Title} already exists.");
            }

            return await next();
        }
    }
}
