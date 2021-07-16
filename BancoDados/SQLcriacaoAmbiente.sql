USE master ;  
GO 

IF DB_ID('praticaDBGabhriel') IS NULL
BEGIN
	CREATE DATABASE praticaDBGabhriel  
	ON   
	( NAME = praticaDBGabhriel_dat,  
		FILENAME = 'C:\Users\gabhr\Desktop\.NET\PraticaGSW_DB\praticaDBGabhrielDat.mdf',  
		SIZE = 10,  
		MAXSIZE = 50,  
		FILEGROWTH = 5 )  
	LOG ON  
	( NAME = praticaDBGabhriel_log,  
		FILENAME = 'C:\Users\gabhr\Desktop\.NET\PraticaGSW_DB\praticaDBGabhrielLog.ldf',  
		SIZE = 5MB,  
		MAXSIZE = 25MB,  
		FILEGROWTH = 5MB );  
END
GO

USE praticaDBGabhriel
GO

IF OBJECT_ID('paises') IS NULL
BEGIN
    CREATE TABLE paises (
		pais       VARCHAR(50) NOT NULL UNIQUE,
		moeda      VARCHAR(3),
		ddi        VARCHAR(4),
		sigla      VARCHAR(3),
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL--,
		--CONSTRAINT FK_codPaisUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('estados') IS NULL
BEGIN
    CREATE TABLE estados (
		estado     VARCHAR(50) NOT NULL UNIQUE,
		uf         VARCHAR(3),
		codigoPais INT NOT NULL,
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codPaisEstado FOREIGN KEY (codigoPais) REFERENCES paises (codigo)--,
		--CONSTRAINT FK_codEstadoUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('cidades') IS NULL
BEGIN
    CREATE TABLE cidades (
		cidade       VARCHAR(50) NOT NULL UNIQUE,
		ddd          VARCHAR(3),
		codigoEstado INT NOT NULL,
		codigo       INT PRIMARY KEY IDENTITY,
		codigoUsu    INT,
		dataCad      VARCHAR(10) NOT NULL,
		dataUltAlt   VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codEstadoCidade FOREIGN KEY (codigoEstado) REFERENCES estados (codigo)--,
		--CONSTRAINT FK_codCidadeUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('cargos') IS NULL
BEGIN
	CREATE TABLE cargos (
		cnh        VARCHAR(5) NOT NULL,
		cargo      VARCHAR(50) NOT NULL UNIQUE,
		descricao  VARCHAR(200),
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL--,
		--CONSTRAINT FK_codCargoUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('grupos') IS NULL
BEGIN
	CREATE TABLE grupos (
		grupo      VARCHAR(50) NOT NULL UNIQUE,
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL--,
		--CONSTRAINT FK_codGrupoUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('subgrupos') IS NULL
BEGIN
	CREATE TABLE subgrupos (
		subgrupo    VARCHAR(50) NOT NULL UNIQUE,
		codigoGrupo INT NOT NULL,
		codigo      INT PRIMARY KEY IDENTITY,
		codigoUsu   INT,
		dataCad     VARCHAR(10) NOT NULL,
		dataUltAlt  VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codGrupoSubgrupo FOREIGN KEY (codigoGrupo) REFERENCES grupos (codigo)--,
		--CONSTRAINT FK_codSubgrupoUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('marcas') IS NULL
BEGIN
	CREATE TABLE marcas (
		marca      VARCHAR(50) NOT NULL UNIQUE,
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL--,
		--CONSTRAINT FK_codMarcaUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('modelos') IS NULL
BEGIN
	CREATE TABLE modelos (
		modelo      VARCHAR(50) NOT NULL UNIQUE,
		descricao   VARCHAR(250),
		codigoMarca INT NOT NULL,
		codigo      INT PRIMARY KEY IDENTITY,
		codigoUsu   INT,
		dataCad     VARCHAR(10) NOT NULL,
		dataUltAlt  VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codMarcaModelo FOREIGN KEY (codigoMarca) REFERENCES marcas (codigo)--,
		--CONSTRAINT FK_codModeloUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('formasPagamento') IS NULL
BEGIN
	CREATE TABLE formasPagamento (
		formaPagamento VARCHAR(50) NOT NULL UNIQUE,
		codigo         INT PRIMARY KEY IDENTITY,
		codigoUsu      INT,
		dataCad        VARCHAR(10) NOT NULL,
		dataUltAlt     VARCHAR(10) NOT NULL--,
		--CONSTRAINT FK_codFormPagUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('condicoesPagamento') IS NULL
BEGIN
	CREATE TABLE condicoesPagamento (
	codigo            INT PRIMARY KEY IDENTITY,
	condicaoPagamento VARCHAR(80) NOT NULL UNIQUE,
	totalParcelas     INT NOT NULL,
	taxaJuros         NUMERIC(8,4) NOT NULL,
	multa             NUMERIC(8,4) NOT NULL,
	desconto          NUMERIC(8,4) NOT NULL,
	codigoUsu         INT  NOT NULL,
	dataCad           VARCHAR(10) NOT NULL,
	dataUltAlt        VARCHAR(10) NOT NULL--,
	--CONSTRAINT FK_codCondPagUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('parcelasCondicaoPagamento') IS NULL
BEGIN
	CREATE TABLE parcelasCondicaoPagamento (
	codigoCondPag INT NOT NULL,
	numero        INT NOT NULL,
	dias          INT NOT NULL,
	porcentagem   NUMERIC(8,4) NOT NULL,
	codigoFormaPagamento INT NOT NULL,
	PRIMARY KEY (codigoCondPag, numero),
	CONSTRAINT FK_codCondPag FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento (codigo),
	CONSTRAINT FK_codFormPag FOREIGN KEY (codigoFormaPagamento) REFERENCES formasPagamento (codigo)
	);
END

IF OBJECT_ID('funcionarios') IS NULL
BEGIN
	CREATE TABLE funcionarios (
		funcionario VARCHAR(50) NOT NULL UNIQUE,
        logradouro  VARCHAR(50) NOT NULL,
        numero      VARCHAR(5) NOT NULL,
        complemento VARCHAR(50),
        bairro      VARCHAR(50) NOT NULL,
        cep         VARCHAR(10),
        tel_Celular VARCHAR(20) NOT NULL,
        email       VARCHAR(30),
        cnpj_cpf    VARCHAR(20) NOT NULL UNIQUE,
        inscEst_rg  VARCHAR(20),
        cnh         VARCHAR(20),
		dataFund_Nasc   VARCHAR(10),
		salarioBase     NUMERIC(8,4) NOT NULL,
		comissaoVenda   NUMERIC(8,4),
		comissaoProduto NUMERIC(8,4),
        dataVencCNH VARCHAR(10), 		
		codigoCidade INT NOT NULL,
		codigoCargo  INT NOT NULL,
		codigo       INT PRIMARY KEY IDENTITY,
		codigoUsu    INT  NOT NULL,
		dataCad      VARCHAR(10) NOT NULL,
		dataUltAlt   VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codCargoFunc FOREIGN KEY (codigoCargo) REFERENCES cargos (codigo),
		CONSTRAINT FK_codCidadeFunc FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)--,
		--CONSTRAINT FK_codFuncUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('clientes') IS NULL
BEGIN
	CREATE TABLE clientes (
		cliente     VARCHAR(50) NOT NULL UNIQUE,
        logradouro  VARCHAR(50) NOT NULL,
        numero      VARCHAR(5) NOT NULL,
        complemento VARCHAR(50),
        bairro      VARCHAR(50) NOT NULL,
        cep         VARCHAR(10),
        tel_Celular VARCHAR(20) NOT NULL,
        email       VARCHAR(30),
        cnpj_cpf    VARCHAR(20) NOT NULL UNIQUE,
        inscEst_rg  VARCHAR(20),
		dataFund_Nasc VARCHAR(10),		
		codigoCidade  INT NOT NULL,
		codigoCondPag INT NOT NULL,
		codigo        INT PRIMARY KEY IDENTITY,
		codigoUsu     INT  NOT NULL,
		dataCad       VARCHAR(10) NOT NULL,
		dataUltAlt    VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codCondPagCliente FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento (codigo),
		CONSTRAINT FK_codCidadeCliente FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)--,
		--CONSTRAINT FK_codClienteUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('fornecedores') IS NULL
BEGIN
	CREATE TABLE fornecedores (
		fornecedor  VARCHAR(50) NOT NULL UNIQUE,
        logradouro  VARCHAR(50) NOT NULL,
        numero      VARCHAR(5) NOT NULL,
        complemento VARCHAR(50),
        bairro      VARCHAR(50) NOT NULL,
        cep         VARCHAR(10),
        tel_Celular VARCHAR(20) NOT NULL,
        email       VARCHAR(30),
        cnpj_cpf    VARCHAR(20) NOT NULL UNIQUE,
        inscEst_rg  VARCHAR(20),
		dataFund_Nasc VARCHAR(10),		
		codigoCidade  INT NOT NULL,
		codigoCondPag INT NOT NULL,
		codigo        INT PRIMARY KEY IDENTITY,
		codigoUsu     INT  NOT NULL,
		dataCad       VARCHAR(10) NOT NULL,
		dataUltAlt    VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codCondPagForn FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento (codigo),
		CONSTRAINT FK_codCidadeForn FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)--,
		--CONSTRAINT FK_codFornUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('produtos') IS NULL
BEGIN
	CREATE TABLE produtos (
		produto     VARCHAR(50) NOT NULL UNIQUE,
        referencia  VARCHAR(50) NOT NULL,
        codigoBarras VARCHAR(20) NOT NULL,
        custo       NUMERIC(8,4) NOT NULL,
        unidade     INT NOT NULL,
        saldo       INT NOT NULL,		
		codigoModelo   INT NOT NULL,
		codigoSubgrupo INT NOT NULL,
		codigo         INT PRIMARY KEY IDENTITY,
		codigoUsu      INT  NOT NULL,
		dataCad        VARCHAR(10) NOT NULL,
		dataUltAlt     VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codModeloProd FOREIGN KEY (codigoModelo) REFERENCES modelos (codigo),
		CONSTRAINT FK_codSubgrupoProd FOREIGN KEY (codigoSubgrupo) REFERENCES subgrupos (codigo)--,
		--CONSTRAINT FK_codProdUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END

IF OBJECT_ID('produto_fornecedor') IS NULL
BEGIN
	CREATE TABLE produto_fornecedor (
		codigoProduto     INT  NOT NULL,
		codigoFornecedor  INT  NOT NULL,
		--codigoUsu      INT  NOT NULL,
		--dataCad        VARCHAR(10) NOT NULL,
		--dataUltAlt     VARCHAR(10) NOT NULL,
		PRIMARY KEY(codigoProduto, codigoFornecedor),
		CONSTRAINT FK_codProdProd_forn FOREIGN KEY (codigoProduto) REFERENCES produtos (codigo),
		CONSTRAINT FK_codFornProd_forn FOREIGN KEY (codigoFornecedor) REFERENCES fornecedores (codigo)--,
		--CONSTRAINT FK_codProdUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END


IF OBJECT_ID('depositos') IS NULL
BEGIN
	CREATE TABLE depositos (
		deposito    VARCHAR(50) NOT NULL UNIQUE,
        logradouro  VARCHAR(50) NOT NULL,
        numero      VARCHAR(5) NOT NULL,
        complemento VARCHAR(50),
        bairro      VARCHAR(50) NOT NULL,
        cep         VARCHAR(10),	
		codigoCidade  INT NOT NULL,
		codigo        INT PRIMARY KEY IDENTITY,
		codigoUsu     INT  NOT NULL,
		dataCad       VARCHAR(10) NOT NULL,
		dataUltAlt    VARCHAR(10) NOT NULL,
		CONSTRAINT FK_codCidadeDepo FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)--,
		--CONSTRAINT FK_codFornUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);  
END

IF OBJECT_ID('deposito_produto') IS NULL
BEGIN
	CREATE TABLE deposito_produto (
		codigoProduto  INT  NOT NULL,
		codigoDeposito INT  NOT NULL,
		--codigoUsu      INT  NOT NULL,
		--dataCad        VARCHAR(10) NOT NULL,
		--dataUltAlt     VARCHAR(10) NOT NULL,
		PRIMARY KEY(codigoProduto, codigoDeposito),
		CONSTRAINT FK_codProdDep_prod FOREIGN KEY (codigoProduto) REFERENCES produtos (codigo),
		CONSTRAINT FK_codDepoDep_prod FOREIGN KEY (codigoDeposito) REFERENCES depositos (codigo)--,
		--CONSTRAINT FK_codProdUsu FOREIGN KEY (codigoUsu) REFERENCES usuarios (codigo)
	);
END
GO