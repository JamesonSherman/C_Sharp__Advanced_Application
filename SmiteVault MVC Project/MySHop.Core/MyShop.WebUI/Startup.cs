using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShop.WebUI.Startup))]
namespace MyShop.WebUI
{
    public partial class Startup
    {
        //standard startup configure auth for the IappBuilder.
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
