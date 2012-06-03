using System;
using AutoMapper;
using Bartender.Repositories;
using DTO;
using ServiceStack.ServiceInterface;

namespace Bartender.Api
{
	public class DrinkCardService : RestServiceBase<DrinkCardRequest>
	{
		private readonly IMappingEngine mapper;
		private readonly DrinkCardRepository repository;

		public DrinkCardService(DrinkCardRepository repository, IMappingEngine mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public override object OnGet(DrinkCardRequest request)
		{
			if (request.DrinkCardId != Guid.Empty)
			{
				var drinkCard = repository.GetById(request.DrinkCardId);

				var dtoDrinkCard = mapper.Map<Entities.DrinkCard, DrinkCard>(drinkCard);

				return dtoDrinkCard;
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
}}