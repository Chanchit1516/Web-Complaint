using MediatR;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;
using System.Text.Json.Serialization;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.PostUser
{
    public class PutUserRequestDTO : IRequest<PutUserResponseDTO>
    {
        public string UserName { get; set; }
        [JsonIgnore]
        public string UserID { get; set; }
    }
}
