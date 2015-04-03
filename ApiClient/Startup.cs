using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApiClient.Startup))]
namespace ApiClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
