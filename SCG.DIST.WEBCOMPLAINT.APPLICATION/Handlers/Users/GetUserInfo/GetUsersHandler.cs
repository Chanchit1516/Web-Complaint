using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.GetUsers
{
    public class GetUserInfoHandler : IRequestHandler<GetUserInfoRequestDTO, UserResponseDTO>
    {
        private IUnitOfWork _unitOfWork;

        public GetUserInfoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponseDTO> Handle(GetUserInfoRequestDTO request, CancellationToken cancellationToken)
        {
            var userInfo = await _unitOfWork.UserRepository.GetUserByUserIDAsync(request.UserID);

            return new UserResponseDTO
            {
                BuId = userInfo.BuId,
                Email = userInfo.Email,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                RoleId = userInfo.RoleId,
                Status = userInfo.Status,
                UserId = userInfo.UserId,
                Username = userInfo.Username,
            };
        }
    }
}
