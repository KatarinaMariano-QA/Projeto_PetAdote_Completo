using PetAdote_Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace PetAdote_InfraData.Mappings
{
    public class PetMap : EntityTypeConfiguration<Pet>
    {
        public PetMap () {
            ToTable("Pet");

            //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(50);
            Property(x => x.Breed).HasMaxLength(50);
            Property(x => x.Age);
            Property(x => x.Status);
            Property(x => x.Cautions).HasMaxLength(100);
            Property(x => x.History).HasMaxLength(100);

        }
        
    }
}
