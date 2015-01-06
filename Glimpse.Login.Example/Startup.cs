using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Glimpse.Login.Example.Startup))]
namespace Glimpse.Login.Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
