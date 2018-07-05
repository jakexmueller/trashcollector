using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trashcollector.Startup))]
namespace trashcollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
