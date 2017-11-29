using System;
using System.Web.Mvc;
using MvcAuthorization;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(MenuRoleMVC.WEB.App_Start.MvcAuthorization), "PreStart")]

namespace MenuRoleMVC.WEB.App_Start
{
    public static class MvcAuthorization
    {
        public static void PreStart()
        {
            GlobalFilters.Filters.Add(new AuthorizeFilter());
        }
    }
}