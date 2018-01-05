using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ContactApp.Services.Enquiries;
using ContactApp.Core.Domain.Enquiries;
using ContactApp.API.ViewModels.Enquiries;
using ContactApp.Data.Infrastructure;
using AutoMapper;

namespace ContactApp.API.Controllers
{
    [Route("api/Enquiries")]
    public class EnquiriesController : Controller
    {
        private IEnquiryService _enquiryService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public EnquiriesController(IUnitOfWork unitOfWork,
                                   IEnquiryService enquiryService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _enquiryService = enquiryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var enquiries = _enquiryService.GetEnquiries();

            var enquiriesViewModel = _mapper.Map<IEnumerable<Enquiry>,
                                                 IEnumerable<EnquiryViewModel>>(enquiries);

            return new OkObjectResult(enquiriesViewModel);
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetEnquiry")]
        public IActionResult Get(int id)
        {
            var enquiry = _enquiryService.GetEnquiry(id);

            if (enquiry != null)
            {
                EnquiryViewModel enquiryViewModel = _mapper.Map<Enquiry, EnquiryViewModel>(enquiry);
                return new OkObjectResult(enquiryViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]EnquiryViewModel enquiryViewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Enquiry enquiry = _mapper.Map<EnquiryViewModel, Enquiry>(enquiryViewModel);
            _enquiryService.CreateEnquiry(enquiry);
            _unitOfWork.Commit();

            CreatedAtRouteResult result = CreatedAtRoute("GetEnquiry",
                                                         new { controller = "Enquiries", id = enquiry.Id },
                                                         enquiry);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]EnquiryViewModel enquiryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var enquiryFromDb = _enquiryService.GetEnquiry(id);

            if (enquiryFromDb == null)
            {
                return NotFound();
            }
            else
            {
                Enquiry enquiry = _mapper.Map<EnquiryViewModel, Enquiry>(enquiryViewModel);
                _enquiryService.UpdateEnquiry(enquiry);
                _unitOfWork.Commit();
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enquiryFromDb = _enquiryService.GetEnquiry(id);

            if (enquiryFromDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _enquiryService.DeleteEnquiry(enquiryFromDb);
                return new NoContentResult();
            }
        }
    }
}
