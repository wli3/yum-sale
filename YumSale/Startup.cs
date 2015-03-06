using Microsoft.Owin;
using Owin;
using YumSale;

[assembly: OwinStartup(typeof (Startup))]

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