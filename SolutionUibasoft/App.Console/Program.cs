using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.AppServices.Modulos.Seguridad.Impl;
using Community.DataTransfer.DataTransferObjects.Modulos.Seguridad;

namespace App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAll();
            //var newUsuario = new UsuarioDto(){ Nombres = "Alberto 1", Apellidos = "Baigorria 1"};

            //var row = new ServiceUsuarios().Insert(newUsuario);
            //System.Console.WriteLine($"Filas Insertadas: {row}");

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
