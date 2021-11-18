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

IF OBJECT_ID('servicos') IS NULL
BEGIN
    CREATE TABLE servicos (
		servico    VARCHAR(50) NOT NULL UNIQUE,
		descricao  VARCHAR(100),
		preco      NUMERIC(8,4) NOT NULL,
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT  NOT NULL,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,

	    disponivel    INT NOT NULL default 1
	);
END

IF OBJECT_ID('paises') IS NULL
BEGIN
    CREATE TABLE paises (
		pais       VARCHAR(50) NOT NULL UNIQUE,
		moeda      VARCHAR(3),
		ddi        VARCHAR(4),
		sigla      VARCHAR(3),
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT  NOT NULL,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,

	    disponivel    INT NOT NULL default 1
	);
END

IF OBJECT_ID('estados') IS NULL
BEGIN
    CREATE TABLE estados (
		estado     VARCHAR(50) NOT NULL UNIQUE,
		uf         VARCHAR(3),
		codigoPais INT NOT NULL,
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT  NOT NULL,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codPaisEstado FOREIGN KEY (codigoPais) REFERENCES paises (codigo)
	);
END

IF OBJECT_ID('cidades') IS NULL
BEGIN
    CREATE TABLE cidades (
		cidade       VARCHAR(50) NOT NULL UNIQUE,
		ddd          VARCHAR(3),
		codigoEstado INT NOT NULL,
		codigo       INT PRIMARY KEY IDENTITY,
		codigoUsu    INT  NOT NULL,
		dataCad      VARCHAR(10) NOT NULL,
		dataUltAlt   VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codEstadoCidade FOREIGN KEY (codigoEstado) REFERENCES estados (codigo)
	);
END

IF OBJECT_ID('veiculos') IS NULL
BEGIN
    CREATE TABLE veiculos (
		codigo_antt VARCHAR(50) NOT NULL UNIQUE,
		placa       VARCHAR(50) NOT NULL UNIQUE,
		marca       VARCHAR(50) NOT NULL,
		modelo      VARCHAR(50) NOT NULL,
		uf          VARCHAR(2) NOT NULL,

		codigo      INT PRIMARY KEY IDENTITY,
		codigoUsu   INT  NOT NULL,
		dataCad     VARCHAR(10) NOT NULL,
		dataUltAlt  VARCHAR(10) NOT NULL,

	    disponivel    INT NOT NULL default 1
	);
END

IF OBJECT_ID('transportadoras') IS NULL
BEGIN
    CREATE TABLE transportadoras (
		transportadora  VARCHAR(50) NOT NULL UNIQUE,

		cnpj_cpf      VARCHAR(20) NOT NULL UNIQUE,
		inscEst_rg    VARCHAR(20),
		logradouro    VARCHAR(50) NOT NULL,
        numero        VARCHAR(5) NOT NULL,
        complemento   VARCHAR(50),
        bairro        VARCHAR(50) NOT NULL,
        cep           VARCHAR(10),
        tel_Celular   VARCHAR(20) NOT NULL,
        email         VARCHAR(30) NOT NULL,
		dataFund_Nasc VARCHAR(10),
		codigoCidade  INT NOT NULL,

		codigo       INT PRIMARY KEY IDENTITY,
		codigoUsu    INT  NOT NULL,
		dataCad      VARCHAR(10) NOT NULL,
		dataUltAlt   VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codCidadeTransp FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)
	);
END

IF OBJECT_ID('cargos') IS NULL
BEGIN
	CREATE TABLE cargos (
		cnh        VARCHAR(5) NOT NULL,
		cargo      VARCHAR(50) NOT NULL UNIQUE,
		descricao  VARCHAR(200),
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT  NOT NULL,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,

	    disponivel    INT NOT NULL default 1
	);
END

IF OBJECT_ID('grupos') IS NULL
BEGIN
	CREATE TABLE grupos (
		grupo      VARCHAR(50) NOT NULL UNIQUE,
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT  NOT NULL,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1
	);
END

IF OBJECT_ID('subgrupos') IS NULL
BEGIN
	CREATE TABLE subgrupos (
		subgrupo    VARCHAR(50) NOT NULL UNIQUE,
		codigoGrupo INT NOT NULL,
		codigo      INT PRIMARY KEY IDENTITY,
		codigoUsu   INT  NOT NULL,
		dataCad     VARCHAR(10) NOT NULL,
		dataUltAlt  VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codGrupoSubgrupo FOREIGN KEY (codigoGrupo) REFERENCES grupos (codigo)
	);
END

IF OBJECT_ID('marcas') IS NULL
BEGIN
	CREATE TABLE marcas (
		marca      VARCHAR(50) NOT NULL UNIQUE,
		codigo     INT PRIMARY KEY IDENTITY,
		codigoUsu  INT  NOT NULL,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,

	    disponivel    INT NOT NULL default 1
	);
END

IF OBJECT_ID('modelos') IS NULL
BEGIN
	CREATE TABLE modelos (
		modelo      VARCHAR(50) NOT NULL UNIQUE,
		descricao   VARCHAR(250),
		codigoMarca INT NOT NULL,
		codigo      INT PRIMARY KEY IDENTITY,
		codigoUsu   INT  NOT NULL,
		dataCad     VARCHAR(10) NOT NULL,
		dataUltAlt  VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codMarcaModelo FOREIGN KEY (codigoMarca) REFERENCES marcas (codigo)
	);
END

IF OBJECT_ID('equipamentos') IS NULL
BEGIN
	CREATE TABLE equipamentos (
		equipamento  VARCHAR(50) NOT NULL UNIQUE,
		voltagem     VARCHAR(4),
		obsTecnica   VARCHAR(250),
		codigoModelo INT NOT NULL,
		codigo       INT PRIMARY KEY IDENTITY,
		codigoUsu    INT  NOT NULL,
		dataCad      VARCHAR(10) NOT NULL,
		dataUltAlt   VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codModeloEquip FOREIGN KEY (codigoModelo) REFERENCES modelos (codigo)
	);
END

IF OBJECT_ID('formasPagamento') IS NULL
BEGIN
	CREATE TABLE formasPagamento (
		formaPagamento VARCHAR(50) NOT NULL UNIQUE,
		codigo         INT PRIMARY KEY IDENTITY,
		codigoUsu      INT  NOT NULL,
		dataCad        VARCHAR(10) NOT NULL,
		dataUltAlt     VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1
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
	dataUltAlt        VARCHAR(10) NOT NULL,
	
	disponivel    INT NOT NULL default 1
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

	disponivel    INT NOT NULL default 1, 
	PRIMARY KEY (codigoCondPag, numero),
	CONSTRAINT FK_codCondPag FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento (codigo),
	CONSTRAINT FK_codFormPag FOREIGN KEY (codigoFormaPagamento) REFERENCES formasPagamento (codigo)
	);
END

IF OBJECT_ID('funcionarios') IS NULL
BEGIN
	CREATE TABLE funcionarios (
		funcionario     VARCHAR(50) NOT NULL UNIQUE,

        logradouro      VARCHAR(50) NOT NULL,
        numero          VARCHAR(5) NOT NULL,
        complemento     VARCHAR(50),
        bairro          VARCHAR(50) NOT NULL,
        cep             VARCHAR(10),
        tel_Celular     VARCHAR(20) NOT NULL,
        email           VARCHAR(30) NOT NULL,
        cnpj_cpf        VARCHAR(20) NOT NULL UNIQUE,
        inscEst_rg      VARCHAR(20),
        cnh             VARCHAR(20),
		dataFund_Nasc   VARCHAR(10),
		salarioBase     NUMERIC(8,4) NOT NULL,
		comissaoVenda   NUMERIC(8,4) NOT NULL,
		comissaoProduto NUMERIC(8,4) NOT NULL,
        dataVencCNH     VARCHAR(10), 		
		codigoCidade    INT NOT NULL,
		codigoCargo     INT NOT NULL,

		codigo          INT PRIMARY KEY IDENTITY,
		codigoUsu       INT  NOT NULL,
		dataCad         VARCHAR(10) NOT NULL,
		dataUltAlt      VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codCargoFunc FOREIGN KEY (codigoCargo) REFERENCES cargos (codigo),
		CONSTRAINT FK_codCidadeFunc FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)
	);
END

IF OBJECT_ID('clientes') IS NULL
BEGIN
	CREATE TABLE clientes (
		cliente       VARCHAR(50) NOT NULL UNIQUE,
        logradouro    VARCHAR(50) NOT NULL,
        numero        VARCHAR(5) NOT NULL,
        complemento   VARCHAR(50),
        bairro        VARCHAR(50) NOT NULL,
        cep           VARCHAR(10),
        tel_Celular   VARCHAR(20) NOT NULL,
        email         VARCHAR(30) NOT NULL,
        cnpj_cpf      VARCHAR(20) NOT NULL UNIQUE,
        inscEst_rg    VARCHAR(20),
		dataFund_Nasc VARCHAR(10),		
		codigoCidade  INT NOT NULL,
		codigoCondPag INT NOT NULL,
		codigo        INT PRIMARY KEY IDENTITY,
		codigoUsu     INT  NOT NULL,
		dataCad       VARCHAR(10) NOT NULL,
		dataUltAlt    VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codCondPagCliente FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento (codigo),
		CONSTRAINT FK_codCidadeCliente FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)
	);
END

IF OBJECT_ID('fornecedores') IS NULL
BEGIN
	CREATE TABLE fornecedores (
		fornecedor    VARCHAR(50) NOT NULL UNIQUE,
        logradouro    VARCHAR(50) NOT NULL,
        numero        VARCHAR(5) NOT NULL,
        complemento   VARCHAR(50),
        bairro        VARCHAR(50) NOT NULL,
        cep           VARCHAR(10),
        tel_Celular   VARCHAR(20) NOT NULL,
        email         VARCHAR(30) NOT NULL,
        cnpj_cpf      VARCHAR(20) NOT NULL UNIQUE,
        inscEst_rg    VARCHAR(20),
		dataFund_Nasc VARCHAR(10),		
		codigoCidade  INT NOT NULL,
		codigoCondPag INT NOT NULL,
		codigo        INT PRIMARY KEY IDENTITY,
		codigoUsu     INT  NOT NULL,
		dataCad       VARCHAR(10) NOT NULL,
		dataUltAlt    VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codCondPagForn FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento (codigo),
		CONSTRAINT FK_codCidadeForn FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)
	);
END

IF OBJECT_ID('produtos') IS NULL
BEGIN
	CREATE TABLE produtos (
		produto        VARCHAR(50) NOT NULL UNIQUE,
        referencia     VARCHAR(50),
        codigoBarras   VARCHAR(20),
		ncm_sh         VARCHAR(20),
        custo          NUMERIC(8,4) NOT NULL,
		precoVenda     NUMERIC(8,4) NOT NULL,
        unidade        VARCHAR(20) NOT NULL,
        saldo          INT NOT NULL,
		peso_bruto     NUMERIC(8,4) NOT NULL,
        peso_liquid    NUMERIC(8,4) NOT NULL,
		precoUltCompra NUMERIC(8,4) NOT NULL,
		codigoModelo   INT NOT NULL,
		codigoSubgrupo INT,
		codigo         INT PRIMARY KEY IDENTITY,
		codigoUsu      INT  NOT NULL,
		dataCad        VARCHAR(10) NOT NULL,
		dataUltAlt     VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codModeloProd FOREIGN KEY (codigoModelo) REFERENCES modelos (codigo)--,
		--CONSTRAINT FK_codSubgrupoProd FOREIGN KEY (codigoSubgrupo) REFERENCES subgrupos (codigo)
	);
END

IF OBJECT_ID('produto_fornecedor') IS NULL
BEGIN
	CREATE TABLE produto_fornecedor (
		codigoProduto     INT  NOT NULL,
		codigoFornecedor  INT  NOT NULL,

		disponivel    INT NOT NULL default 1,
		PRIMARY KEY(codigoProduto, codigoFornecedor),
		CONSTRAINT FK_codProdProd_forn FOREIGN KEY (codigoProduto) REFERENCES produtos (codigo),
		CONSTRAINT FK_codFornProd_forn FOREIGN KEY (codigoFornecedor) REFERENCES fornecedores (codigo)
	);
END


IF OBJECT_ID('depositos') IS NULL
BEGIN
	CREATE TABLE depositos (
		deposito      VARCHAR(50) NOT NULL UNIQUE,
        logradouro    VARCHAR(50) NOT NULL,
        numero        VARCHAR(5) NOT NULL,
        complemento   VARCHAR(50),
        bairro        VARCHAR(50) NOT NULL,
        cep           VARCHAR(10),	
		codigoCidade  INT NOT NULL,
		codigo        INT PRIMARY KEY IDENTITY,
		codigoUsu     INT  NOT NULL,
		dataCad       VARCHAR(10) NOT NULL,
		dataUltAlt    VARCHAR(10) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		CONSTRAINT FK_codCidadeDepo FOREIGN KEY (codigoCidade) REFERENCES cidades (codigo)
	);  
END

IF OBJECT_ID('deposito_produto') IS NULL
BEGIN
	CREATE TABLE deposito_produto (
		codigoProduto  INT  NOT NULL,
		codigoDeposito INT  NOT NULL,

		disponivel    INT NOT NULL default 1,
		PRIMARY KEY(codigoProduto, codigoDeposito),
		CONSTRAINT FK_codProdDep_prod FOREIGN KEY (codigoProduto) REFERENCES produtos (codigo),
		CONSTRAINT FK_codDepoDep_prod FOREIGN KEY (codigoDeposito) REFERENCES depositos (codigo)
	);
END

IF OBJECT_ID('compras') IS NULL
BEGIN
	CREATE TABLE compras (
		modelo          VARCHAR(50) NOT NULL,
		serie           VARCHAR(50) NOT NULL,
		numero_nf       VARCHAR(50) NOT NULL,  
		codigoForn      INT  NOT NULL,
		codigoTransp    INT,
		codigoVeiculo   INT,
		codigoCondPag   INT NOT NULL,
		chave_acesso    VARCHAR(50) NOT NULL,
		nat_op          VARCHAR(50),
		dados_NFe       VARCHAR(50),
		valor_frete     NUMERIC(8,4) NOT NULL,
		valor_seguro    NUMERIC(8,4) NOT NULL,
		out_desp        VARCHAR(50) NOT NULL,
		valor_IPI       NUMERIC(8,4),
		fretePorconta   VARCHAR(50),
		especie         VARCHAR(50),
		marca           VARCHAR(50),
		numero          INT,
		total_nota      NUMERIC(8,4) NOT NULL,
		total_produtos  NUMERIC(8,4) NOT NULL,
		peso_bruto      NUMERIC(8,4) NOT NULL,
		peso_liquido    NUMERIC(8,4) NOT NULL,
		data_emissao    VARCHAR(10) NOT NULL,
		data_chegada    VARCHAR(10) NOT NULL,
		codigoUsu       INT  NOT NULL,

	    disponivel    INT NOT NULL default 1,
		PRIMARY KEY(modelo, serie, numero_nf, codigoForn),
		CONSTRAINT FK_codFornNf FOREIGN KEY (codigoForn) REFERENCES fornecedores (codigo),
		CONSTRAINT FK_codVeiculoNf FOREIGN KEY (codigoVeiculo) REFERENCES veiculos (codigo),
		--CONSTRAINT FK_codTranspNf FOREIGN KEY (codigoTransp) REFERENCES transportadoras (codigo),
		CONSTRAINT FK_codCondPagNf FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento (codigo)
	);
END

IF OBJECT_ID('produtos_compra') IS NULL
BEGIN
	CREATE TABLE produtos_compra (
		codigoProd INT  NOT NULL,
		modelo     VARCHAR(50) NOT NULL,
		serie      VARCHAR(50) NOT NULL,
		numero_nf  VARCHAR(50) NOT NULL,
		codigoForn INT  NOT NULL,

		csosn      VARCHAR(50),
		cfop       VARCHAR(50),
		unidade    VARCHAR(5) NOT NULL,
		quantidade INT NOT NULL,
		valor_un   NUMERIC(8,4) NOT NULL,
		desconto   NUMERIC(8,4) NOT NULL,
		disponivel    INT NOT NULL default 1,
		PRIMARY KEY(codigoProd, modelo, serie, numero_nf, codigoForn),
		CONSTRAINT FK_codCompraNf FOREIGN KEY (codigoProd) REFERENCES produtos (codigo),
		CONSTRAINT FK_pkProdCompraNf FOREIGN KEY (modelo, serie, numero_nf, codigoForn) 
			REFERENCES compras (modelo, serie, numero_nf, codigoForn)
	);
END

IF OBJECT_ID('vendas') IS NULL
BEGIN
	CREATE TABLE vendas (
		modelo        VARCHAR(50) NOT NULL,
		serie         VARCHAR(50) NOT NULL,
		numero_nf     VARCHAR(50) NOT NULL,  
		codigoCliente INT  NOT NULL,
		codigoTransp  INT,
		codigoVeiculo INT,
		codigoCondPag INT NOT NULL,

		total_nota    NUMERIC(8,4) NOT NULL,

		peso_bruto    NUMERIC(8,4) NOT NULL,
		peso_liquido  NUMERIC(8,4) NOT NULL,
		data_emissao  VARCHAR(10) NOT NULL,
		data_saida    VARCHAR(10) NOT NULL,
		codigoUsu     INT  NOT NULL,

	    disponivel    INT NOT NULL default 1,
		PRIMARY KEY(modelo, serie, numero_nf, codigoCliente),
		CONSTRAINT FK_codCliNf FOREIGN KEY (codigoCliente) REFERENCES clientes (codigo),
		--CONSTRAINT FK_codTranspNf FOREIGN KEY (codigoTransp) REFERENCES transportadoras (codigo),
		CONSTRAINT FK_codCondPagVenda FOREIGN KEY (codigoCondPag) REFERENCES condicoesPagamento(codigo)
	);
END

IF OBJECT_ID('produtos_venda') IS NULL
BEGIN
	CREATE TABLE produtos_venda (
		codigoProd INT  NOT NULL,
		modelo     VARCHAR(50) NOT NULL,
		serie      VARCHAR(50) NOT NULL,
		numero_nf  VARCHAR(50) NOT NULL,
		codigoCliente INT  NOT NULL,

		unidade    VARCHAR(5) NOT NULL,
		quantidade INT NOT NULL,
		valor_un   NUMERIC(8,4) NOT NULL,
		desconto   NUMERIC(8,4) NOT NULL,
		disponivel    INT NOT NULL default 1,
		PRIMARY KEY(codigoProd, modelo, serie, numero_nf, codigoCliente),
		CONSTRAINT FK_codVendaNf FOREIGN KEY (codigoProd) REFERENCES produtos(codigo),
		CONSTRAINT FK_pkProdVendaNf FOREIGN KEY (modelo, serie, numero_nf, codigoCliente) 
			REFERENCES vendas (modelo, serie, numero_nf, codigoCliente)
	);
END

IF OBJECT_ID('contas_pagar') IS NULL
BEGIN
	CREATE TABLE contas_pagar	 (
		modelo         VARCHAR(50) NOT NULL,
		serie          VARCHAR(50) NOT NULL,
		numero_nf      VARCHAR(50) NOT NULL,
		codigoForn     INT  NOT NULL,
		parcela        INT  NOT NULL,

		vencimento     VARCHAR(10) NOT NULL,
		dataPagamento  VARCHAR(10) NOT NULL,
		valorTotal     NUMERIC(8,4) NOT NULL,
		valorPago      NUMERIC(8,4),

		codigoFormaPag INT NOT NULL,
		codigoUsu      INT  NOT NULL,
		dataCad        VARCHAR(10) NOT NULL,

		descontoPag NUMERIC(8,4) NOT NULL, 
		taxaJuros   NUMERIC(8,4) NOT NULL,
		multa       NUMERIC(8,4) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		PRIMARY KEY(modelo, serie, numero_nf, codigoForn, parcela),
		CONSTRAINT FK_pkContasPagFormPag FOREIGN KEY (codigoFormaPag) REFERENCES formasPagamento(codigo),
		CONSTRAINT FK_pkContasPag FOREIGN KEY (modelo, serie, numero_nf, codigoForn) 
			REFERENCES compras(modelo, serie, numero_nf, codigoForn)
	);
END

IF OBJECT_ID('contas_receber') IS NULL
BEGIN
	CREATE TABLE contas_receber	 (
		modelo         VARCHAR(50) NOT NULL,
		serie          VARCHAR(50) NOT NULL,
		numero_nf      VARCHAR(50) NOT NULL,
		codigoCliente  INT  NOT NULL,
		parcela        INT  NOT NULL,

		vencimento     VARCHAR(10) NOT NULL,
		dataPagamento  VARCHAR(10) NOT NULL,
		valorTotal     NUMERIC(8,4) NOT NULL,
		valorPago      NUMERIC(8,4),

		codigoFormaPag INT NOT NULL,
		codigoUsu      INT  NOT NULL,
		dataCad        VARCHAR(10) NOT NULL,

		descontoPag NUMERIC(8,4) NOT NULL, 
		taxaJuros   NUMERIC(8,4) NOT NULL,
		multa       NUMERIC(8,4) NOT NULL,
		
	    disponivel    INT NOT NULL default 1,
		PRIMARY KEY(modelo, serie, numero_nf, codigoCliente, parcela),
		CONSTRAINT FK_pkContasPagFormPag FOREIGN KEY (codigoFormaPag) REFERENCES formasPagamento(codigo),
		CONSTRAINT FK_pkContasPag FOREIGN KEY (modelo, serie, numero_nf, codigoCliente) 
			REFERENCES vendas (modelo, serie, numero_nf, codigoCliente)
	);
END

IF OBJECT_ID('usuarios') IS NULL
BEGIN
	CREATE TABLE usuarios	 (
		codigo     INT  NOT NULL PRIMARY KEY,
		usuario    VARCHAR(10) NOT NULL,   
		senha      VARCHAR(10) NOT NULL,
		codigoUsu  INT  NOT NULL,
		dataCad    VARCHAR(10) NOT NULL,
		dataUltAlt VARCHAR(10) NOT NULL,
	);
END

IF OBJECT_ID('usuarios_permissoes') IS NULL
BEGIN
	CREATE TABLE usuarios_permissoes	 (
		codigo     INT  NOT NULL,
		permissao  VARCHAR(20) NOT NULL,
		PRIMARY KEY(codigo, permissao)
	);
END
GO