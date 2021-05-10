using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SG_ASP_2.Startup))]
namespace SG_ASP_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
