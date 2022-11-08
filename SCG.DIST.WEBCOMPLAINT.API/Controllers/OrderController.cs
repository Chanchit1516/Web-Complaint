using AspNet.Security.OAuth.Introspection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Orders.Commands;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Orders.Queries;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Orders;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Attribute;
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
    public class OrderController : Controller
    {
        private IMediator _mediator;
        private IUnitOfWork _unitOfWork;
        public OrderController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ResponseResult<List<OrderResponseDTO>>> GetAllOrder()
        {
            var result = await _mediator.Send(new GetAllOrderTableQuery());
            return ResponseResult<List<OrderResponseDTO>>.Success(result);
        }

        [HttpPost]
        public async Task<ResponseResult<string>> InsertOrder([FromBody] CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<string>.Success();
        }

    }
}
