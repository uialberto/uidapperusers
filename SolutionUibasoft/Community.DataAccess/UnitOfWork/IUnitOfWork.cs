﻿using System;
using Community.DataAccess.Repositorios.Seguridad;

namespace Community.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
        IRepoUsuarios UsuariosRepo { get; }
        void Complete();
    }

   
}
