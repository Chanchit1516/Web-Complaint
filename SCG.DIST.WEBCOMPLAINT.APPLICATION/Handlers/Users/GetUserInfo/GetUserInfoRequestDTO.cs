using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Users.GetUsers
{
    public class GetUserInfoRequestDTO : IRequest<UserResponseDTO>
    {
        public int UserID { get; set; }
    }
}
