using System;
using System.Net;
using Entities;
using Raven.Client;
using Raven.Client.Linq;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;
using System.Linq;

namespace Bartender.api
{
	public class DrinkCardService:RestServiceBase<DrinkCard>
	{
		private readonly IDocumentSession session;

		public DrinkCardService(IDocumentSession session)
		{
			this.session = session;
		}

		public override object OnGet(DrinkCard request)
		{
			if(request.Id!=Guid.Empty)
			{
				var drinkCard = session.Load<DrinkCard>(request.Id);

				return new DrinkCardResponse {Cards = new[] {drinkCard}};
			}

			var drinkCards = (from dc in session.Query<DrinkCard>() select dc).ToList();

			return new DrinkCardResponse {Cards = drinkCards};
		}

		public override object OnPost(DrinkCard request)
		{
			session.Store(request);

			session.SaveChanges();

			return new HttpResult(new DrinkCardResponse{Cards = new []{request}}) {StatusCode = HttpStatusCode.Created};
		}
	}
}