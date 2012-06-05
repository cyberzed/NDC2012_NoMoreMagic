using System;
using System.Collections.Generic;
using Entities;
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

		public IEnumerable<DrinkCard> GetAll()
		{
			return (from dc in session.Query<DrinkCard>() select dc);
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