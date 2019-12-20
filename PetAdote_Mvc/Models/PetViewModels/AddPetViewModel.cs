using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.Models.PetViewModels
{
    public class AddPetViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Name { get; set; }

        public int Age { get; set; }

        public int TypeId { get; set; }

        public int GenderId { get; set; }

        public int SizeId { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        public string GenderName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        public string SizeName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        public string Status { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Cautions { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Breed { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Máximo de 250 caracteres")]
        public string History { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoAddress { get; set; }
        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}