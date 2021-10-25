using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DLCMS.Startup))]
namespace DLCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
