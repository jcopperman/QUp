using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QUp.Web.Startup))]
namespace QUp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
