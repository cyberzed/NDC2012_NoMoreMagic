﻿using System;
using Entities;
using Raven.Client;
using Raven.Client.Linq;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bartender.api
{
	public class DrinkService : ServiceBase<Drink>
	{
		private readonly IDocumentSession session;

		public DrinkService(IDocumentSession session)
		{
			this.session = session;
		}

		protected override object Run(Drink request)
		{
			if (request.Id != Guid.Empty)
			{
				var drink = session.Load<Drink>(request.Id);

				return new DrinkResponse {Drinks = new[] {drink}};
			}

			var drinks = (from d in session.Query<Drink>() select d).ToList();

			return new DrinkResponse {Drinks = drinks};
		}
	}
}