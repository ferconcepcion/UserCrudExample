using Autofac;
using System.Web.Http;
using UserCrudExample.Config;

namespace UserCrudExample.Controllers
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains the commun configuration for the all controllers
    /// </summary>
    public class BaseController : ApiController
    {
        private static IContainer _singletonContainer;

        protected static IContainer _container
        {
            get
            {
                if (_singletonContainer == null)
                {
                    _singletonContainer = AutofacConfig.GetContainerConfigured();
                }
                return _singletonContainer;
            }
        }
    }
}
