using PetAdote_Dominio.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PetAdote_Infra.Mappings
{
    public class PetMap : EntityTypeConfiguration<Pet>
    {
        public PetMap()
        {
            ToTable("Pet");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.IdUser);                      
            Property(x => x.Name).HasMaxLength(50);
            Property(x => x.Breed).HasMaxLength(50);
            Property(x => x.Age);
            Property(x => x.Status).HasMaxLength(10);
            Property(x => x.TypeName).HasMaxLength(15);
            Property(x => x.SizeName).HasMaxLength(15);;
            Property(x => x.GenderName).HasMaxLength(15);
            Property(x => x.Cautions).HasMaxLength(100);
            Property(x => x.History).HasMaxLength(250);

        }

    }
}