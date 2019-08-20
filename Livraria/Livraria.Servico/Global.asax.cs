using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

//incluidos
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using Livraria.Negocio.Contrato;
using Livraria.Negocio.Dominio;
using Livraria.Negocio.Especificacoes;
using Livraria.Negocio.Validacoes;
using Livraria.Repositorio.Contrato;
using Livraria.Repositorio.Persistencia;




namespace Livraria.Servico
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Create the container as usual.
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();


            // Register your types, for instance using the scoped lifestyle:
            //== vincula a interface com a classe
            container.Register<ILivroNegocio, LivroNegocio>(Lifestyle.Scoped);
            container.Register<ILivroRep, LivroRep>(Lifestyle.Scoped);
            container.Register<ILivroEspec, LivroEspec>(Lifestyle.Scoped);
            container.Register<ILivroValidacao, LivroValidacao>(Lifestyle.Scoped);
            //-----------------------------------------------------------------

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            // Here your usual Web API configuration stuff.
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}
