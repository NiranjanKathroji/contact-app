using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ContactApp.API.ViewModels.Enquiries;
using ContactApp.API.Validators.Customers;

namespace ContactApp.API.ViewModels.Customers
{
    public class CustomerViewModel
    {
        public string id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Avatar { get; set; }

        public ICollection<EnquiryViewModel> Enquiries { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CustomerViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item =>
                                        new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }

    }
}
