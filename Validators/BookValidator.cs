namespace Demo.Validators;
using FluentValidation;
using System;
using Demo.Models;

public class BookValidator : AbstractValidator<Book> {
    public BookValidator() {
        RuleFor(book => book.Title) 
            .NotEmpty()
            .WithMessage("Title is required")
            .MaximumLength(100)
            .WithMessage("Title cannot exceed 100 characters");

        RuleFor(book => book.Author)
            .NotNull()
            .SetValidator(new AuthorValidator());
        
        RuleFor(book => book.Publisher)
            .NotNull()
            .SetValidator(new PublisherValidator());
        
        RuleFor(book => book.PublishYear)
            .LessThanOrEqualTo(DateTime.Now.Year)
            .WithMessage("Publish year cannot be in the future");
    }
}