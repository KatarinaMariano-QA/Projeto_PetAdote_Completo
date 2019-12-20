using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.Models.ManagerViewModels
{
    public class EditPasswordViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}