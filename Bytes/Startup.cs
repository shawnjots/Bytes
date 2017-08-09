using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bytes.Startup))]
namespace Bytes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
