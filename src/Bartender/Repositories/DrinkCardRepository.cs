using System;
using System.Linq;
using DTO;
using Raven.Client;
using Raven.Client.Linq;

namespace Bartender.Repositories
{
	public class DrinkCardRepository
	{
		private readonly IDocumentSession session;

		public DrinkCardRepository(IDocumentSession session)
		{
			this.session = session;
		}

		public DrinkCard GetDrinkCardByType(DrinkCardType cardType)
		{
			var drinkCards = (from dc in session.Query<DrinkCard>() where dc.CardType == cardType select dc);

			if (drinkCards.Any())
			{
				return drinkCards.First();
			}
			else
			{
				return default(DrinkCard);
			}
		}

		public DrinkCard GetById(Guid drinkCardId)
		{
			throw new NotImplementedException();
		}
	}
}