using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bartender.Installers
{
	internal class AutoMapperInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<ConfigurationStore>().ImplementedBy<ConfigurationStore>().OnlyNewServices().DependsOn(
					Property.ForKey<ITypeMapFactory>().Eq(new TypeMapFactory()),
					Property.ForKey<IEnumerable<IObjectMapper>>().Eq(MapperRegistry.AllMappers())),
				Component.For<IConfigurationProvider>()
					.OnlyNewServices()
					.UsingFactoryMethod(kernel => kernel.Resolve<ConfigurationStore>()),
				Component.For<IConfiguration>()
					.OnlyNewServices()
					.UsingFactoryMethod(kernel => kernel.Resolve<ConfigurationStore>()),
				Component.For<IMappingEngine>()
					.OnlyNewServices()
					.ImplementedBy<MappingEngine>());

			//container.Register(Classes.FromAssemblyContaining<AutoMapperInstaller>().BasedOn<Profile>().WithService.Base());
		}
	}
}