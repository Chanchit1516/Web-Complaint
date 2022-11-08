using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.PostUser;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.GetUsers
{
    public class PutUserHandler : IRequestHandler<PutUserRequestDTO, PutUserResponseDTO>
    {
        private IUnitOfWork _unitOfWork;

        public PutUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PutUserResponseDTO> Handle(PutUserRequestDTO request, CancellationToken cancellationToken)
        {
            return new PutUserResponseDTO();
        }
    }
}
