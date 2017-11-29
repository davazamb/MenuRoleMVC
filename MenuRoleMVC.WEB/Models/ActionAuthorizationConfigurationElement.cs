using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MenuRoleMVC.WEB.Models
{

    public class ActionAuthorizationConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("action", IsRequired = true)]
        public string Action
        {
            get
            {
                return (string)this["action"];
            }
            set
            {
                this["action"] = value;
            }
        }

        [ConfigurationProperty("roles", IsRequired = true)]
        public string Roles
        {
            get
            {
                return (string)this["roles"];
            }
            set
            {
                this["roles"] = value;
            }
        }
    }
}