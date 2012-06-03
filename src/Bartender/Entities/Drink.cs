using System.Collections.Generic;

namespace Bartender.Entities
{
	public class Drink
	{
		public string Name { get; set; }
		public IEnumerable<Ingredient> Ingredients { get; set; }
	}
}