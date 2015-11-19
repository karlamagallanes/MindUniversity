using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MindUniversity.MidEvaluation.Startup))]
namespace MindUniversity.MidEvaluation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
