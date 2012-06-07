using System;
using System.Net;
using Entities;
using Raven.Client;
using Raven.Client.Linq;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace Bartender.Api
{
	public class DrinkCardService : RestServiceBase<DrinkCard>
	{
		private readonly IDocumentSession session;

		public DrinkCardService(IDocumentSession session)
		{
			this.session = session;
		}

		public override object OnGet(DrinkCard request)
		{
			if (request.Id != Guid.Empty)
			{
				var drinkCard = session.Load<DrinkCard>(request.Id);

				return new DrinkCardResponse {Cards = new[] {drinkCard}};
			}

			var cards = (from dc in session.Query<DrinkCard>() select dc);

			return new DrinkCardResponse {Cards = cards};
		}

		public override object OnDelete(DrinkCard request)
		{
			session.Delete(request);

			return new HttpResult(HttpStatusCode.NoContent);
		}

		public override object OnPost(DrinkCard request)
		{
			session.Store(request);

			var response = new DrinkCardResponse {Cards = new[] {request}};

			return new HttpResult(response) {StatusCode = HttpStatusCode.Created};
		}

		public override object OnPut(DrinkCard request)
		{
			session.Store(request, request.Id);

			return new HttpResult(HttpStatusCode.NoContent);
		}
	}
}