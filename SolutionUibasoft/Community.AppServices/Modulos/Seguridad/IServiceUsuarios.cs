using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;

namespace Community.AppServices.Modulos.Seguridad
{
    public interface IServiceUsuarios
    {
        Task<List<UsuarioDto>> GetAllPaginate(int pageIndex, int pageSize);
        Task<List<UsuarioDto>> GetAllAsync();
        int DeleteFullUser(long idUser);
    }
}
