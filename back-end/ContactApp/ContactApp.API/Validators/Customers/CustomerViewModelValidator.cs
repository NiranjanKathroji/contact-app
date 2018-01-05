using System;
using FluentValidation;
using ContactApp.API.ViewModels.Customers;

namespace ContactApp.API.Validators.Customers
{
    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty");

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email.");

            RuleFor(customer => customer.UserName)
                .NotEmpty().WithMessage("Username cannot be empty");

            RuleFor(customer => customer.Gender)
                .NotEmpty().WithMessage("Gender cannot be empty");
        }
    }
}
