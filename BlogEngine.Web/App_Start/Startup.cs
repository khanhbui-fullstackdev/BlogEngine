using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Services.Description;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BlogEngine.Data;
using BlogEngine.Data.Infrastrutures;
using BlogEngine.Data.Repositories;
using BlogEngine.Service;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(BlogEngine.Web.App_Start.Startup))]

namespace BlogEngine.Web.App_Start
{
    // remmeber to create partial class Startup
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutoFac(app);
        }

        private void ConfigAutoFac(IAppBuilder app)
        {
            var containerBuilder = new ContainerBuilder();
            // Register your Web MVC constructor controllers.
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API constructor controllers.
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers


            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            containerBuilder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            containerBuilder.RegisterType<BlogEngineDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            //containerBuilder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            //containerBuilder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //containerBuilder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //containerBuilder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //containerBuilder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            // Repositories
            containerBuilder.RegisterAssemblyTypes(typeof(PostRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            containerBuilder.RegisterAssemblyTypes(typeof(PostService).Assembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//Set the MVC DependencyResolver

            // Web Api
            // Install-Package Microsoft.AspNet.WebApi.WebHost
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }       
    }
}
