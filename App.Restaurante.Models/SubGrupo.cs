using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Models
{
    public class SubGrupo
    {
        [ExplicitKey]
        public int IdSubGrupo { get; set; }
        public int IdGrupo { get; set; }
        public string Descripcion { get; set; }
    }
}
