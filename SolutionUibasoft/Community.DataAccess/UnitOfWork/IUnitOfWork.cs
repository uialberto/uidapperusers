using System;
using Community.DataAccess.Repositorios.Seguridad;

namespace Community.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepoUsuarios UsuariosRepo { get; }
        void Complete();
    }

   
}
