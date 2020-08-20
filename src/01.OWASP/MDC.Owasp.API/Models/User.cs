using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDC.Owasp.API.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        public User(string login, string password, string name)
        {
            Id = Guid.NewGuid();
            Login = login;
            Password = password;
            Name = name;
        }
    }
}
