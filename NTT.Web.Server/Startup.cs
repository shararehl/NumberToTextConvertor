using System.Reflection;
using System.Web.Http;
using AKQA.Common;
using AKQA.Common.Abstraction;
using AKQA.Common.Formatter;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AKQA.Web.Server.Startup))]
namespace AKQA.Web.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var config = new HttpConfiguration();

            configureRoute(config);

            var builder = new ContainerBuilder();
            builder.RegisterType<CustomEnglishWithDollarFormatter>().As<INumberToTextLanguageFormatter>();
            builder.Register((c, p) => new NumberToTextConvertor(c.Resolve<INumberToTextLanguageFormatter>())).As<INumberToTextConvertor>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            builder.RegisterWebApiFilterProvider(config);


            // Create and assign a dependency resolver for Web API to use.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

        }
        private void configureRoute(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                 name: "ApiFromConfig",
                 routeTemplate: "api/{request}",
                 defaults: new { controller = "ib", action = "process" }
             );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
