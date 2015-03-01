using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YumSale.Startup))]
namespace YumSale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
