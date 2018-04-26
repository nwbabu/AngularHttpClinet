using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace JwtDemo.Models
{
    public class Models
    {
    }
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public LoginResponse()
        {

            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }

    }
}