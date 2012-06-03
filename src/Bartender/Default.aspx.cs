using System;
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

			var drinkCardResponse = serviceClient.Send<DrinkCardResponse>(HttpMethod.Get, "/drinkcards",
			                                                              new DrinkCard {CardType = DrinkCardType.Afternoon});

			if (drinkCardResponse.Card != null)
			{
				serviceClient.Delete<object>(string.Format("/drinkcards/{0}", drinkCardResponse.Card.Id));
			}
		}
	}
}