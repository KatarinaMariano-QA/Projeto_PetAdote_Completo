using PetAdote_Application.IServices;
using PetAdote_Dominio.Entities;
using PetAdote_Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdote_Application.Services
{
    public class PetService : IPetService
    {
        private readonly IUnityOfWork _Uow;

        public PetService(IUnityOfWork Uow)
        {
            this._Uow = Uow;
        }

        public void Delete(int id)
        {
            _Uow.GetRepository<Pet>().Remove(id);
        }

        public IEnumerable<Pet> Get()
        {
            return _Uow.GetRepository<Pet>().GetAll();
        }

        public Pet Get(int? id)
        {
            return _Uow.GetRepository<Pet>().GetById(id);
        }

        public void SaveOrUpdate(Pet entity)
        {
            if (entity.Id == 0)
            {
                _Uow.GetRepository<Pet>().Add(entity);
                _Uow.GetRepository<Pet>().SaveChanges();
            }
            else
            {
                _Uow.GetRepository<Pet>().Update(entity);

            }
        }

        public void Dispose()
        {
            _Uow.GetRepository<Pet>().Dispose();
        }


    }
}