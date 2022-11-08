using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Models
{
    public class UserCredential
    {
        public class ComplaintUserCredential
        {
            [JsonPropertyName("user_id")]
            public int UserId { get; set; }
            [JsonPropertyName("email")]
            public string Email { get; set; }
            [JsonPropertyName("user_name")]
            public string UserName { get; set; }
            [JsonPropertyName("first_name")]
            public string FirstName { get; set; }
            [JsonPropertyName("last_name")]
            public string LastName { get; set; }
            [JsonPropertyName("is_administrator")]
            public bool IsAdministrator { get; set; }
            [JsonPropertyName("role_id")]
            public string RoleId { get; set; }
            [JsonPropertyName("role_name")]
            public string role_name { get; set; }
            [JsonPropertyName("token")]
            public string Token { get; set; }

        }
    }
}
