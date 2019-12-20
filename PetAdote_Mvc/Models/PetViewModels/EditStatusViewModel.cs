using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.Models.PetViewModels
{
    public class EditStatusViewModel
    {
        [Key]
        public int Id { get; set; }
        public string status { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoAddress { get; set; }
        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

    }
}