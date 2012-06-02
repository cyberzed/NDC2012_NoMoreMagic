using System;
using System.Configuration;
using System.Linq;
using DTO;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.ServiceInterface;

namespace Bartender.api
{
	public class DrinkCardService : ServiceBase<DrinkCardRequest>
	{
		private readonly OrmLiteConnectionFactory connectionFactory =
			new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["DB"].ConnectionString, SqlServerOrmLiteDialectProvider.Instance);

		protected override object Run(DrinkCardRequest request)
		{
			try
			{
				var drinkCards = connectionFactory.Exec(dbCmd => dbCmd.Select<DrinkCard>(q => q.CardType == request.CardType));

				if (drinkCards.Any())
				{
					return drinkCards.First();
				}
			}
			catch (Exception e)
			{

				throw;
			}

			return new DrinkCard();
		}
	}
}