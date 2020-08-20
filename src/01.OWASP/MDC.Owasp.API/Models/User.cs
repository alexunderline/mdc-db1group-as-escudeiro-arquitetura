using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDC.Owasp.API.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        protected User()
        {

        }

        public User(string login, string password, string name)
        {
            Id = Guid.NewGuid();
            Username = login;
            Password = password;
            Name = name;
        }
    }
}
