using System;
using System.Collections.Generic;
using ContactApp.Core.Domain.Enquiries;


namespace ContactApp.Services.Enquiries
{
    public interface IEnquiryService
    {
        IEnumerable<Enquiry> GetEnquiries();
        Enquiry GetEnquiry(int id);
        void CreateEnquiry(Enquiry enquiry);
        void UpdateEnquiry(Enquiry enquiry);
        void DeleteEnquiry(Enquiry enquiry);
        void SaveEnquiry();
    }
}
