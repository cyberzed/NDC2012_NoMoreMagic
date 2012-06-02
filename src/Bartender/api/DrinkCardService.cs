using System.Configuration;
using System.Linq;
using DTO;
using Raven.Client.Embedded;
using Raven.Client.Linq;
using ServiceStack.ServiceInterface;

namespace Bartender.api
{
	public class DrinkCardService : ServiceBase<DrinkCardRequest>
	{
		protected override object Run(DrinkCardRequest request)
		{
			using (var documentStore = new EmbeddableDocumentStore {DataDirectory = ConfigurationManager.AppSettings["RavenDataDir"]}.Initialize())
			{
				using (var session = documentStore.OpenSession())
				{
					var drinkCards = (from dc in session.Query<DrinkCard>() where dc.CardType == request.CardType select dc);

					if (drinkCards.Any())
					{
						return drinkCards.First();
					}
				}
			}

			return default(DrinkCard);
		}
	}
}