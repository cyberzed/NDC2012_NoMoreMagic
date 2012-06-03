using System;

namespace Bartender.Entities
{
	public class DrinkCard
	{
		public Guid Id { get; set; }
		public DrinkCardType CardType { get; set; }
	}
}