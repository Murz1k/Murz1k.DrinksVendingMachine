using Microsoft.Owin;
using Murz1k.DrinksVendingMachine.Models;
using Murz1k.DrinksVendingMachine.Utilities;
using Owin;

[assembly: OwinStartupAttribute(typeof(Murz1k.DrinksVendingMachine.Startup))]
namespace Murz1k.DrinksVendingMachine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IoCProvider.AddComponent<DrinksVendingContext>();

            ConfigureAuth(app);
        }
    }
}
