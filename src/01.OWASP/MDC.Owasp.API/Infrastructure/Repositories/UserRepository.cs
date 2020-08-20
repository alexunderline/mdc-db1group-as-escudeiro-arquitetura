using MDC.Owasp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDC.Owasp.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OwaspDbContext _owaspDbContext;

        public UserRepository(OwaspDbContext owaspDbContext)
        {
            _owaspDbContext = owaspDbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var query = "SELECT * FROM Users";

            var result = await _owaspDbContext.Users.FromSqlRaw(query).ToListAsync();

            return result;
        }

        public async Task<User> GetByLoginAndPasswordAsync(string login, string password)
        {
            var query = "SELECT * FROM Users WHERE Username = '" + login + "' AND Password = '" + password + "'";

            var result = await _owaspDbContext.Users.FromSqlRaw(query).FirstOrDefaultAsync();

            return result;
        }
    }
}
