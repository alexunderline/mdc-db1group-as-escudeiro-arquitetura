using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDC.Owasp.API.Requests
{
    public class LoginResponse
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string AccessToken { get; private set; }
        public string GrantType => "Bearer";
        public DateTime Expiration => DateTime.Now.AddDays(1);

        public LoginResponse(Guid userId, string name, string token)
        {
            UserId = userId;
            Name = name;
            AccessToken = token;
        }
    }
}
