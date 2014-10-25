using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(King.Mapper.MVC.Startup))]
namespace King.Mapper.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}