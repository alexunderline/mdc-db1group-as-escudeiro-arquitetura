using MDC.Owasp.API.Models;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDC.Owasp.API.Infrastructure.Seeds
{
    public static class OwaspDbContextSeed
    {
        public static void Seed()
        {
            using var db = new OwaspDbContext();

            SetUsers(db);
        }

        private static void SetUsers(OwaspDbContext db)
        {
            if (db.Users.Any())
            {
                return;
            }

            var users = new List<User>
            {
                new User("db1global", "123456", "DB1 Global Software"),
                new User("db1group", "123456", "DB1 Group"),
                new User("timbot", "123456", "Timbot")
            };

            db.Users.AddRange(users);
            db.SaveChanges();
        }
    }
}
