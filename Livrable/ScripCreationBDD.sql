/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Recette
------------------------------------------------------------*/
CREATE TABLE Recette(
	ID     INT IDENTITY (1,1) NOT NULL ,
	Nom    VARCHAR(50)  NOT NULL ,
	Prix   INT  NOT NULL  ,
	CONSTRAINT Recette_PK PRIMARY KEY (ID)
);
INSERT INTO Recette (Nom, Prix) VALUES ('Endive aux Noix', 11), ('Compote de Pomme', 6);

/*------------------------------------------------------------
-- Table: StockIngredients
------------------------------------------------------------*/
CREATE TABLE StockIngredients(
	ID          INT IDENTITY (1,1) NOT NULL ,
	Nom         VARCHAR(50)  NOT NULL ,
	Stock       INT  NOT NULL ,
	Categorie   VARCHAR(50)  NOT NULL  ,
	CONSTRAINT StockIngredients_PK PRIMARY KEY (ID)
);

INSERT INTO StockIngredients (Nom, Stock, Categorie) VALUES ('Endive', 20, 'Legume'), ('Noix', 21, 'Legume'), ('Pomme', 16, 'Fruit');

/*------------------------------------------------------------
-- Table: IngredientRecette
------------------------------------------------------------*/
CREATE TABLE IngredientRecette(
	ID             INT  NOT NULL ,
	NomRecette     VARCHAR(50)  NOT NULL , 
	NomIngredient  VARCHAR(50)  NOT NULL ,
	Quantite       INT  NOT NULL ,
	CONSTRAINT IngredientRecette_PK PRIMARY KEY (ID)
);
INSERT INTO IngredientRecette (ID, NomRecette, NomIngredient, Quantite) VALUES (1,'Endive aux Noix', 'Endive', 2), (2,'Endive aux Noix', 'Noix', 3), (3,'Compote de Pomme', 'Pomme', 3);


/*------------------------------------------------------------
-- Table: ReservationTable
------------------------------------------------------------*/
CREATE TABLE ReservationTable(
	ID               INT IDENTITY (1,1) NOT NULL ,
	NomReservation   VARCHAR(50)  NOT NULL ,
	NbPersonne       INT  NOT NULL ,
	Horaire          INT  NOT NULL  ,
	CONSTRAINT ReservationTable_PK PRIMARY KEY (ID)
);


/*------------------------------------------------------------
-- Table: Materiel
------------------------------------------------------------*/
CREATE TABLE Materiel(
	ID         INT IDENTITY (1,1) NOT NULL ,
	Nom        VARCHAR(50)  NOT NULL ,
	Quantite   INT  NOT NULL  ,
	CONSTRAINT Materiel_PK PRIMARY KEY (ID)
);


/*------------------------------------------------------------
-- Table: ComptaCommande
------------------------------------------------------------*/
CREATE TABLE ComptaCommande(
	ID                INT IDENTITY (1,1) NOT NULL ,
	IDRecette         INT  NOT NULL ,
	NomRecette        VARCHAR(50)  NOT NULL ,
	QuantiteRecette   INT  NOT NULL  ,
	CONSTRAINT ComptaCommande_PK PRIMARY KEY (ID)
);


CREATE TABLE EtapeRecette(
	ID 				INT IDENTITY (1,1) NOT NULL ,
	NomRecette      VARCHAR(50) NOT NULL ,
	NbEtape			INT NOT NULL ,
	Description   	VARCHAR(250) NOT NULL ,
	Action			VARCHAR(50) NOT NULL ,
	Temps				INT NOT NULL , 
	CONSTRAINT EtapeRecette_PK PRIMARY KEY (ID)
);

INSERT INTO EtapeRecette (NomRecette, NbEtape, Description, Action, Temps) 
VALUES ('Endive aux Noix', 1, 'Découpez les endives en tranche', 'Decoupe', 10),
 ('Endive aux Noix', 2, 'Cassez les noix en morceaux', 'Decoupe', 20), 
 ('Endive aux Noix', 3, 'Melangez les endives et les noix', 'Melange', 25);