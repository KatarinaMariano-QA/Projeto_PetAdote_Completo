using System.ComponentModel.DataAnnotations;

namespace PetAdote_Mvc.Models.AccountViewModels
{
    public class LoginViewModel
    {
       
        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Email { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Password { get; set; }
    }
}