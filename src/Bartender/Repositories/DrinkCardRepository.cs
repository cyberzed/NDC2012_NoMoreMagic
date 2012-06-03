using System;
using System.Linq;
using Bartender.Entities;
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
			var drinkCard = session.Load<DrinkCard>(drinkCardId);

			return drinkCard;
		}

		public DrinkCard Store(DrinkCard drinkCard)
		{
			if (drinkCard.Id == Guid.Empty)
			{
				session.Store(drinkCard);
			}
			else
			{
				session.Store(drinkCard, drinkCard.Id);
			}

			session.SaveChanges();

			return session.Load<DrinkCard>(drinkCard.Id);
		}

		public void Delete(DrinkCard drinkCard)
		{
			var card = session.Load<DrinkCard>(drinkCard.Id);

			if (card != null)
			{
				session.Delete(card);

				session.SaveChanges();
			}
		}
	}
}