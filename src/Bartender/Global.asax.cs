using System;
using Bartender.Api;
using Bartender.Installers;
using Castle.Windsor;

namespace Bartender
{
	public class Global : System.Web.HttpApplication
	{
		private IWindsorContainer container;

		protected void Application_Start(object sender, EventArgs e)
		{
			InitializeContainer();

			new ApiHost().Init();
		}

		private void InitializeContainer()
		{
			container = new WindsorContainer();

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