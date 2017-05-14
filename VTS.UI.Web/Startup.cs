using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VTS.UI.Web.Startup))]
namespace VTS.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
