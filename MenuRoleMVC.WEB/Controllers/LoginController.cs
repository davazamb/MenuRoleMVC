using MenuRoleMVC.WEB.DataModels;
using MenuRoleMVC.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MenuRoleMVC.WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModels _login)
        {
            if (ModelState.IsValid) //validating the user inputs
            {
                bool isExist = false;
                using (PanelMenuRolEntities ctx = new PanelMenuRolEntities())  // out Entity name is "SampleMenuMasterDBEntites"
                {
                    isExist = ctx.tblUsuario.Where(x => x.Usuario.Trim().ToLower() == _login.Usuario.Trim().ToLower()).Any(); //validating the user name in tblLogin table whether the user name is exist or not
                    if (isExist)
                    {
                        LoginModels _loginCredentials = ctx.tblUsuario.Where(x => x.Usuario.Trim().ToLower() == _login.Usuario.Trim().ToLower()).Select(x => new LoginModels
                        {
                            Usuario = x.Usuario,
                            PerfilNombre = x.tblPerfil.Perfiles,
                            UsarioPerfilId = x.PerfilId,
                            UsuarioId = x.Id
                        }).FirstOrDefault();  // Get the login user details and bind it to LoginModels class
                        List<MenuModels> _menus = ctx.tblSubMenu.Where(x => x.RoleId == _loginCredentials.UsarioPerfilId).Select(x => new MenuModels
                        {
                            MainMenuId = x.tblMainMenu.Id,
                            MainMenuName = x.tblMainMenu.MainMenu,
                            SubMenuId = x.Id,
                            SubMenuName = x.SubMenu,
                            ControllerName = x.Controller,
                            ActionName = x.Action,
                            PerfilId = x.RoleId,
                            PerfilNombre = x.tblPerfil.Perfiles
                        }).ToList(); //Get the Menu details from entity and bind it in MenuModels list.
                        FormsAuthentication.SetAuthCookie(_loginCredentials.Usuario, false); // set the formauthentication cookie
                        Session["LoginCredentials"] = _loginCredentials; // Bind the _logincredentials details to "LoginCredentials" session
                        Session["MenuMaster"] = _menus; //Bind the _menus list to MenuMaster session
                        Session["UserName"] = _loginCredentials.Usuario;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Por Favor ingrese credenciales validas!...";
                        return View();
                    }
                }
            }
            return View();
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        }
    }
}