using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core.Models.Auth
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
