using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App.Restaurante.Models
{
    public class Plato
    {
        [Key]
        public int IdPlato { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int IdSubGrupo { get; set; }
        public int IdUnidad { get; set; }
        public bool Estado { get; set; }
    }
}
