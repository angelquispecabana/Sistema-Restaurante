using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Restaurante.WebMVC.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Debe ingresar el correo obligatoriamente.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage ="Maximo 100 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe ingresar la contraseña obligatoriamente.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}