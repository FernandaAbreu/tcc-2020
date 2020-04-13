using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ui.viewmodels.CustomValidators;

namespace api.viewmodels
{
    public class VMInstructor
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Nome é Obrigatório"), MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail é Obrigatório"),
       RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
       ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é Obrigatório"), MinLength(3), MaxLength(255)]
        public string Password { get; set; }
        [Required(ErrorMessage = "CNPJ/CPF obrigatório")]
        [Display(Name = "CPF")]
        [CustomValidationCPFAttribute(ErrorMessage = "CPF inválido")]
        public string cpf { get; set; }
        [Required(ErrorMessage = "RG é obrigatório")]
        [RegularExpression("^([0-9]{2}[.][0-9]{3}[.][0-9]{3}[-][0-9]{1})$", ErrorMessage = "Por favor, preencha o campo no formato: 00.000.000-0")]
        [Display(Name = "RG")]
        public string RG { get; set; }
        [Required(ErrorMessage = "Logradouro obrigatório"), MinLength(3), MaxLength(255)]
        [Display(Name = "Logradouro ")]
        public string Street { get; set; }
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Bairro obrigatório"), MinLength(3), MaxLength(255)]
        public string Neighborhood { get; set; }
        [Display(Name = "Cidade ")]
        [Required(ErrorMessage = "Cidade é Obrigatório")]
        [BindRequired]
        public int idCity { get; set; }
        [Display(Name = "Estado ")]
        [Required(ErrorMessage = "Estado é Obrigatório")]
        [BindRequired]
        public int idState { get; set; }
        public int idUser { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
