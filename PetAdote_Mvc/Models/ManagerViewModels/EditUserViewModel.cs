using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.Models.ManagerViewModels
{
    public class EditUserViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Email { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string ONG { get; set; }
        [Required]
        [MaxLength(14, ErrorMessage = "Máximo de 11 caracteres")]
        public string Telephone { get; set; }

    }
}