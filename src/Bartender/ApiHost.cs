using System.Reflection;
using Entities;
using Funq;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.Logging.Support.Logging;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.Common;

namespace Bartender
{
	public class ApiHost:AppHostBase
	{
		public ApiHost(IContainerAdapter adapter) : base("NDC DrinkCard Service", typeof(ApiHost).Assembly)
		{
			Container.Adapter = adapter;
		}

		public override void Configure(Container container)
		{
			SetConfig(new EndpointHostConfig {ServiceStackHandlerFactoryPath = "api",EnableFeatures = Feature.All.Remove(Feature.Csv)});

			DrinkCardFormat.Register(this);

			Routes.Add<DrinkCard>("/drinkcards").Add<DrinkCard>("/drinkcards/{Id}");
			Routes.Add<Drink>("/drinks").Add<Drink>("/drinks/{Id}");
		}
	}
}