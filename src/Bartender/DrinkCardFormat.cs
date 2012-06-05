using System;
using System.IO;
using Entities;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace Bartender
{
	public class DrinkCardFormat
	{
		private const string DrinkCardContentType = "text/x-drinkcard";

		public static void Register(IAppHost appHost)
		{
			appHost.ContentTypeFilters.Register(DrinkCardContentType, SerializeToStream, (t, s) => { throw new NotImplementedException(); });
		}

		public static void SerializeToStream(IRequestContext context, object response, Stream stream)
		{
			var drinkCardResponse = response as DrinkCardResponse;

			if (drinkCardResponse != null)
			{
				using (var writer = new StreamWriter(stream))
				{
					foreach (var drinkCard in drinkCardResponse.Cards)
					{
						writer.WriteLine("Id: {0}", drinkCard.Id);
						writer.WriteLine("Name: {0}", drinkCard.Name);
						writer.WriteLine("CardType: {0}", drinkCard.CardType);

						writer.WriteLine("Drinks:");
						foreach (var drink in drinkCard.Drinks)
						{
							writer.WriteLine("\t{0}", drink.Name);
						}

						writer.WriteLine();
					}
				}
			}
		}
	}
}