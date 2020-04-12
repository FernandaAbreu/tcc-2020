using System;
using System.ComponentModel.DataAnnotations;


namespace api.viewmodels
{
    public class VMClient
    {

        
        [Required, MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail é Obrigatório"),
       RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
       ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MinLength(3), MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "CNPJ/CPF obrigatório")]
        [Display(Name = "CPF")]
        //[CPF(ErrorMessage = "CPF inválido")]
        public string cpf { get; set; }
        [RegularExpression("(^[A-Za-z]{2}[-][0-9]{2}[.][0-9]{3}[.][0-9]{3})$", ErrorMessage = "Por favor, preencha o campo no formato: AA-00.000.000")]
        [Display(Name = "RG")]
        public string RG { get; set; }

        public int idCity { get; set; }
        public int idState { get; set; }
        public int idPlanType { get; set; }
        public int idTypePayment { get; set; }
        public int idUser { get; set; }

        [Required, MinLength(3), MaxLength(255)]
        [Display(Name = "Logradouro ")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Data de Inicio é Obrigatóris")]
        [DataType(DataType.Date, ErrorMessage = "A data deve ter o seguinte formato dd/mm/yyyy")]
        [Display(Name = "Data de Inicio ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ContractStartDate { get; set; }

        
        [DataType(DataType.Date, ErrorMessage = "A data deve ter o seguinte formato dd/mm/yyyy")]
        [Display(Name = "Data de final do contrato ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ContractEndDate { get; set; }

    }
}
