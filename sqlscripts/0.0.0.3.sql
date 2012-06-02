CREATE TABLE DrinkCard
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	CardType SMALLINT NOT NULL
)

CREATE TABLE DrinkCardDrink
(
	DrinkCardId INT NOT NULL CONSTRAINT FK_DrinkCardDrinks_DrinkCard FOREIGN KEY (DrinkCardId) REFERENCES DrinkCard(Id),
	DrinkId INT NOT NULL CONSTRAINT FK_DrinkCardDrinks_Drink FOREIGN KEY (DrinkId) REFERENCES Drink(Id)
)

INSERT INTO Version(VersionNumber, CreateDate) VALUES ('0.0.0.3', GETDATE())