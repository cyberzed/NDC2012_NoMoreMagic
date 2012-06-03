using System;
using System.Collections.Generic;

namespace Bartender.Entities
{
	public class Drink
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public IEnumerable<Ingredient> Ingredients { get; set; }
	}
}