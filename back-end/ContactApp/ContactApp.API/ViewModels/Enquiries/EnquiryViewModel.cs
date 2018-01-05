using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ContactApp.API.ViewModels.Customers;
using ContactApp.API.Validators.Enquiries;


namespace ContactApp.API.ViewModels.Enquiries
{
    public class EnquiryViewModel : IValidatableObject
    {
        public string id { get; set; }

        public int CustomerId { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public CustomerViewModel Customer { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new EnquiryViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item =>
                                        new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
