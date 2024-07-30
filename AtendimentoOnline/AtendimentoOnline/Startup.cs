using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtendimentoOnline.Startup))]
namespace AtendimentoOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
