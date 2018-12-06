using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.UnitOfWork;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;

namespace Community.AppServices.Modulos.Seguridad.Impl
{
    public class ServiceUsuariosGeneric : IServiceUsuarios
    {
        private IUnitOfWork _unitOfWork;

        public ServiceUsuariosGeneric(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<UsuarioDto>> GetAllPaginate(int pageIndex, int pageSize)
        {
            return await _unitOfWork.UsuariosRepo.GetAllPaginateAsync(pageIndex, pageSize);
        }
    }
}
