using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(dvvWeb.Startup))]
namespace dvvWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}