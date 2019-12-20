using PetAdote_Dominio.Entities;
using PetAdote_Dominio.IRepositories;
using PetAdote_InfraData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdote_InfraData.Repositories
{
    public class PetArchiveRepository : Repository<PetArchive>, IPetArchiveRepository
    {
        public PetArchiveRepository(PetAdoteContext context)
            : base(context)
        {

        }

        public PetArchive GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.pet.Name.Contains(name));
        }
    }
}