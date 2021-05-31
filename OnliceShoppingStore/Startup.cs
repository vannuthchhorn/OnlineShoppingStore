using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnliceShoppingStore.Startup))]
namespace OnliceShoppingStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
