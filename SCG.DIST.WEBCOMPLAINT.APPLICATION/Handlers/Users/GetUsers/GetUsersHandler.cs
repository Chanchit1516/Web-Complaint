using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequestDTO, List<UserResponseDTO>>
    {
        private IUnitOfWork _unitOfWork;

        public GetUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserResponseDTO>> Handle(GetUsersRequestDTO request, CancellationToken cancellationToken)
        {
            return new List<UserResponseDTO>
            {
                new UserResponseDTO
                {
                    Email = "surapong.phian19@gmail.com",
                    FirstName = "surapong",
                    LastName = "phian",
                    Username = "surapong.p"
                }
            };
        }
    }
}
