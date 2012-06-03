using System;
using Bartender.Installers;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace Bartender
{
	public class Global : System.Web.HttpApplication
	{
		private IWindsorContainer container;

		protected void Application_Start(object sender, EventArgs e)
		{
			InitializeContainer();

			var apiHost = container.Resolve<ApiHost>();

			apiHost.Init();
		}

		private void InitializeContainer()
		{
			container = new WindsorContainer();

			container.AddFacility<LoggingFacility>(f => f.UseNLog());

			container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

			container.Install(
				new RavenDbInstaller(),
				new AppInstaller()
				);
		}

		protected void Application_Error(object sender, EventArgs e)
		{
		}

		protected void Application_End(object sender, EventArgs e)
		{
		}
	}
}