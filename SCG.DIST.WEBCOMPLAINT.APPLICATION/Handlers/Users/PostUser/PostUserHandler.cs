using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.PostUser;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.GetUsers
{
    public class PostUserHandler : IRequestHandler<PostUserRequestDTO, PostUserResponseDTO>
    {
        private IUnitOfWork _unitOfWork;

        public PostUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostUserResponseDTO> Handle(PostUserRequestDTO request, CancellationToken cancellationToken)
        {
            return new PostUserResponseDTO(); 
        }
    }
}
