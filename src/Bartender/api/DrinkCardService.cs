using System;
using Bartender.Repositories;
using DTO;
using ServiceStack.ServiceInterface;

namespace Bartender.Api
{
	public class DrinkCardService : RestServiceBase<DrinkCardRequest>
	{
		private readonly DrinkCardRepository repository;

		public DrinkCardService(DrinkCardRepository repository)
		{
			this.repository = repository;
		}

		public override object OnGet(DrinkCardRequest request)
		{
			if (request.DrinkCardId != Guid.Empty)
			{
				var drinkCard = repository.GetById(request.DrinkCardId);

				return drinkCard;
			}

			var card = repository.GetDrinkCardByType(request.CardType);

			return card;
		}

		public override object OnDelete(DrinkCardRequest request)
		{
			return base.OnDelete(request);
		}

		public override object OnPut(DrinkCardRequest request)
		{
			return base.OnPut(request);
		}
	}
}