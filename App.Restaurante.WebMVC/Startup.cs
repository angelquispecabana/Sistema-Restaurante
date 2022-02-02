﻿using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(App.Restaurante.WebMVC.Startup))]

namespace App.Restaurante.WebMVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Usuario/Login"),
                ExpireTimeSpan = TimeSpan.FromDays(30)/*,
                LogoutPath = new PathString("Home/Index")*/
            });
        }
    }
}