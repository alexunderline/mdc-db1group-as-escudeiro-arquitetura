using MDC.Owasp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDC.Owasp.API.Infrastructure.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
