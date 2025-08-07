namespace Demo.Validators;

using FluentValidation;
using System;
using Demo.Models;

public class PublisherValidator : AbstractValidator<Publisher> {
    public PublisherValidator() {
        RuleFor(pulisher => pulisher.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(200)
            .WithMessage("Name cannot exceed 200 characters");
        
        RuleFor(publisher => publisher.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .MaximumLength(100)
            .WithMessage("Email cannot exceed 100 characters");
        
        RuleFor(publisher => publisher.Phone)
            .NotEmpty()
            .WithMessage("Phone is required")
            .MaximumLength(20)
            .WithMessage("Phone cannot exceed 20 characters");
        
        RuleFor(pulisher => pulisher.Location)
            .NotEmpty()
            .WithMessage("Location is required")
            .MaximumLength(200)
            .WithMessage("Location cannot exceed 200 characters");
    }
}