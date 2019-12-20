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
    public class PetArchiveMap : EntityTypeConfiguration<PetArchive>
    {
        public PetArchiveMap()
        {
            ToTable("PetArchive");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


        }

    }
}