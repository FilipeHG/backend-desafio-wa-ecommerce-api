-- CREATE TABLES BY ENTITY PROJECT
--=================================================

DROP TABLE IF EXISTS [wa-desafio-ecommerce].dbo.Endereco;
DROP TABLE IF EXISTS [wa-desafio-ecommerce].dbo.Pedido;
DROP TABLE IF EXISTS [wa-desafio-ecommerce].dbo.Frota;
DROP TABLE IF EXISTS [wa-desafio-ecommerce].dbo.Produto;

CREATE TABLE Frota (
	Id bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nome varchar(250) NOT NULL,
    Descricao varchar(250) NOT NULL,
    PlacaVeiculoUtilizado varchar(8) NOT NULL
);

CREATE TABLE Pedido (
	Id bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FrotaId bigint FOREIGN KEY REFERENCES Frota(Id),
    Status varchar(100) NOT NULL,
	DataEntrega datetime,
	DataCriacao datetime NOT NULL,
	DataAtualizacao datetime,
	DataDelecao datetime
);

CREATE TABLE Endereco (
	Id bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PedidoId bigint FOREIGN KEY REFERENCES Pedido(Id),
    CEP varchar(9) NOT NULL,
    Logradouro varchar(250) NOT NULL,
    Numero int NOT NULL,
    Complemento varchar(50) NULL,
    Bairro varchar(150) NOT NULL,
    Cidade varchar(150) NOT NULL,
    UF varchar(2) NOT NULL
);

CREATE TABLE Produto (
	Id bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
    PedidoId bigint FOREIGN KEY REFERENCES Pedido(Id),
    Nome varchar(250) NOT NULL,
    Descricao varchar(250) NOT NULL,
    Valor DECIMAL(9,2) NOT NULL
);
