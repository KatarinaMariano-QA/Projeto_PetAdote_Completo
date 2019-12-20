using PetAdote_Dominio.Entities;
using PetAdote_Dominio.IRepositories;
using PetAdote_Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdote_Infra.Repositories
{
    public class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(PetAdoteDbContext context)
            : base(context)
        {

        }

        public Pet GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name.Contains(name));
        }
    }
}