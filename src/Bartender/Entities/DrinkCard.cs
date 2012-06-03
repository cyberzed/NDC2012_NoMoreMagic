using System;
using System.Collections.Generic;

namespace Bartender.Entities
{
	public class DrinkCard
	{
		public Guid Id { get; set; }
		public DrinkCardType CardType { get; set; }
		public IEnumerable<Drink> Drinks { get; set; }
	}
}