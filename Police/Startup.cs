using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Police.Startup))]
namespace Police
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
