using BookCatalog.Application.Commands;
using FluentValidation;

namespace BookCatalog.Application.Validators
{
    public class InsertBookCommandValidator : AbstractValidator<InsertBookCommand>
    {
        public InsertBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title is required.")
                .MinimumLength(3).WithMessage("The title must have at least 3 characters")
                .MaximumLength(100).WithMessage("The title must not exceed 100 characters.");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("The author is required.")
                .MinimumLength(2).WithMessage("The title must have at least 2 characters")
                .MaximumLength(100).WithMessage("The author must not exceed 100 characters.");

            RuleFor(x => x.PublishDate)
                .NotEmpty().WithMessage("The publish date is required.")
                .Must(BeAValidDate).WithMessage("The publish date must be a valid date.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("The publish date cannot be in the future.");

            RuleFor(x => x.Genre)
                .NotEmpty().WithMessage("The genre is required.")
                .MinimumLength(3).WithMessage("The title must have at least 3 characters")
                .MaximumLength(50).WithMessage("The genre must not exceed 50 characters.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default;
        }
    }
}
