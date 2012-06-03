using System;
using System.Net;
using Bartender.Entities;
using Bartender.Repositories;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace Bartender.Api
{
	public class DrinkCardService : RestServiceBase<DrinkCard>
	{
		private readonly DrinkCardRepository repository;

		public DrinkCardService(DrinkCardRepository repository)
		{
			this.repository = repository;
		}

		public override object OnGet(DrinkCard request)
		{
			if (request.Id != Guid.Empty)
			{
				var drinkCard = repository.GetById(request.Id);

				return new DrinkCardResponse {Card = drinkCard};
			}

			var card = repository.GetDrinkCardByType(request.CardType);

			return new DrinkCardResponse {Card = card};
		}

		public override object OnDelete(DrinkCard request)
		{
			repository.Delete(request);

			return new HttpResult(HttpStatusCode.NoContent);
		}

		public override object OnPost(DrinkCard request)
		{
			var card = repository.Store(request);

			var response = new DrinkCardResponse {Card = card};

			return new HttpResult(response) {StatusCode = HttpStatusCode.Created};
		}

		public override object OnPut(DrinkCard request)
		{
			repository.Store(request);

			return new HttpResult(HttpStatusCode.NoContent);
		}
	}
}