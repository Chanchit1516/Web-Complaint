using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : Controller
    {
        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseResult<List<UserResponseDTO>>> GetUsers([FromBody] GetUsersRequestDTO request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<List<UserResponseDTO>>.Success(result);
        }
        
        [HttpGet("{userID}")]
        public async Task<ResponseResult<UserResponseDTO>> GetUserInfo([FromRoute] int userID)
        {
            var result = await _mediator.Send(new GetUserInfoRequestDTO
            {
                UserID = userID
            });
            return ResponseResult<List<UserResponseDTO>>.Success(result);
        } 
        
        [HttpPut("{userID}")]
        public async Task<ResponseResult<PutUserResponseDTO>> PutUser([FromBody] PutUserRequestDTO request, [FromRoute] string userID)
        {
            request.UserID = userID;
            var result = await _mediator.Send(request);
            return ResponseResult<PutUserResponseDTO>.Success(result);
        }

        //[HttpDelete]
        //public async Task<ResponseResult<string>> DeleteUser()
        //{
        //    return default;
        //} 
        
        [HttpPost]
        public async Task<ResponseResult<PostUserResponseDTO>> PostUser([FromBody] PostUserRequestDTO request)
        {
            var result = await _mediator.Send(request);
            return ResponseResult<PostUserResponseDTO>.Success(result);
        }
    }
}
