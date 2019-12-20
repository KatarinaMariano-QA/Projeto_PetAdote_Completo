using PetAdote_Dominio.IRepositories;
using System;

namespace PetAdote_InfraData.Transaction
{
    public interface IUnityOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int Commit();
    }
}
