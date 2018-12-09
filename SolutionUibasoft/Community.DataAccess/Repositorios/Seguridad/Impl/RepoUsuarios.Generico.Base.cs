using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.Entidades.Seguridad;
using Community.DataAccess.Helpers;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;
using Dapper;

namespace Community.DataAccess.Repositorios.Seguridad.Impl
{
    public class RepoUsuariosGenericoBase : IRepoUsuarios
    {
        public RepoUsuariosGenericoBase()
        {
            
        }

        public async Task<List<UsuarioDto>> GetAllAsync()
        {
            var result = new List<UsuarioDto>();                      
            using (var connection = new FactoryDataAccess().GetConnection)
            {
                var query = "select * from Usuarios";
                var repository = new RepositoryGenerico<Usuario>(connection);
                var response = await repository.GetAllAsync(query);
                var enumerable = response as Usuario[] ?? response.ToArray();
                if (enumerable.Any())
                {
                    result.AddRange(enumerable.Select(ele => new UsuarioDto()
                    {
                        Id = ele.Id,
                        Nombres = ele.Nombres,
                        Apellidos = ele.Apellidos
                    }));
                }
            }
            return result;
        }

        public async Task<List<UsuarioDto>> GetAllPaginateAsync(int pageIndex, int pageSize)
        {
            var result = new List<UsuarioDto>();
            var connectionString = new SettingsHelper("ConnectionString").GetSettingsConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "usp_GetAllPaginate";
                var param = new DynamicParameters();
                param.Add("@PageIndex", pageIndex);
                param.Add("@PageSize", pageSize);                
                var response = await connection.QueryAsync<Usuario>(query, param, commandType: CommandType.StoredProcedure);
                var usuarios = response as Usuario[] ?? response.ToArray();
                if (usuarios.Any())
                {
                    result.AddRange(usuarios.Select(ele => new UsuarioDto()
                    {
                        Id = ele.Id,
                        Nombres = ele.Nombres,
                        Apellidos = ele.Apellidos
                    }));
                }
            }
            return result;
        }
    }
}
