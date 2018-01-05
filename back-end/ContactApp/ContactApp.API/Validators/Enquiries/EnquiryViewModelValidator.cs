using System;
using FluentValidation;
using ContactApp.API.ViewModels.Enquiries;

namespace ContactApp.API.Validators.Enquiries
{
    public class EnquiryViewModelValidator : AbstractValidator<EnquiryViewModel>
    {
        public EnquiryViewModelValidator()
        {
            RuleFor(enquiry => enquiry.Customer.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty");

            RuleFor(enquiry => enquiry.Customer.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email.");

            RuleFor(enquiry => enquiry.Title)
                .NotEmpty().WithMessage("Title cannot be empty");

            RuleFor(enquiry => enquiry.Message)
                .NotEmpty().WithMessage("Message body cannot be empty");
        }
    }
}
