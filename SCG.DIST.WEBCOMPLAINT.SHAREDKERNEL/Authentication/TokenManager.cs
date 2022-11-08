using Microsoft.IdentityModel.Tokens;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Models.UserCredential;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Authentication
{
    public enum ClaimStore
    {
        Name,
        Email,
        UserId,
        Role,
        Domain,
        AccountId,
        FirstName,
        LastName,
        UserName
    }
    public class TokenManager
    {
        private static string Secret = AppConfigUtilities.GetAppConfig<string>("JwtKey");
        public static string GetClaim(ClaimStore key, string token)
        {
            var val = GetPrincipal(token).Claims.Where(s => s.Type == key.ToString()).FirstOrDefault();
            if (val == null) return "";


            return val.Value;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                token = token.StartsWith("Bearer ") ? token.Substring(7) : token;
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret);

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = AppConfigUtilities.GetAppConfig<string>("JwtIssuer"),
                    ValidAudience = AppConfigUtilities.GetAppConfig<string>("JwtAudience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret))

                };

                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GenerateComplaintToken(ComplaintUserCredential user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", user.Email),
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", user.Email.ToString()),
                new Claim(ClaimStore.UserId.ToString(), user.UserId.ToString()),
                new Claim(ClaimStore.Email.ToString(), user.Email),
                new Claim(ClaimStore.UserName.ToString(), user.UserName),
                new Claim(ClaimStore.Role.ToString(), user.RoleId.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfigUtilities.GetAppConfig<string>("JwtKey")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble("8"));

            var token = new JwtSecurityToken(
                issuer: AppConfigUtilities.GetAppConfig<string>("JwtIssuer"),
                audience: AppConfigUtilities.GetAppConfig<string>("JwtAudience"),
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
