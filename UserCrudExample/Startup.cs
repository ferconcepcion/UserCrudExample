using Owin;

//[assembly: OwinStartup(typeof(UserCrudExample.Startup))]

namespace UserCrudExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
