using System;
using System.ComponentModel.DataAnnotations;

namespace api.viewmodels
{
    public class VMLoginRequest
    {
        [Required(ErrorMessage = "E-mail é Obrigatório"),
      RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
      ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Senha é obrigatória"), MinLength(3), MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class VMLoginResponse
    {
        public string Token { get; set; }
    }
}
