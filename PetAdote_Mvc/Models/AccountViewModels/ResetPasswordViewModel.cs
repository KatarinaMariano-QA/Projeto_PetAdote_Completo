using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Email { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}