using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MenuRoleMVC.WEB.Models
{
    public class LoginModels
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Por favor ingrese usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Por favor ingrese Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? UserRoleId { get; set; }
        public string RoleName { get; set; }
    }
}