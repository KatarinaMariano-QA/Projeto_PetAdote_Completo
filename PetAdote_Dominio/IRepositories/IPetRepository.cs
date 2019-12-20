using PetAdote_Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdote_Dominio.IRepositories
{
    public interface IPetRepository : IRepository<Pet>
    {
        Pet GetByName(string name);
    }
}
