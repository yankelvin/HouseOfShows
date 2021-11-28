--CRUD de Responsável por eventos (0,5):
--o Campos: Nome, Data de Nascimento, CPF, Cidade, UF, Endereço;
--o O sistema deverá validar se já existe um cadastro para o mesmo CPF;

CREATE TABLE Responsaveis (
	CPF VARCHAR(11) PRIMARY KEY,
	NOME VARCHAR(100) NOT NULL,
	DATA_NASCIMENTO DATE NOT NULL,
	CIDADE VARCHAR(50) NOT NULL,
	UF CHAR(2) NOT NULL,
	ENDERECO VARCHAR(250) NOT NULL
);

SELECT * FROM Responsaveis;

--CRUD de eventos (1,5):
--o Campos: ID Sequencial e único, nome do evento, data do evento, responsável pelo evento, valor
--do ingresso inteiro, valor do ingresso meia, status (A Realizar, Vendas abertas, Realizado);
--o A informação do responsável pelo evento deve vir do cadastro respectivo;

CREATE TABLE Status (
	NOME_STATUS VARCHAR(50) PRIMARY KEY NOT NULL
);

SELECT * FROM Status;

CREATE TABLE Eventos (
	ID INT PRIMARY KEY IDENTITY NOT NULL,
	NOME VARCHAR(100) NOT NULL,
	DATA_EVENTO DATE NOT NULL,
	CPF_RESPONSAVEL VARCHAR(11) NOT NULL,
	VALOR_INTEIRA DECIMAL(8, 2) NOT NULL,
	VALOR_MEIA DECIMAL(8, 2) NOT NULL,
	NOME_STATUS VARCHAR(50) NOT NULL
);

ALTER TABLE Eventos
ADD CONSTRAINT CPF_RESPONSAVEL
FOREIGN KEY (CPF_RESPONSAVEL) REFERENCES Responsaveis(CPF);

ALTER TABLE Eventos
ADD CONSTRAINT NOME_STATUS
FOREIGN KEY (NOME_STATUS) REFERENCES Status(NOME_STATUS);

SELECT * FROM Eventos;

--CRUD de cliente (1,5):
--o Campos: Nome, Data de Nascimento, CPF, Cidade, UF;
--o O sistema deverá validar se já existe um cadastro para o mesmo CPF;
--o Caso o cliente seja menor de idade, deverá preencher também os campos nome (do menor de
--idade) e idade;

CREATE TABLE Clientes (
	CPF VARCHAR(11) PRIMARY KEY,
	NOME VARCHAR(100) NOT NULL,
	DATA_NASCIMENTO DATE NOT NULL,
	CIDADE VARCHAR(50) NOT NULL,
	UF CHAR(2) NOT NULL,
	IDADE INT NULL
);

SELECT * FROM Clientes;

--Cadastro e Consulta de Venda de ingresso (2,0);
--o Campos: Evento, Cliente, tipo do ingresso (inteiro/meia), quantidade de ingressos, valor total da
--venda;
--o As informações do evento, cliente e valor dos ingressos devem vir dos respectivos cadastros;
--o Deve validar se o evento ainda está disponível (vendas abertas);

CREATE TABLE TipoIngresso (
	TIPO_INGRESSO VARCHAR(50) PRIMARY KEY NOT NULL
);

SELECT * FROM TipoIngresso;

CREATE TABLE Vendas (
	ID_VENDA INT PRIMARY KEY IDENTITY NOT NULL,
	ID_EVENTO INT NOT NULL,
	CPF_CLIENTE VARCHAR(11) NOT NULL,
	TIPO_INGRESSO VARCHAR(50) NOT NULL,
	QTD_INGRESSO INT NOT NULL,
	VALOR_TOTAL DECIMAL(8, 2) NOT NULL
);

ALTER TABLE Vendas
ADD CONSTRAINT ID_EVENTO
FOREIGN KEY (ID_EVENTO) REFERENCES Eventos(ID);

ALTER TABLE Vendas
ADD CONSTRAINT CPF_CLIENTE
FOREIGN KEY (CPF_CLIENTE) REFERENCES Clientes(CPF);

ALTER TABLE Vendas
ADD CONSTRAINT TIPO_INGRESSO
FOREIGN KEY (TIPO_INGRESSO) REFERENCES TipoIngresso(TIPO_INGRESSO);
