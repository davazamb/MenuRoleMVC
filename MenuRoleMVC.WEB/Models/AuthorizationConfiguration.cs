using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MenuRoleMVC.WEB.Models
{

    public class AuthorizationConfiguration : ConfigurationSection
    {
        private static AuthorizationConfiguration _authorizationConfiguration
            = ConfigurationManager.GetSection("authorizationConfiguration") as AuthorizationConfiguration;

        public static AuthorizationConfiguration Section
        {
            get
            {
                return _authorizationConfiguration;
            }
        }

        [ConfigurationProperty("controllerAuthorizationMappings")]
        public ControllerAuthorizationConfigurationCollection ControllerAuthorizationMappings
        {
            get
            {
                return this["controllerAuthorizationMappings"] as ControllerAuthorizationConfigurationCollection;
            }
        }
    }
}