using System;
using System.Linq;
using Bartender.Installers;
using Bartender.Repositories;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Entities;

namespace Bartender
{
	public class Global : System.Web.HttpApplication
	{
		private IWindsorContainer container;

		protected void Application_Start(object sender, EventArgs e)
		{
			InitializeContainer();

			EducateTheBartender();

			var apiHost = container.Resolve<ApiHost>();

			apiHost.Init();
		}

		private void EducateTheBartender()
		{
			var drinkRepository = container.Resolve<DrinkRepository>();

			var drinks = drinkRepository.GetAll();

			if (drinks.Any())
			{
				return;
			}

			var whiteRussian = new Drink
			                   	{
			                   		Name = "White Russian",
			                   		Ingredients = new[]
			                   		              	{
			                   		              		"50mL Vodka",
			                   		              		"20mL Coffee liqueur",
			                   		              		"30mL fresh cream"
			                   		              	}
			                   	};

			drinkRepository.Store(whiteRussian);

			var cubaLibre = new Drink
			                	{
			                		Name = "Cuba Libre",
			                		Ingredients = new[]
			                		              	{
			                		              		"100mL Cola",
			                		              		"50mL White rum"
			                		              	}
			                	};

			drinkRepository.Store(cubaLibre);

			var longIslandIcedTea = new Drink
			                        	{
			                        		Name = "Long Island Iced Tea",
			                        		Ingredients = new[]
			                        		              	{
			                        		              		"15mL Vodka",
			                        		              		"15mL Tequila",
			                        		              		"15mL White rum",
			                        		              		"15mL Triple sec",
			                        		              		"15mL Gin",
			                        		              		"25mL Lemon juice",
			                        		              		"30mL Comme syrup",
			                        		              		"Splash of coke"
			                        		              	}
			                        	};

			drinkRepository.Store(longIslandIcedTea);

			var mojito = new Drink
			             	{
			             		Name = "Mojito",
			             		Ingredients = new[]
			             		              	{
			             		              		"40mL White rum",
			             		              		"30 mL Fresh lime juice",
			             		              		"3 leaves of mint",
			             		              		"2 teaspoons sugar",
			             		              		"Soda water"
			             		              	}
			             	};

			drinkRepository.Store(mojito);

			var pinaColada = new Drink
			                 	{
			                 		Name = "Piña Colada",
			                 		Ingredients = new[]
			                 		              	{
			                 		              		"30mL White rum",
			                 		              		"30mL Cream of coocnut",
			                 		              		"90mL Pineapple juice"
			                 		              	}
			                 	};

			drinkRepository.Store(pinaColada);

			var manhattan = new Drink
			                	{
			                		Name = "Manhattan",
			                		Ingredients = new[]
			                		              	{
			                		              		"50mL Rye or Canadian whiskey",
			                		              		"20mL Sweet red vermouth",
			                		              		"Dash Angostura bitter",
			                		              		"Maraschino cherry"
			                		              	}
			                	};

			drinkRepository.Store(manhattan);

			var whiskeySour = new Drink
			                  	{
			                  		Name = "Whiskey sour",
			                  		Ingredients = new[]
			                  		              	{
			                  		              		"45mL Bourbon whiskey",
			                  		              		"30mL Fresh lemon juice",
			                  		              		"15mL Gomme syrup",
			                  		              		"Dash egg white"
			                  		              	}
			                  	};

			drinkRepository.Store(whiskeySour);
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