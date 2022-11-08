using AspNet.Security.OAuth.Introspection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Products.Commands;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Products.Queries;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Products;
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
    public class ProductController : Controller
    {
        private IMediator _mediator;
        private IUnitOfWork _unitOfWork;
        public ProductController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ResponseResult<List<ProductResponseDTO>>> GetAllProduct()
        {
            var result = await _mediator.Send(new GetAllProductTableQuery());
            return ResponseResult<List<ProductResponseDTO>>.Success(result);
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<ResponseResult<string>> InsertProduct([FromBody] CreateProductCommand request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<string>.Success();
        }
    }
}
