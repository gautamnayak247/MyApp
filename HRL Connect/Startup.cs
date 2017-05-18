using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRL_Connect.Startup))]
namespace HRL_Connect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
