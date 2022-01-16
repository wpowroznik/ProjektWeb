using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektWeb.Startup))]
namespace ProjektWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
