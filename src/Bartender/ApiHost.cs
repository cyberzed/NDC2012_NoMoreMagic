using Bartender.Api;
using DTO;
using Funq;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using ServiceStack.WebHost.Endpoints;

namespace Bartender
{
	public class ApiHost : AppHostBase
	{
		public ApiHost(IContainerAdapter containerAdapter) : base("Bartender Api Service", typeof (DrinkService).Assembly)
		{
			Container.Adapter = containerAdapter;

			LogManager.LogFactory = new NLogFactory();
		}

		public override void Configure(Container container)
		{
			SetConfig(new EndpointHostConfig {ServiceStackHandlerFactoryPath = "api"});

			Routes.Add<DrinkCardRequest>("/drinkcards").Add<DrinkCardRequest>("/drinkcards/{DrinkCardId}");
			Routes.Add<DrinkRequest>("/drinks").Add<DrinkRequest>("/drinks/{DrinkId}");
		}
	}
}