using Bartender.Repositories;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bartender.Installers
{
	internal class AppInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromAssemblyContaining<DrinkCardRepository>().InSameNamespaceAs<DrinkCardRepository>().WithService.DefaultInterfaces());
		}
	}
}