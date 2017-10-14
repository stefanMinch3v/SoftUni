using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookLy.Web.Startup))]
namespace BookLy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
