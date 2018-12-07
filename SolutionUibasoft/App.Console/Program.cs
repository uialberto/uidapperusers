using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.AppServices.Modulos.Seguridad;
using Community.AppServices.Modulos.Seguridad.Impl;
using Community.DataAccess.Infrastructure;
using Community.DataAccess.Repositorios.Seguridad;
using Community.DataAccess.Repositorios.Seguridad.Impl;
using Community.DataAccess.UnitOfWork;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;
using Unity;

namespace App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IRepoUsuarios, RepoUsuariosGeneric>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWorkDapper>();
            container.RegisterType<IServiceUsuarios, ServiceUsuariosGeneric>();

            var appUsers = container.Resolve<IServiceUsuarios>();

            var task = Task.Run(() => appUsers.GetAllPaginate(1,1));
            task.Wait();          

            var usuarios = task.Result;

            foreach (var user in usuarios)
            {
                System.Console.WriteLine($"Id: {user.Id}, Nombres :{user.Nombres}, Apellidos: {user.Apellidos}");
            }
            System.Console.ReadLine();

        }
        private void RunDapper()
        {
            GetAll();
            var newUsuario = new UsuarioDto() { Nombres = "Alberto 2", Apellidos = "Baigorria 2" };
            var row = new ServiceUsuarios().Insert(newUsuario);
            System.Console.WriteLine($"Filas Insertadas: {row}");
            GetAll();
            System.Console.ReadLine();
        }

        private static void GetAll()
        {
            var usuarios = new ServiceUsuarios().List();
            foreach (var user in usuarios)
            {
                System.Console.WriteLine($"Id: {user.Id}, Nombres :{user.Nombres}, Apellidos: {user.Apellidos}");
            }
        }
    }
}
