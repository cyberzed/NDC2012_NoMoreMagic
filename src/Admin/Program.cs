using System;
using System.Linq;
using Entities;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace Admin
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var apiUri = "http://localhost:59816/api";

			var serviceClient = new JsonServiceClient(apiUri);

			var response = serviceClient.Get<DrinkResponse>("/drinks");

			Console.WriteLine("Please enter the name of the new card");
			var drinkCard = new DrinkCard();

			drinkCard.Name = Console.ReadLine();

			var cardTypes = Enum.GetNames(typeof (DrinkCardType));
			var drinkCardTypes = string.Join(",", cardTypes);
			Console.WriteLine("Please enter the type of card ({0})", drinkCardTypes);

			drinkCard.CardType = (DrinkCardType) Enum.Parse(typeof (DrinkCardType), Console.ReadLine());

			Console.WriteLine("Drinks available:");
			var drinks = response.Drinks.ToList();
			for (var i = 0; i < drinks.Count(); i++)
			{
				Console.WriteLine("{0}: {1}", i, drinks[i].Name);
			}

			Console.WriteLine("Please enter which drinks should be on the new card, press c when done");

			var input = string.Empty;
			while (true)
			{
				if (input == null)
				{
					continue;
				}

				if (input.Equals("c"))
				{
					break;
				}

				int indx;
				if (int.TryParse(input, out indx))
				{
					if (indx <= drinks.Count)
					{
						drinkCard.Drinks.Add(drinks[indx]);
					}
				}

				input = Console.ReadLine();
			}

			var newCard = serviceClient.Post<DrinkCardResponse>("/drinkcards", drinkCard);

			if (newCard.Cards != null && newCard.Cards.Any())
			{
				var jsonCard = newCard.ToJson();

				Console.WriteLine(jsonCard);
			}

			Console.WriteLine("Press a key to end.");
			Console.ReadKey();
		}
	}
}