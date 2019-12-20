using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PetAdote_Application.Configuration;
using PetAdote_Application.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PetAdote_Mvc.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<PetAdoteIdentityDbContext>(PetAdoteIdentityDbContext.Create);
            app.CreatePerOwinContext<ManagerUser>(ManagerUser.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            CultureInfo ci = new CultureInfo("pt-BR");
           
        }
    }
}