using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenVanKhai_lab456.Startup))]
namespace NguyenVanKhai_lab456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
