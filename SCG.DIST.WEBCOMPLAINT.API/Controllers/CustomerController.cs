using AspNet.Security.OAuth.Introspection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Customers.Commands;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Customers.Queries;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Customers;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Attribute;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Extensions;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Filters;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Models;

namespace SCG.DIST.WEBCOMPLAINT.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiException]
    [ApiController]
    [ValidateModel]
    [Authorize(AuthenticationSchemes = OAuthIntrospectionDefaults.AuthenticationScheme)]
    //[TypeFilter(typeof(BasicAuthenticationActionFilter), Order = 2, Arguments = new object[] { BasicAuthenticationSystem.CPM })]
    public class CustomerController : Controller
    {
        private IMediator _mediator;
        private IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseResult<List<CustomerResponseDTO>>> GetAllCustomer()
        {
            var userId = HttpContext?.User?.Identity?.GetUserId() ?? "1";
            var result = await _mediator.Send(new GetAllCustomerTableQuery());
            return ResponseResult<List<CustomerResponseDTO>>.Success(result);
        }

        [HttpPost]
        public async Task<ResponseResult<string>> InsertCustomer([FromBody] CreateCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<string>.Success();
        }
    }
}
