using System.Configuration;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Raven.Client;
using Raven.Client.Embedded;

namespace Bartender.Installers
{
	internal class RavenDbInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IDocumentStore>().Instance(CreateCustomDocumentStore()).LifestyleSingleton());
			container.Register(Component.For<IDocumentSession>().UsingFactoryMethod(CreateDocumentSession).LifestyleTransient());
		}

		private IDocumentStore CreateCustomDocumentStore()
		{
			var documentStore = new EmbeddableDocumentStore {DataDirectory = ConfigurationManager.AppSettings["RavenDataDir"]};

			documentStore.Initialize();

			return documentStore;
		}

		private IDocumentSession CreateDocumentSession(IKernel kernel)
		{
			var documentStore = kernel.Resolve<IDocumentStore>();

			return documentStore.OpenSession();
		}
	}
}