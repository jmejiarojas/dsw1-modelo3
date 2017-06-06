using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APP_MVC_10.Startup))]
namespace APP_MVC_10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
