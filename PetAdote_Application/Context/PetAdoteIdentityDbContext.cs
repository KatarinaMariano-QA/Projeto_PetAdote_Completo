using Microsoft.AspNet.Identity.EntityFramework;
using PetAdote_Dominio.Entities;
using System;
using System.Data.Entity;
using MySql.Data.Entity;
namespace PetAdote_Application.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PetAdoteIdentityDbContext : IdentityDbContext<User>, IDisposable
    {
        public PetAdoteIdentityDbContext() : base("PetAdoteConnection")
        {
        }
        static PetAdoteIdentityDbContext()
        {
            Database.SetInitializer<PetAdoteIdentityDbContext>(new IdentityDbInit());
        }
        public static PetAdoteIdentityDbContext Create()
        {
            return new PetAdoteIdentityDbContext();
        }

        
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<PetAdoteIdentityDbContext>
    {
    }
}

