using Community.DataAccess.Repositorios.Seguridad;
using System;

namespace Community.DataAccess.UnitOfWork
{
    public class UnitOfWorkDapper : IUnitOfWork
    {
        #region Atributos

        private readonly IRepoUsuarios _repoUsuarios;

        #endregion

        #region Constructor

        public UnitOfWorkDapper(IRepoUsuarios repoUsuarios)
        {
            _repoUsuarios = repoUsuarios;
        }

        #endregion

        #region Save Changes

        public void Complete()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Propiedades

        public IRepoUsuarios UsuariosRepo
        {
            get
            {
                return _repoUsuarios;
            }
        }

        #endregion

        #region Dispose

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
