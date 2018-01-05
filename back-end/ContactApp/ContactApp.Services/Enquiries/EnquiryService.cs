using System;
using System.Collections.Generic;
using ContactApp.Core.Domain.Enquiries;
using ContactApp.Data.Infrastructure;

namespace ContactApp.Services.Enquiries
{
    public class EnquiryService : IEnquiryService
    {
        private readonly IRepository<Enquiry> _enquiryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnquiryService(IRepository<Enquiry> enquiryRepository, IUnitOfWork unitOfWork)
        {
            this._enquiryRepository = enquiryRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Enquiry> GetEnquiries()
        {
            //return _enquiryRepository.GetAll();
            return _enquiryRepository.AllIncluding(x => x.Customer);
        }

        public Enquiry GetEnquiry(int id)
        {
            //return _enquiryRepository.GetSingle(id);
            return _enquiryRepository.GetSingle(x => x.Id == id, x => x.Customer);
        }

        public void CreateEnquiry(Enquiry enquiry)
        {
            _enquiryRepository.Add(enquiry);
        }

        public void UpdateEnquiry(Enquiry enquiry)
        {
            _enquiryRepository.Update(enquiry);
        }

        public void DeleteEnquiry(Enquiry enquiry)
        {
            _enquiryRepository.Delete(enquiry);
        }

        public void SaveEnquiry()
        {
            _unitOfWork.Commit();
        }
    }
}