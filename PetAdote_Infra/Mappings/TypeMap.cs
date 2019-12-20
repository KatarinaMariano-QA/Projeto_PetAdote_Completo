using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetAdote_Dominio.Entities;
namespace PetAdote_Infra.Mappings
{
    public class TypeMap : EntityTypeConfiguration<PetAdote_Dominio.Entities.Type>
    {
        public TypeMap()
        {
            ToTable("Type");

            Property(x => x.TypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TypeName).HasMaxLength(15);
        }
    }
}
