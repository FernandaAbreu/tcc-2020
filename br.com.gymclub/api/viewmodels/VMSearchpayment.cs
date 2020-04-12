using System;
using System.ComponentModel.DataAnnotations;

namespace api.viewmodels
{
    public class VMSearchpayment
    {
        public VMSearchpayment()
        {
        }
        public string searchValue { get; set; }
      
        [DataType(DataType.Date, ErrorMessage = "A data deve ter o seguinte formato dd/mm/yyyy")]
        [Display(Name = "Data Inicial ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime initDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "A data deve ter o seguinte formato dd/mm/yyyy")]
        [Display(Name = "Data Final ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime finalDate { get; set; }
    }
}
