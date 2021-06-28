using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App_Site_Touristique.Startup))]
namespace App_Site_Touristique
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
