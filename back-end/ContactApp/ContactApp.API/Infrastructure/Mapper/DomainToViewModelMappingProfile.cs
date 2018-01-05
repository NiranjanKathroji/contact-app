using AutoMapper;
using ContactApp.Core.Domain.Customers;
using ContactApp.API.ViewModels.Customers;
using ContactApp.Core.Domain.Enquiries;
using ContactApp.API.ViewModels.Enquiries;

namespace ContactApp.API.Infrastructure.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();

            CreateMap<Enquiry, EnquiryViewModel>();
        }
    }
}
