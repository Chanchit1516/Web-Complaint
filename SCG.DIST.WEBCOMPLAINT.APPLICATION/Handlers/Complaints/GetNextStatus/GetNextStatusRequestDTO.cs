using MediatR;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Complaints.GetNextStatus
{
    public class GetNextStatusRequestDTO : IRequest<GetNextStatusResponseDTO>
    {
        public string CaseNo { get; set; }
    }
}
