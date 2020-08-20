using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDC.Owasp.API.Requests
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string AccessToken => Guid.NewGuid().ToString();
        public string GrantType => "Bearer";
        public DateTime Expiration => DateTime.Now.AddDays(1);

        public LoginResponse(Guid userId, string name)
        {
            UserId = userId;
            Name = name;
        }
    }
}
