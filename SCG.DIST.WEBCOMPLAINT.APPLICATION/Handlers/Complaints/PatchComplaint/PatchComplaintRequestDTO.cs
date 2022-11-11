using MediatR;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Complaints.GetNextStatus
{
    public class PatchComplaintRequestDTO : IRequest<PatchComplaintResponseDTO>
    {
        public string CaseNo { get; set; }
    }
}
