using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MAFRANFER.Startup))]
namespace MAFRANFER
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
