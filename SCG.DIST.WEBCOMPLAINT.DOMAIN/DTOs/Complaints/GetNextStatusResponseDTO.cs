namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users
{
    public class GetNextStatusResponseDTO
    {
        public List<GetNextStatusResponseDTO_NextStatus> NextStatusItems { get; set; }
        public string CurrentStatus { get; set; }
    }

    public class GetNextStatusResponseDTO_NextStatus
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
