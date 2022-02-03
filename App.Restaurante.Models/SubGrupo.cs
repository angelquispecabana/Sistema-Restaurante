using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Restaurante.Models
{
    public class SubGrupo
    {
        [ExplicitKey]
        public int IdSubGrupo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int IdGrupo { get; set; }
        [Computed]
        public string Descripcion_Grupo { get; set; }
        public bool Estado { get; set; }
        //[Computed]
        //public IEnumerable<Grupo> ListaGrupo { get; set; }
    }
}
