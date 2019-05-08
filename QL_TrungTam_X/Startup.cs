using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QL_TrungTam_X.Startup))]
namespace QL_TrungTam_X
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
