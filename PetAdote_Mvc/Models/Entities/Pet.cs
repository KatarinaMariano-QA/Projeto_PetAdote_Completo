using PetAdote_Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.Models.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Cautions { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string Breed { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Máximo de 250 caracteres")]
        public string History { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Status { get; set; }   

        public Gender Gender { get; set; }

        public Size Size { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoAddress { get; set; }
        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}