using System;
using System.Web.UI;
using DTO;
using ServiceStack.ServiceClient.Web;

namespace Bartender
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var serviceClient = new JsonServiceClient(Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped) +"/api");

			var drinkCard = serviceClient.Send<DrinkCard>(HttpMethod.Get, "/drinkcards", null);
		}
	}
}