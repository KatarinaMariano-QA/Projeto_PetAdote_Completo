using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PetAdote_Infra.Mappings
{
    public class GenderMap: EntityTypeConfiguration<PetAdote_Dominio.Entities.Gender>
    {
        public GenderMap()
        {
            ToTable("Gender");

            Property(x => x.GenderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.GenderName).HasMaxLength(15);
        }

    }
}
