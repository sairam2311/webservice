using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TSIIC.Startup))]
namespace TSIIC
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
