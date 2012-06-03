using System;

namespace DTO
{
	public class DrinkCardRequest
	{
		public Guid DrinkCardId { get; set; }
		public DrinkCardType CardType { get; set; }
	}
}