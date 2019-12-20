using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PetAdote_Dominio.Entities
{
    public class Pet
    {

        [Key]
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string TypeName { get; set; }
        public string GenderName { get; set; }
        public string SizeName { get; set; }
        public string Cautions { get; set; }
        public string Breed { get; set; }
        public string History { get; set; }
        public string Status { get; set; }

        [NotMapped]
        public virtual ICollection<Type> Types { get; set; } 
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Gender> Genders { get; set; }


        [DataType(DataType.ImageUrl)]
        public string PhotoAddress { get; set; }
        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
        public Pet() { }
        public Pet(string IdUser, string Name, int Age, string GenderName, string SizeName, string Cautions , string Breed ,string History,string Status, string PhotoAddress, HttpPostedFileBase Photo) {
            this.IdUser = IdUser;
            this.Name = Name;
            this.Age = Age;
            this.SizeName = SizeName;
            this.GenderName = GenderName;
            this.Cautions = Cautions;
            this.Breed = Breed;
            this.History = History;
            this.Status = Status;
            this.PhotoAddress = PhotoAddress;
            this.Photo = Photo;
        }

    }
}
