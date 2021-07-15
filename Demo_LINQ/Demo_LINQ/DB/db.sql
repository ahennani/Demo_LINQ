--- CREATE DATABASE
		CREATE DATABASE Demo_LINQ
		GO
		
--- USE DATABASE
		USE Demo_LINQ
		GO

--- Department --- (Num_Department, Department_Name, Lieu)  
	--- CREATE
		CREATE TABLE Department (
								   Num_Department VARCHAR(50) NOT NULL,
								   Name_Department VARCHAR(50) NOT NULL,
								   Lieu VARCHAR(50) NOT NULL,

								   PRIMARY KEY (Num_Department)
								 )
		GO

	--- INSERT
		INSERT INTO Department VALUES ('D10', 'Administration', 'Rabat'),
									  ('D20', 'IT', 'Casablanca'),
									  ('D30', 'Human Resources', 'Sela'),
									  ('D40', 'Public Relations', 'Nador'),
									  ('D50', 'Marketing', 'Ouarzazate'),
									  ('D60', 'Executive', 'Tinghir'),
									  ('D70', 'Finance', 'Agadir'),
									  ('D80', 'Sales', 'Titouan'),
									  ('D90', 'Control And Credit', 'El-Housaima'),
									  ('D100', 'Treasury', 'Taza')
		GO
	
--- Employe --- (Matricule, Employe_Name, Poste,  ID_Sup, Salaire, Num_Department)  
	--- CREATE
		CREATE TABLE Employe(
								 Matricule VARCHAR(50) NOT NULL,
								 Name_Employe VARCHAR(50) NOT NULL,
								 Poste VARCHAR(50) NOT NULL,
								 ID_Sup VARCHAR(50) NULL,
								 Salaire MONEY NOT NULL,
								 Num_Department VARCHAR(50) NOT NULL,

								 PRIMARY KEY (Matricule),
								 FOREIGN KEY (ID_Sup) REFERENCES Employe(Matricule),
								 FOREIGN KEY (Num_Department) REFERENCES Department(Num_Department)
							)
		GO

	--- INSERT
		INSERT INTO Employe VALUES('101', 'NKOCHHAR', 'Project Manager', NULL , 40000 , 'D10'),
								  ('102', 'DAUSTIN', 'President of Sales', '101', 9000 , 'D80'),
								  ('103', 'VPATABAL', 'Cashier', '102', 6000 , 'D80'),
								  ('104', 'DLORENTZ', 'Store Manager', '101', 12000 , 'D80'),
								  ('105', 'NGREENBE', 'Web Developer', NULL, 5000 , 'D20'),
								  ('106', 'DFAVIET', 'Back End Developer', '101', 20000 , 'D20'),
								  ('107', 'JCHEN', 'Computer Programmer', '106', 6500 , 'D20'),
								  ('108', 'ISCIARRA', 'Programmer', '102', 7000 , 'D20'),
								  ('109', 'JMURMAN', 'Chief Human Resources', '106', 17000 , 'D30'),
								  ('110', 'ALAMI’', 'Media Director', '106', 4000 , 'D40'),
								  ('111', 'SSEWALL', 'Media Director', '104', 3000 , 'D40'),
								  ('112', 'CVISHNEY', 'Marketing Specialist', '107', 3500 , 'D50'),
								  ('113', 'DGREENE', 'Marketing Manager', '106', 6500 , 'D50'),
								  ('114', 'DLEE', 'Marketing Director', '106', 4500 , 'D50'),
								  ('115', 'MSULLIVA', 'Executive Director', '101', 15000 , 'D60'),
								  ('116', 'ABULL', 'Financial branch manager', '115', 2500 , 'D70'),
								  ('117', 'JDELLING', 'Accountant', '102', 5500 , 'D70'),
								  ('118', 'ACABRIO', 'Cashier', '106', 8000 , 'D80'),
								  ('119', 'JDILLY', 'Office Assistant', '115', 7500 , 'D10'),
								  ('120', 'TGATES', 'Web Developer', '119', 6000 , 'D20'),
								  ('121', 'RPERKINS', 'Accountant', '115', 4400 , 'D70'),
								  ('122', 'DOCONNEL', 'Controller', '120', 3200 , 'D10')
		GO

		SELECT * FROM Employe
		GO
		SELECT * FROM Department
		GO
	
--- Projet --- (Code_Projet, Projet_Name)
	--- CREATE
		CREATE TABLE Projet(
							 Code_Projet VARCHAR(50) NOT NULL,
							 Name_Projet VARCHAR(50),

							 PRIMARY KEY (Code_Projet)
							)
		GO

	--- INSERT
		INSERT INTO Projet VALUES ('P110', 'Acciona'),
								  ('P120', 'SGTM'),
								  ('P130', 'ASTVS'),
								  ('P140', 'AMJB'),
								  ('P150', 'Advanced Vision Morocco'),
								  ('P160', 'SMEC Morocco'),
								  ('P170', 'les Colombes de l’Espoir'),
								  ('P180', 'DARELOUAD'),
								  ('P190', 'The Arab Contractors')
		GO
		
--- Participer --- (Matricule#, Code_Projet#)
	--- CREATE
		CREATE TABLE Participer(
									 Matricule VARCHAR(50) NOT NULL,
									 Code_Projet VARCHAR(50),

									 PRIMARY KEY (Matricule, Code_Projet),
									 FOREIGN KEY (Matricule) REFERENCES Employe(Matricule),
									 FOREIGN KEY (Code_Projet) REFERENCES Projet(Code_Projet)
							   )
		GO
		
	--- INSERT
		INSERT INTO Participer VALUES ('101', 'P110'),
									  ('101', 'P120'),
									  ('101', 'P130'),
									  ('101', 'P140'),
									  ('102', 'P110'),
									  ('103', 'P110'),
									  ('105', 'P120'),
									  ('105', 'P110'),
									  ('106', 'P120'),
									  ('107', 'P140'),
									  ('108', 'P130'),
									  ('109', 'P120'),
									  ('110', 'P130'),
									  ('110', 'P140'),
									  ('111', 'P140'),
									  ('112', 'P120'),
									  ('113', 'P130'),
									  ('114', 'P110'),
									  ('114', 'P120'),
									  ('114', 'P130'),
									  ('114', 'P140'),
									  ('115', 'P110'),
									  ('116', 'P140'),
									  ('117', 'P130'),
									  ('116', 'P110'),
									  ('118', 'P130'),
									  ('119', 'P110'),
									  ('120', 'P120'),
									  ('120', 'P130'),
									  ('120', 'P140')
		GO
		

--- Fournisseur --- (Num_Fourniture, Name, Ville) 
	--- CREATE
		CREATE TABLE Fournisseur(
									Num_Fourniture VARCHAR(50),
									Name_Fournisseur VARCHAR(50),
									Ville VARCHAR(50),

									PRIMARY KEY(Num_Fourniture)
								)
		GO
		
	--- INSERT
		INSERT INTO Fournisseur VALUES('F110', 'Aptitude ', 'Rabat'),
									  ('F120', 'Dorval', 'Titouan'),
									  ('F130', 'EX&CO', 'Ouarzazate'),
									  ('F140', 'Forum 7', 'Taza'),
									  ('F150', 'InDepartment', 'Agadir'),
									  ('F160', 'Rabat Invest', 'Rabat'),
									  ('F170', 'Wink', 'Titouan'),
									  ('F180', 'ADAMCOM', 'Bni-Mlale'),
									  ('F190', 'Pasmed', 'Tinghir'),
									  ('F200', 'Benicom', 'Casablanca')
		GO

--- Produit --- (Code_Produit, Libelle, Origine, Couleur) 
	--- CREATE
		CREATE TABLE Produit(
								Code_Produit VARCHAR(50) NOT NULL,
								Libelle VARCHAR(50) NOT NULL,
								Origine VARCHAR(50) NOT NULL,
								Couleur VARCHAR(50) NOT NULL,

								PRIMARY KEY(Code_Produit)
							)
		GO

	--- INSERT
		INSERT INTO Produit VALUES('M-P110', 'Papiers', 'USA', 'Rouge'),
								  ('M-P120', 'Secteur Agroalimentaire', 'England', 'Blue'),
								  ('M-P130', 'Safran', 'Morocco', 'Verte'),
								  ('M-P140', 'Câpres', '', 'Marron'),
								  ('M-P150', 'Tria', 'Suise', 'Rouge'),
								  ('M-P160', 'Nestle', 'USA', 'Mouve'),
								  ('M-P170', 'Aicha', 'Morocco', 'Blanc'),
								  ('M-P180', 'Milka', 'Algeria', 'Noir'),
								  ('M-P190', 'Ideal', 'Portogal', 'Gris'),
								  ('M-P200', 'Dia', 'Orss', 'Violet')
		GO
		
		SELECT * FROM Produit
		GO
	
--- Fourniture --- (Num_Fourniture#, Code_Produit#, Quantite) 

	--- CREATE
		CREATE TABLE Fourniture (
									Num_Fourniture VARCHAR(50) NOT NULL,
									Code_Produit VARCHAR(50),
									Quantite INT NOT NULL,

									FOREIGN KEY(Num_Fourniture) REFERENCES Fournisseur(Num_Fourniture),
									FOREIGN KEY(Code_Produit) REFERENCES Produit(Code_Produit)
								)
		GO
	
	--- INSERT
		INSERT INTO Fourniture VALUES ('F110','M-P120', 120),
									  ('F120','M-P160', 1100),
									  ('F130','M-P140', 770),
									  ('F130','M-P120', 0),
									  ('F150','M-P170', 3250),
									  ('F160','M-P110', 20000),
									  ('F170','M-P130', 250),
									  ('F180','M-P150', 5850),
									  ('F110','M-P180', 8000),
									  ('F140','M-P110', 10000)
		GO
	


SELECT * FROM Employe
SELECT * FROM Department
SELECT * FROM Produit
SELECT * FROM Projet
SELECT * FROM Fourniture
SELECT * FROM Fournisseur
GO