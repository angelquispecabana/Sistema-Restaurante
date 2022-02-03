using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Restaurante.WebMVC.Models
{
    public class SubGrupoViewModel
    {
        public SubGrupo SubGrupo { get; set; }
        [Required]
        public IEnumerable<Grupo> ListaGrupo { get; set; }
    }
}