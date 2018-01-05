using AutoMapper;
using ContactApp.Core.Domain.Customers;
using ContactApp.API.ViewModels.Customers;
using ContactApp.Core.Domain.Enquiries;
using ContactApp.API.ViewModels.Enquiries;

namespace ContactApp.API.Infrastructure.Mapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<EnquiryViewModel, Enquiry>();
        }
    }
}
