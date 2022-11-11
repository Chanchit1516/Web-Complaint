using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Complaints.GetNextStatus
{
    public class GetNextStatusHandler : IRequestHandler<GetNextStatusRequestDTO, GetNextStatusResponseDTO>
    {
        private IUnitOfWork _unitOfWork;

        public GetNextStatusHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetNextStatusResponseDTO> Handle(GetNextStatusRequestDTO request, CancellationToken cancellationToken)
        {
            List<GetNextStatusResponseDTO_NextStatus> items = new List<GetNextStatusResponseDTO_NextStatus>();

            var complaintInfo = await _unitOfWork.ComplaintRepository.GetComplaintByCaseNoAsync(request.CaseNo);

            #region "validation go home"
            if (complaintInfo.Status.Equals(COMPLAINT_STATUS.COMPLETE, StringComparison.InvariantCultureIgnoreCase))
            {
                return new GetNextStatusResponseDTO
                {
                    CurrentStatus = complaintInfo.Status,
                };
            }
            #endregion


            items.Add(new GetNextStatusResponseDTO_NextStatus
            {
                Text = complaintInfo.Status,
                Value = complaintInfo.Status,
            });

            #region
            if (complaintInfo.Status.Equals(COMPLAINT_STATUS.OPEN, StringComparison.InvariantCultureIgnoreCase))
            {
                items.Add(new GetNextStatusResponseDTO_NextStatus
                {
                    Text = COMPLAINT_STATUS.FIRST_RESPONSE,
                    Value = COMPLAINT_STATUS.FIRST_RESPONSE,
                });
            }
            else if (complaintInfo.Status.Equals(COMPLAINT_STATUS.FIRST_RESPONSE, StringComparison.InvariantCultureIgnoreCase))
            {
                items.Add(new GetNextStatusResponseDTO_NextStatus
                {
                    Text = COMPLAINT_STATUS.APPROVE,
                    Value = COMPLAINT_STATUS.APPROVE,
                });
            }
            else if (complaintInfo.Status.Equals(COMPLAINT_STATUS.APPROVE, StringComparison.InvariantCultureIgnoreCase))
            {
                items.Add(new GetNextStatusResponseDTO_NextStatus
                {
                    Text = COMPLAINT_STATUS.RESOLVE,
                    Value = COMPLAINT_STATUS.RESOLVE,
                });
                items.Add(new GetNextStatusResponseDTO_NextStatus
                {
                    Text = COMPLAINT_STATUS.RESOLVE_WITH_SURVEY,
                    Value = COMPLAINT_STATUS.RESOLVE_WITH_SURVEY,
                });
            }
            #endregion


            items.Add(new GetNextStatusResponseDTO_NextStatus
            {
                Text = COMPLAINT_STATUS.CANCEL,
                Value = COMPLAINT_STATUS.CANCEL,
            });

            return new GetNextStatusResponseDTO
            {
                CurrentStatus = complaintInfo.Status,
                NextStatusItems = items,
            };
        }
    }

    public class COMPLAINT_STATUS
    {
        public const string OPEN = "Open";
        public const string FIRST_RESPONSE = "First Response";
        public const string APPROVE = "Approve";
        public const string RESOLVE = "Resolve";
        public const string RESOLVE_WITH_SURVEY = "Resolve With Survey";
        public const string COMPLETE = "Complete";
        public const string CANCEL = "Cancel";
    }
}
