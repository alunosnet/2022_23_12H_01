CREATE TABLE tipo
(
	nTipo int identity primary key,
	nome varchar(20) not null DEFAULT('Nenhum'),
)

CREATE TABLE utilizadores
(
	id int identity primary key,
	tipo int references tipo(nTipo),
	email varchar(100) not null unique check (email like '%@%.%'),
	nome varchar(100) not null,
	morada varchar(100) not null,
	nif varchar(9) not null unique,
	password varchar(64) not null,
	sal int,
	perfil int not null check (perfil in ('0','1','2')) DEFAULT(0), --0 - cliente; 1 - admin; 2 - prestador
	lnkRecuperar varchar(36),
	data_lnk date,
)

CREATE TABLE pedidos
(
	[npedido] INT NOT NULL PRIMARY KEY identity,
	idut int references utilizadores(id), -- id do cliente
	tipo int references tipo(nTipo),
	preco decimal(4,2) not null check(preco > 0),
	data_ped date DEFAULT(getdate()),
	descricao varchar(100) not null,
	estado int not null check (estado in ('0','1','2')) DEFAULT(0) --0 - por aceitar; 1 - pendente ;2 - concluida
)

CREATE TABLE servicos
(
	[nservicos] INT NOT NULL PRIMARY KEY identity,
	idut int references utilizadores(id), -- id do prestador
	idped int references pedidos(npedido),
	avaliacao int not null check (avaliacao in ('0','1','2','3','4','5')) DEFAULT('0'),
	comentarios varchar(500),
	data_serv date DEFAULT(getdate())
)

create index iutilizador_nome on utilizadores(nome)

--Cria Admin
INSERT INTO utilizadores(email,nome,morada,nif,password,perfil)
VALUES ('a@g.c','admin','viseu','123456789',HASHBYTES('SHA2_512','12345'),1)

--Cria Cliente
INSERT INTO utilizadores(email,nome,morada,nif,password,perfil)
VALUES ('c@g.c','cliente','viseu','123456788',HASHBYTES('SHA2_512','12345'),0)

--Cria Prestador
INSERT INTO utilizadores(email,nome,morada,nif,password,perfil)
VALUES ('p@g.c','prestador','viseu','123456777',HASHBYTES('SHA2_512','12345'),2)

--Criar os Tipos
INSERT INTO tipo(nome)
VALUES ('Entrega de Comida')
INSERT INTO tipo(nome)
VALUES ('Taxi')
INSERT INTO tipo(nome)
VALUES ('Manutenção')
INSERT INTO tipo(nome)
VALUES ('Nenhum')

drop table servicos
drop table pedidos 
drop table utilizadores 
drop table tipo