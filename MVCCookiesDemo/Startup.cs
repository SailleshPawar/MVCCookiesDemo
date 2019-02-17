using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCookiesDemo.Startup))]
namespace MVCCookiesDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
