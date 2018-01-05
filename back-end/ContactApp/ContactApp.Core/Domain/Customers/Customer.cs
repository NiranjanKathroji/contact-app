using System;
using System.Collections.Generic;
using ContactApp.Core.Domain.Enquiries;

namespace ContactApp.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public class Customer : BaseEntity
    {
        private ICollection<Enquiry> _enquiries;

        /// <summary>
        /// Ctor
        /// </summary>
        public Customer()
        {
            this.CustomerGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the customer GUID
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        /// <value>The avatar.</value>
        public string Avatar { get; set; }

        #region Navigation properties


        /// <summary>
        /// Gets or sets customer addresses
        /// </summary>
        public virtual ICollection<Enquiry> Enquiries
        {
            get { return _enquiries ?? (_enquiries = new List<Enquiry>()); }
            set { _enquiries = value; }
        }

        #endregion
    }
}
