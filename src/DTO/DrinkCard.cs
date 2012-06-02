using System.Collections.Generic;

namespace DTO
{
	public class DrinkCard
	{
		public DrinkCardType CardType { get; set; }
		public IEnumerable<Drink> Drinks { get; set; }
	}

	public class Drink
	{
		public string Name { get; set; }
		public IEnumerable<Ingredient> Ingredients { get; set; }
	}

	public class Ingredient
	{
		public string Name { get; set; }
	}
}