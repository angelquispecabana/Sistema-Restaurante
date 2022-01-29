﻿using App.Restaurante.Repositories;
using App.Restaurante.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.UnitOfWork
{
    public class RestauranteUnitOfWork: IUnitOfWork
    {
        public RestauranteUnitOfWork(string connectionString)
        {
            Platos = new PlatoRepository(connectionString);
            Proveedores = new ProveedorRepository(connectionString);
            SubGrupos = new SubGrupoRepository(connectionString);
            //VentasCabecera = new VentaCabeceraRepository(connectionString);
            Turnos = new TurnoRepository(connectionString);
        }
        public IPlatoRepository Platos
        {
            get;
            private set;
        }
        //public IVentaCabeceraRepository VentasCabecera
        //{
        //    get;
        //    private set;
        //}
        public IProveedorRepository Proveedores
        {
            get;
            private set;
        }
        public ISubGrupoRepository SubGrupos
        {
            get;
            private set;
        }
        public ITurnoRepository Turnos
        {
            get;
            private set;
        }
    }
}
