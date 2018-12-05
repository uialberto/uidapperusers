using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Community.DataAccess.Entidades.Seguridad;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;

namespace Community.DataAccess.Repositorios.Seguridad.Impl
{
    public class RepoUsuarios
    {
        private readonly IRepository<Usuario> _repo;

        public RepoUsuarios()
        {
            _repo = new RepositoryDapper<Usuario>();
        }

        public List<UsuarioDto> List()
        {
            var result = new List<UsuarioDto>();
            var query = "select * from Usuarios";
            var usuarios = _repo.GetAll(query).ToList();
            if (usuarios.Any())
            {
                result.AddRange(usuarios.Select(ele => new UsuarioDto()
                {
                    Id = ele.Id,
                    Nombres = ele.Nombres,
                    Apellidos = ele.Apellidos
                }));
            }            
            return result;
        }

        public int Insert(UsuarioDto data)
        {
            var result = 0;
            var query = string.Empty;
            query += " INSERT INTO Usuarios (Nombres, Apellidos) VALUES (@Nombres, @Apellidos)";
            result = _repo.SaveData(query, new Usuario {Nombres = data.Nombres, Apellidos = data.Apellidos});
            return result;
        }
    }
}
