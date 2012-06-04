using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Bartender.Entities;
using ServiceStack.ServiceClient.Web;

namespace Bartender
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var serviceClient = new JsonServiceClient(Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped) + "/api");

			var drinkCardResponse = serviceClient.Get<DrinkCardResponse>("/drinkcards");

			if (drinkCardResponse.Cards.Any())
			{
				foreach (var drinkCard in drinkCardResponse.Cards)
				{
					serviceClient.Delete<object>(string.Format("/drinkcards/{0}", drinkCard.Id));
				}
			}

			var drinks = serviceClient.Get<IEnumerable<Drink>>("/drinks");
		}
	}
}