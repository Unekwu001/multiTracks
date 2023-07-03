using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;


namespace MultiTracks_API
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//Autofac Dependency Registration

			// Configure Autofac container
			var container = AutofacConfig.ConfigureContainer();

			// Create the resolver for Web API dependencies
			var resolver = new AutofacWebApiDependencyResolver(container);

			// Configure Web API with the resolver
			GlobalConfiguration.Configuration.DependencyResolver = resolver;

		}
	}
}
