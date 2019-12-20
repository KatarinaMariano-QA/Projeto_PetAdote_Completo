using System;
using System.Collections.Generic;

namespace PetAdote_Dominio.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        void SaveChanges();
    }
}
