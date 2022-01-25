using App.Restaurante.Repositories;
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
        }
        public IPlatoRepository Platos
        {
            get;
            private set;
        }
    }
}
