using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Filmotekica.Startup))]
namespace Filmotekica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
