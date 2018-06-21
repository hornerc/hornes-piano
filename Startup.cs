using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleHornesPiano.Startup))]
namespace SimpleHornesPiano
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
