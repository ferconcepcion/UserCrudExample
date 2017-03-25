using Autofac;
using UserCrudExample.Repositories;
using UserCrudExample.Tests.Mock;

namespace UserCrudExample.Tests.Config
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains the Autofac´s config for test
    /// </summary>
    public static class AutofacConfig
    {
        public static IContainer GetContainerConfigured()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MockRepository>().As<IUserRepository>().InstancePerDependency();

            return builder.Build();
        }
    }
}
