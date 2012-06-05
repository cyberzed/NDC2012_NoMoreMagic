using System;
using System.Collections.Generic;

namespace Entities
{
	public class DrinkCard
	{
		public DrinkCard()
		{
			Drinks = new List<Drink>();
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public DrinkCardType CardType { get; set; }
		public List<Drink> Drinks { get; set; }
	}
}