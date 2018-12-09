using Community.DataAccess.Entidades.Seguridad;
using Community.DataAccess.Infrastructure;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Community.DataAccess.Repositorios.Seguridad.Impl
{
    public class RepoUsuariosGeneric : RepositoryDapperGeneric<Usuario>, IRepoUsuarios
    {
        private IConnectionFactory _connectionFactory;
        public RepoUsuariosGeneric(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int FullDelete(long idUser)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<UsuarioDto>> GetAllAsync()
        {
            var result = new List<UsuarioDto>();            
            var query = "select * from Usuarios";
            var response = await GetAllAsync(query);
            var list = response.ToList();
            if (list.Any())
            {
                result.AddRange(list.Select(ele => new UsuarioDto()
                {
                    Id = ele.Id,
                    Nombres = ele.Nombres,
                    Apellidos = ele.Apellidos
                }));
            }
            return result;
        }

        public async Task<List<UsuarioDto>> GetAllPaginateAsync(int pageIndex, int pageSize)
        {
            var result = new List<UsuarioDto>();
            var query = "usp_GetAllPaginate";
            var param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            var response = await _connectionFactory.GetConnection.QueryAsync<Usuario>(query, param, commandType: CommandType.StoredProcedure);            
            var list = response.ToList();
            if (list.Any())
            {
                result.AddRange(list.Select(ele => new UsuarioDto()
                {
                    Id = ele.Id,
                    Nombres = ele.Nombres,
                    Apellidos = ele.Apellidos
                }));
            }
            return result;

        }
    }
}
