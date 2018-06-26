
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BlogEngine.Data;
using BlogEngine.Data.Infrastrutures;
using BlogEngine.Data.Repositories;
using BlogEngine.Service;
using Microsoft.Owin;
using Owin;
using System.Reflection;

[assembly: OwinStartup(typeof(BlogEngine.Web.App_Start.Startup))]

namespace BlogEngine.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutoFac(app);
        }

        private void ConfigAutoFac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Register your Web MVC constructor controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API constructor controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register UnitOfWork and DbFactory
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<BlogEngineDbContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(PostRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(PostService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
        }
    }
}
