using System;
using Bartender.Entities;
using Bartender.Repositories;
using ServiceStack.ServiceInterface;

namespace Bartender.Api
{
	public class DrinkService : ServiceBase<Drink>
	{
		private readonly DrinkRepository repository;

		public DrinkService(DrinkRepository repository)
		{
			this.repository = repository;
		}

		protected override object Run(Drink request)
		{
			if (request.Id != Guid.Empty)
			{
				var drink = repository.GetById(request.Id);

				return new DrinkResponse {Drinks = new[] {drink}};
			}

			var drinks = repository.GetAll();

			return new DrinkResponse {Drinks = drinks};
		}
	}
}