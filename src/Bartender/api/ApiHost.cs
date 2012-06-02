using DTO;
using Funq;
using ServiceStack.WebHost.Endpoints;

namespace Bartender.api
{
	public class ApiHost : AppHostBase
	{
		public ApiHost() : base("Bartender Api Service", typeof (DrinkService).Assembly)
		{
		}

		public override void Configure(Container container)
		{
			SetConfig(new EndpointHostConfig {ServiceStackHandlerFactoryPath = "api"});

			Routes.Add<DrinkCardRequest>("/drinkcards");
		}
	}
}