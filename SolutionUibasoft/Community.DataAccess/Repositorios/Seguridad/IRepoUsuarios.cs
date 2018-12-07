using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.Entidades.Seguridad;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;

namespace Community.DataAccess.Repositorios.Seguridad
{
    public interface IRepoUsuarios
    {
        Task<List<UsuarioDto>> GetAllAsync();
        Task<List<UsuarioDto>> GetAllPaginateAsync(int pageIndex, int pageSize);
    }
}
