using PetAdote_Dominio.IRepositories;
using PetAdote_Infra.Context;
using PetAdote_Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdote_Infra.Transaction
{
    public class UnityOfWork : IUnityOfWork
    {
        private PetAdoteDbContext _context;

        private Dictionary<Type, object> _repositories;

        public UnityOfWork(PetAdoteDbContext context)
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