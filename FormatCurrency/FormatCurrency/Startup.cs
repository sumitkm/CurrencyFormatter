using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormatCurrency.Startup))]
namespace FormatCurrency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
