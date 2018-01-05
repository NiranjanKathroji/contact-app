using ContactApp.Core.Domain.Customers;

namespace ContactApp.Core.Domain.Enquiries
{
    /// <summary>
    /// Represents a enquiry message
    /// </summary>
    public class Enquiry : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the enquiry title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the enquiry text
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}


