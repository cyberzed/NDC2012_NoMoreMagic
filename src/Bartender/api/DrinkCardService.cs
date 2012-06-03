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
			if( request.DrinkCardId!=default(int))
			{}

			var drinkCard = repository.GetDrinkCardByType(request.CardType);

			return drinkCard;
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