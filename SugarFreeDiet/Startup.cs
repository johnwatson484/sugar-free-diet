using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SugarFreeDiet.Startup))]
namespace SugarFreeDiet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
