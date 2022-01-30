using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace App.Restaurante.Models
{
    public class Grupo
    {
        [ExplicitKey]
        public int IdGrupo { get; set; }
        public string Descripcion { get; set; }
        
    }
}
