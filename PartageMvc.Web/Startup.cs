using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartageMvc.Web.Startup))]
namespace PartageMvc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
