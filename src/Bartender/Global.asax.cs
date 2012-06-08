using System;
using System.Linq;
using Bartender.Installers;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Entities;
using Raven.Client;
using Raven.Client.Linq;
using ServiceStack.MiniProfiler;

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
			var session = container.Resolve<IDocumentSession>();

			var anyDrinks = (from d in session.Query<Drink>() select d).Any();

			if (anyDrinks)
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

			session.Store(whiteRussian);

			var cubaLibre = new Drink
			                	{
			                		Name = "Cuba Libre",
			                		Ingredients = new[]
			                		              	{
			                		              		"100mL Cola",
			                		              		"50mL White rum"
			                		              	}
			                	};

			session.Store(cubaLibre);

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

			session.Store(longIslandIcedTea);

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

			session.Store(mojito);

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

			session.Store(pinaColada);

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

			session.Store(manhattan);

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

			session.Store(whiskeySour);

			session.SaveChanges();
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

		protected void Application_BeginRequest(object src, EventArgs e)
		{
			if (Request.IsLocal)
			{
				Profiler.Start();
			}
		}

		protected void Application_EndRequest(object src, EventArgs e)
		{
			Profiler.Stop();
		}
	}
}