﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PanelMenuRolEntities : DbContext
    {
        public PanelMenuRolEntities()
            : base("name=PanelMenuRolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblMainMenu> tblMainMenu { get; set; }
        public virtual DbSet<tblPerfil> tblPerfil { get; set; }
        public virtual DbSet<tblSubMenu> tblSubMenu { get; set; }
        public virtual DbSet<tblUsuario> tblUsuario { get; set; }
    }
}