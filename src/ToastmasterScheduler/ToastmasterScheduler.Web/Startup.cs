using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToastmasterScheduler.Web.Startup))]
namespace ToastmasterScheduler.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
