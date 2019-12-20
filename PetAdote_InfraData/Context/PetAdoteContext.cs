using PetAdote_Dominio.Entities;
using PetAdote_InfraData.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdote_InfraData.Context
{
    public class PetAdoteContext : DbContext
    {
        public PetAdoteContext() : base("PetAdoteConnection")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<PetAdoteContext>());
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetArchive> Archives { get; set; }
        public DbSet<PetType> Types { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new PetMap());
            modelBuilder.Configurations.Add(new PetArchiveMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
