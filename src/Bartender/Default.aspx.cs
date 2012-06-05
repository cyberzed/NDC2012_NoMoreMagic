using System;
using System.Web.UI;
using Entities;
using ServiceStack.ServiceClient.Web;

namespace Bartender
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				var serviceClient = new JsonServiceClient(Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)+"/api");

				var drinkCards = serviceClient.Get<DrinkCardResponse>("/drinkcards");

				drinkcardsRepeater.DataSource = drinkCards.Cards;
				drinkcardsRepeater.DataBind();
			}
		}
	}
}