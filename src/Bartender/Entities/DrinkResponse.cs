using System.Collections.Generic;

namespace Bartender.Entities
{
	public class DrinkResponse
	{
		public IEnumerable<Drink> Drinks { get; set; }
	}
}