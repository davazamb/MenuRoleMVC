using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuRoleMVC.WEB.Models
{
    public class MenuModels
    {
        public string MainMenuName { get; set; }
        public int MainMenuId { get; set; }
        public string SubMenuName { get; set; }
        public int SubMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? PerfilId { get; set; }
        public string PerfilNombre { get; set; }
    }
}