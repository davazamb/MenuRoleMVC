using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuRoleMVC.WEB.Models
{
    /// <summary>
    /// Authorization attribute for an MVC controller
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] _rolesArray;
        private string _authorizationGroupName;

        /// <summary>
        /// 
        /// </summary>
        public string AccessDeniedController { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccessDeniedAction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ControllerAuthorizeAttribute()
        {
            AccessDeniedController = ConfigurationManager.AppSettings["DefaultAccessDeniedController"] ??

"AccessDenied";
            AccessDeniedAction = ConfigurationManager.AppSettings["DefaultAccessDeniedAction"] ?? "Index";
            _authorizationGroupName = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] RolesArray
        {
            get
            {
                return _rolesArray;
            }
            set
            {
                _rolesArray = value;
                this.Roles = string.Join(",", _rolesArray);
            }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            // Get any controller specific role mappings
            var controllerRoleMappings = AuthorizationConfiguration.Section.ControllerAuthorizationMappings.Where(e

=> e.Controller == controllerName).FirstOrDefault();

            if (controllerRoleMappings != null && !string.IsNullOrEmpty(controllerRoleMappings.Roles))
            {
                this.RolesArray = controllerRoleMappings.Roles.Split(',');
            }

            //
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
            {

                Controller = AccessDeniedController,
                Action = AccessDeniedAction,
                Roles = Roles
            }));
        }
    }
}