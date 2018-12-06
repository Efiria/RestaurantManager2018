/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Recette
------------------------------------------------------------*/
CREATE TABLE Recette(
	ID    INT IDENTITY (1,1) NOT NULL ,
	Nom   TEXT  NOT NULL  ,
	CONSTRAINT Recette_PK PRIMARY KEY (ID)
);


/*------------------------------------------------------------
-- Table: StockIngredients
------------------------------------------------------------*/
CREATE TABLE StockIngredients(
	ID          INT IDENTITY (1,1) NOT NULL ,
	Nom         TEXT  NOT NULL ,
	Stock       INT  NOT NULL ,
	Categorie   TEXT  NOT NULL  ,
	CONSTRAINT StockIngredients_PK PRIMARY KEY (ID)
);


/*------------------------------------------------------------
-- Table: IngredientRecette
------------------------------------------------------------*/
CREATE TABLE IngredientRecette(
	ID             INT  NOT NULL ,
	Quantite       INT  NOT NULL ,
	IDrecette      INT  NOT NULL ,
	IDingredient   INT  NOT NULL ,
	ID_Recette     INT  NOT NULL  ,
	CONSTRAINT IngredientRecette_PK PRIMARY KEY (ID) ,
	CONSTRAINT IngredientRecette_AK UNIQUE (IDrecette,IDingredient)

	,CONSTRAINT IngredientRecette_Recette_FK FOREIGN KEY (ID_Recette) REFERENCES Recette(ID)
);


/*------------------------------------------------------------
-- Table: ReservationTable
------------------------------------------------------------*/
CREATE TABLE ReservationTable(
	ID               INT IDENTITY (1,1) NOT NULL ,
	NomReservation   TEXT  NOT NULL ,
	NbPersonne       INT  NOT NULL ,
	Horaire          INT  NOT NULL  ,
	CONSTRAINT ReservationTable_PK PRIMARY KEY (ID)
);


/*------------------------------------------------------------
-- Table: Materiel
------------------------------------------------------------*/
CREATE TABLE Materiel(
	ID         INT IDENTITY (1,1) NOT NULL ,
	Nom        TEXT  NOT NULL ,
	Quantite   INT  NOT NULL  ,
	CONSTRAINT Materiel_PK PRIMARY KEY (ID)
);



