DROP TABLE Ingredient
GO

CREATE TABLE Ingredient
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(60) NOT NULL,
	Amount NVARCHAR(60) NOT NULL,
	DrinkId INT CONSTRAINT FK_Ingredient_Drink FOREIGN KEY (DrinkId) REFERENCES Drink(Id)
)

INSERT INTO Version(VersionNumber, CreateDate) VALUES ('0.0.0.2', GETDATE())