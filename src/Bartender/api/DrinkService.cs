using DTO;
using ServiceStack.ServiceInterface;

namespace Bartender.Api
{
	public class DrinkService : ServiceBase<DrinkRequest>
	{
		protected override object Run(DrinkRequest request)
		{
			throw new System.NotImplementedException();
		}
	}
}