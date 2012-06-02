namespace Bartender.Entities
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Amount { get; set; }
		public int DrinkId { get; set; }
	}
}