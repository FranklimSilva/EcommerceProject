using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerceProject.Startup))]
namespace ECommerceProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
