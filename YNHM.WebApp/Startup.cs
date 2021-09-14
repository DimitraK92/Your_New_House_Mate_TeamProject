using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YNHM.WebApp.Startup))]
namespace YNHM.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
