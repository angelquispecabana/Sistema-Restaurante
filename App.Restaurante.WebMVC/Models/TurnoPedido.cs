using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using App.Restaurante.Models;

namespace App.Restaurante.WebMVC.Models
{
    public class TurnoPedido: Turno
    {

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}