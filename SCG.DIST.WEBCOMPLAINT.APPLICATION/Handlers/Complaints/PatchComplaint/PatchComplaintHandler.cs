using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Complaints.GetNextStatus
{
    public class PatchComplaintHandler : IRequestHandler<GetNextStatusRequestDTO, GetNextStatusResponseDTO>
    {
        private IUnitOfWork _unitOfWork;

        public PatchComplaintHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetNextStatusResponseDTO> Handle(GetNextStatusRequestDTO request, CancellationToken cancellationToken)
        {
            return default;
        }
    }

}
