using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Project_Server.Startup))]
namespace Web_Project_Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
