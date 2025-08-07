namespace Demo.Validators;

using FluentValidation;
using System;
using Demo.Models;

public class AuthorValidator : AbstractValidator<Author> {
    public AuthorValidator() {
        RuleFor(author => author.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name cannot exceed 100 characters");
        
        RuleFor(author => author.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .MaximumLength(100)
            .WithMessage("Email cannot exceed 100 characters");

        RuleFor(author => author.DateOfBirth)
            .NotEmpty()
            .WithMessage("Date of birth is required");
        
        RuleFor(author => author.Address)
            .NotEmpty()
            .WithMessage("Address is required")
            .MaximumLength(100)
            .WithMessage("Address cannot exceed 100 characters");
    }
}