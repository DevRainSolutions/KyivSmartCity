using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevRainSolutions.KyivSmartCity.New.Startup))]
namespace DevRainSolutions.KyivSmartCity.New
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
