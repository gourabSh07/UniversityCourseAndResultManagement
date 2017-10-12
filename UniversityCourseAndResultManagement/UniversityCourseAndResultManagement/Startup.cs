using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityCourseAndResultManagement.Startup))]
namespace UniversityCourseAndResultManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
