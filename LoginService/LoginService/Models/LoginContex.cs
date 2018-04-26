using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LoginService.Models
{
    public class LoginContext:DbContext
    {
        public LoginContext()
        {
        }
        public DbSet<UserRegistation> Register { get; set; }
    }
}