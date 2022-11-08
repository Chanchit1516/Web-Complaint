using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Extensions
{
    public static class UserPrincipalExtensions
    {
        public static string GetUserId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.Claims.FirstOrDefault(s => s.Type == ClaimStore.UserId.ToString());
            return claim?.Value;
        }
    }
}
