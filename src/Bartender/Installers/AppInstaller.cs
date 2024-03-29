using Bartender.api;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceStack.Configuration;
using ServiceStack.ServiceHost;

namespace Bartender.Installers
{
	internal class AppInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IContainerAdapter>().Instance(new WindsorContainerAdapter(container)));

			container.Register(Classes.FromAssemblyContaining<DrinkService>().BasedOn(typeof(IService<>)).WithService.DefaultInterfaces());

			container.Register(Component.For<ApiHost>().ImplementedBy<ApiHost>().LifestyleSingleton());
		}
	}
}