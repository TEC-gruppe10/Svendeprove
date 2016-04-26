using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceDesk.Startup))]
namespace ServiceDesk
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
