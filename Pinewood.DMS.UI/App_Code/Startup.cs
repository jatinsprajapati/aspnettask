using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pinewood.DMS.UI.Startup))]
namespace Pinewood.DMS.UI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
