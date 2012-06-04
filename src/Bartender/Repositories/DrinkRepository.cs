using System;
using System.Collections.Generic;
using Bartender.Entities;
using Raven.Client;
using Raven.Client.Linq;

namespace Bartender.Repositories
{
	public class DrinkRepository
	{
		private readonly IDocumentSession session;

		public DrinkRepository(IDocumentSession session)
		{
			this.session = session;
		}

		public IEnumerable<Drink> GetAll()
		{
			return (from d in session.Query<Drink>() select d);
		}

		public Drink GetById(Guid id)
		{
			return session.Load<Drink>(id);
		}

		public Drink Store(Drink drink)
		{
			if (drink.Id == Guid.Empty)
			{
				session.Store(drink);
			}
			else
			{
				session.Store(drink, drink.Id);
			}

			session.SaveChanges();

			return session.Load<Drink>(drink.Id);
		}
	}
}