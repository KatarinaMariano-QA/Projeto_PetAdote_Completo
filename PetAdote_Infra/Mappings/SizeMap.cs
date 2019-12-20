using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PetAdote_Infra.Mappings
{
    public class SizeMap : EntityTypeConfiguration<PetAdote_Dominio.Entities.Size>
    {
        public SizeMap()
        {
            ToTable("Size");

            Property(x => x.SizeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SizeName).HasMaxLength(15);
        }

    }
}