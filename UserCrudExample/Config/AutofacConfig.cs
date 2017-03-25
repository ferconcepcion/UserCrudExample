using Autofac;
using UserCrudExample.Model;
using UserCrudExample.Repositories;

namespace UserCrudExample.Config
{
    /// <summary>
    /// UserCrudExample
    /// Author: Fernando Concepción Gutiérrez
    /// http://www.fconcepcion.com
    /// 
    /// This class contains the Autofac´s config
    /// </summary>
    public static class AutofacConfig
    {
        public static IContainer GetContainerConfigured()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<UserContext>().As<IUserContext>().InstancePerDependency();
            
            return builder.Build();
        }
    }
}