using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCExample.Startup))]
namespace MVCExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
