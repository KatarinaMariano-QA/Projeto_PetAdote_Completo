using PetAdote_Dominio.Entities;
using PetAdote_Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;
namespace PetAdote_Infra.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PetAdoteDbContext : DbContext
    {
        public PetAdoteDbContext() : base("PetAdoteConnection")
        {
            Database.SetInitializer<PetAdoteDbContext>(new DropCreateDatabaseIfModelChanges<PetAdoteDbContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<PetAdoteDbContext>());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.CommandTimeout = 300;
        }

        public DbSet<Pet> Pets { get; set; } 
        public DbSet<PetAdote_Dominio.Entities.Type> Types { get; set; }
        public DbSet<PetAdote_Dominio.Entities.Gender> Genders { get; set; }
        public DbSet<PetAdote_Dominio.Entities.Size> Sizes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PetMap());
            modelBuilder.Configurations.Add(new TypeMap());
            modelBuilder.Configurations.Add(new GenderMap());
            modelBuilder.Configurations.Add(new SizeMap());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
