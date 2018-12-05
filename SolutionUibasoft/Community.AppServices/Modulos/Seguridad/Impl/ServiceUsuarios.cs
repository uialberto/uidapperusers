using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.Repositorios.Seguridad.Impl;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;

namespace Community.AppServices.Modulos.Seguridad.Impl
{
    public class ServiceUsuarios
    {
        public List<UsuarioDto> List()
        {
            return new RepoUsuariosDapper().List();
        }

        public int Insert(UsuarioDto param)
        {
            return new RepoUsuariosDapper().Insert(param);
        }
    }
}
