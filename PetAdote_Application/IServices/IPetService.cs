using PetAdote_Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdote_Application.IServices
{
    public interface IPetService
    {
        IEnumerable<Pet> Get();
        Pet Get(int? id);
        void SaveOrUpdate(Pet entity);
        void Delete(int id);
    }
}
