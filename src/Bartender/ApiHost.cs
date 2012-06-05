using Bartender.Api;
using Entities;
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

			//Yay, logging is really easy to setup
			LogManager.LogFactory = new NLogFactory();
		}

		public override void Configure(Container container)
		{
			//Custom location
			SetConfig(new EndpointHostConfig {ServiceStackHandlerFactoryPath = "api" /*,EnableFeatures = Feature.All.Remove(Feature.Csv)*/});

			//Custom serializing
			//DrinkCardFormat.Register(this);

			//Request filtering
			//RequestFilters.Add((req, res, obj) => LogManager.GetLogger(GetType()).Info(string.Format("UA: {0}", req.UserAgent)));

			Routes.Add<DrinkCard>("/drinkcards").Add<DrinkCard>("/drinkcards/{Id}");
			Routes.Add<Drink>("/drinks").Add<Drink>("/drinks/{Id}");
		}
	}
}