USE master;  
GO  
DROP DATABASE XPTest;

CREATE DATABASE XPTest;
GO
USE XPTest;
GO

CREATE TABLE Cliente (
    Id INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(255),
    Telefone VARCHAR(255),
	Idade int,
);

CREATE TABLE Endereco (
    Id INT PRIMARY KEY IDENTITY,
	Principal bit,
    Rua VARCHAR(100) NOT NULL,
    Numero VARCHAR(10),
    Cidade VARCHAR(50),
    Estado VARCHAR(50),
    CEP VARCHAR(10),
	ClienteId int NOT NULL,
	FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);


CREATE TABLE Email (
    ID INT PRIMARY KEY IDENTITY,
    EnderecoEmail VARCHAR(255),
	ClienteId int NOT NULL,
	Principal bit,
	FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);



INSERT INTO Cliente (Nome, Telefone, Idade)
VALUES ('Cliente 1', '5521997260545', 30);

INSERT INTO Cliente (Nome, Telefone, Idade)
VALUES ('Cliente 2', '5521988738234', 25);

INSERT INTO Endereco (Principal, Rua, Numero, Cidade, Estado, CEP, ClienteId)
VALUES (1, 'Rua A', '123', 'Cidade A', 'Estado A', '12345-678', 1);

INSERT INTO Endereco (Principal, Rua, Numero, Cidade, Estado, CEP, ClienteId)
VALUES (0, 'Rua B', '456', 'Cidade B', 'Estado B', '98765-432', 1);

INSERT INTO Endereco (Principal, Rua, Numero, Cidade, Estado, CEP, ClienteId)
VALUES (1, 'Rua X', '789', 'Cidade X', 'Estado X', '56789-012', 2);

INSERT INTO Endereco (Principal, Rua, Numero, Cidade, Estado, CEP, ClienteId)
VALUES (0, 'Rua Y', '1011', 'Cidade Y', 'Estado Y', '12345-678', 2);

INSERT INTO Email (EnderecoEmail, ClienteId, Principal)
VALUES ( 'cliente1@email.com',1, 1);

INSERT INTO Email (EnderecoEmail, ClienteId, Principal)
VALUES ('outrocliente1@email.com', 1 , 0);

INSERT INTO Email (EnderecoEmail, ClienteId, Principal)
VALUES ('cliente2@email.com', 2,1);

INSERT INTO Email (EnderecoEmail, ClienteId, Principal)
VALUES ('outrocliente2@email.com', 2, 0);
