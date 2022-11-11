using MediatR;
using Microsoft.AspNetCore.Mvc;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Complaints.GetNextStatus;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.GetUsers;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.PostUser;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Attribute;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Filters;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Models;

namespace SCG.DIST.WEBCOMPLAINT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiException]
    [ApiController]
    [ValidateModel]
    //[Authorize(AuthenticationSchemes = OAuthIntrospectionDefaults.AuthenticationScheme)]
    //[TypeFilter(typeof(BasicAuthenticationActionFilter), Order = 2, Arguments = new object[] { BasicAuthenticationSystem.CPM })]
    public class ComplaintController : Controller
    {
        private IMediator _mediator;
        public ComplaintController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch]
        public async Task<ResponseResult<PatchComplaintResponseDTO>> PatchComplaint([FromBody] PatchComplaintRequestDTO request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<PatchComplaintResponseDTO>.Success(result);
        }
        
        [HttpGet]
        public async Task<ResponseResult<List<UserResponseDTO>>> GetComplaints([FromBody] GetUsersRequestDTO request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<List<UserResponseDTO>>.Success(result);
        } 
        
        //[HttpGet("{CaseNo}")]
        //public async Task<ResponseResult<List<UserResponseDTO>>> GetComplaintInfo([FromRoute] string CaseNo)
        //{
        //    var result = await _mediator.Send();
        //    return ResponseResult<List<UserResponseDTO>>.Success(result);
        //}

        #region "action"
        [HttpPost("[action]")]
        public async Task<ResponseResult<List<UserResponseDTO>>> SyncComplaint([FromBody] GetUsersRequestDTO request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<List<UserResponseDTO>>.Success(result);
        }

        [HttpPost("[action]")]
        public async Task<ResponseResult<GetNextStatusResponseDTO>> GetNextStatus([FromBody] GetNextStatusRequestDTO request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<GetNextStatusResponseDTO>.Success(result);
        }
        #endregion



    }
}
