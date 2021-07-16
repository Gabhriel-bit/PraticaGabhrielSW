IF DB_ID('praticaDBGabhriel') IS NOT NULL
BEGIN
	IF OBJECT_ID('deposito_produto') IS NOT NULL
	BEGIN
		DROP TABLE deposito_produto;
	END
	
	IF OBJECT_ID('produto_fornecedor') IS NOT NULL
	BEGIN
		DROP TABLE produto_fornecedor;
	END
	
	IF OBJECT_ID('parcelasCondicaoPagamento') IS NOT NULL
	BEGIN
		DROP TABLE parcelasCondicaoPagamento;
	END
	
	IF OBJECT_ID('depositos') IS NOT NULL
	BEGIN
		DROP TABLE depositos;
	END
	
	IF OBJECT_ID('produtos') IS NOT NULL
	BEGIN
		DROP TABLE produtos;
	END
	
	IF OBJECT_ID('fornecedores') IS NOT NULL
	BEGIN
		DROP TABLE fornecedores;
	END
	
	IF OBJECT_ID('clientes') IS NOT NULL
	BEGIN
		DROP TABLE clientes;
	END
	
	IF OBJECT_ID('funcionarios') IS NOT NULL
	BEGIN
		DROP TABLE funcionarios;
	END
	
	IF OBJECT_ID('condicoesPagamento') IS NOT NULL
	BEGIN
		DROP TABLE condicoesPagamento;
	END
	
	IF OBJECT_ID('formasPagamento') IS NOT NULL
	BEGIN
		DROP TABLE formasPagamento;
	END
	
	IF OBJECT_ID('modelos') IS NOT NULL
	BEGIN
		DROP TABLE modelos;
	END
	
    IF OBJECT_ID('marcas') IS NOT NULL
	BEGIN
		DROP TABLE marcas;
	END

	IF OBJECT_ID('subgrupos') IS NOT NULL
	BEGIN
		DROP TABLE subgrupos;
	END

	IF OBJECT_ID('grupos') IS NOT NULL
	BEGIN
		DROP TABLE grupos;
	END

	IF OBJECT_ID('cargos') IS NOT NULL
	BEGIN
		DROP TABLE cargos;
	END
	
	IF OBJECT_ID('cidades') IS NOT NULL
	BEGIN
		DROP TABLE cidades;
	END
	
	IF OBJECT_ID('estados') IS NOT NULL
	BEGIN
		DROP TABLE estados;
	END
	
	IF OBJECT_ID('paises') IS NOT NULL
	BEGIN
		DROP TABLE paises;
	END
END
