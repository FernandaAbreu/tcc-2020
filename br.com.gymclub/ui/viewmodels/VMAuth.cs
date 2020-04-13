using System;
using System.ComponentModel.DataAnnotations;

namespace api.viewmodels
{
    public class VMLoginRequest
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set; }
    }

    public class VMLoginResponse
    {
        public string Token { get; set; }
    }
}
