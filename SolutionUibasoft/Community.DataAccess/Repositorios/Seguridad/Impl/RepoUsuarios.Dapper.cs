using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.Entidades.Seguridad;
using Community.DataAccess.Helpers;
using Dapper;

namespace Community.DataAccess.Repositorios.Seguridad.Impl
{
    public class RepoUsuariosDapper
    {
        public List<UsuarioDto> List()
        {
            var result = new List<UsuarioDto>();
            var query = "select * from Usuarios";
            var connectionString = new SettingsHelper("ConnectionString").GetSettingsConnection();           
            using (var db = new SqlConnection(connectionString))
            {
                var usuarios = db.Query<Usuario>(query).ToList();
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

        public int Insert(UsuarioDto data)
        {
            var result = 0;
            var query = string.Empty;
            query += " INSERT INTO Usuarios (Nombres, Apellidos) VALUES (@Name, @Apellidos)";
            var connectionString = new SettingsHelper("ConnectionString").GetSettingsConnection();
            using (var db = new SqlConnection(connectionString))
            {
                result = db.Execute(query, new { Name = data.Nombres, Apellidos = data.Apellidos });
            }
            return result;
        }
    }
}
