using System;
using System.ComponentModel.DataAnnotations;

namespace viewmodels
{
    public class VMLoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class VMLoginResponse
    {
        public string Token { get; set; }
    }
}
