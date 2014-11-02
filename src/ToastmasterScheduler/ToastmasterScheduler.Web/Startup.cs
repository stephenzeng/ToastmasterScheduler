using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ToastmasterScheduler.Web.Startup))]

namespace ToastmasterScheduler.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
