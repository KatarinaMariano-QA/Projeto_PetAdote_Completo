using PetAdote_Dominio.IRepositories;
using PetAdote_InfraData.Context;
using PetAdote_InfraData.Repositories;
using System;
using System.Collections.Generic;

namespace PetAdote_InfraData.Transaction
{
    public class UnityOfWork : IUnityOfWork
    {
        private PetAdoteContext _context;

        private Dictionary<Type, object> _repositories;

        public UnityOfWork(PetAdoteContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (this._repositories == null)
            {
                this._repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);

            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new Repository<TEntity>(this._context);
            }

            return (IRepository<TEntity>)this._repositories[type];
        }
        public int Commit()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(obj: this);

        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._context != null)
                {
                    this._context.Dispose();
                    this._context = null;
                }
            }
        }
    }
}