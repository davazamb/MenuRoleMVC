//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MenuRoleMVC.WEB.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSubMenu
    {
        public int Id { get; set; }
        public string SubMenu { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<int> MainMenuId { get; set; }
        public Nullable<int> RoleId { get; set; }
    
        public virtual tblMainMenu tblMainMenu { get; set; }
        public virtual tblPerfil tblPerfil { get; set; }
    }
}
