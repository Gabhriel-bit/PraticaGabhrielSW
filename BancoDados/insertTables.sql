use praticaDBGabhriel
insert into paises (codigoUsu, dataCad, dataUltAlt, pais, moeda, ddi, sigla) values (0, '09/11/2021 ', '09/11/2021 ', 'BRASIL', 'R$', '+55', 'BRA');

insert into estados (codigoUsu, dataCad, dataUltAlt, estado, uf, codigoPais) values (0, '09/11/2021 ', '09/11/2021 ', 'PARANÁ', 'PR', 1);
insert into estados (codigoUsu, dataCad, dataUltAlt, estado, uf, codigoPais) values (0, '09/11/2021 ', '09/11/2021 ', 'MATO GROSSO DO SUL', 'MS', 1);
insert into estados (codigoUsu, dataCad, dataUltAlt, estado, uf, codigoPais) values (0, '09/11/2021 ', '09/11/2021 ', 'SÃO PAULO', 'SP', 1);

insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'FOZ DO IGUAÇU', 45, 1);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'CASCAVEL', 45, 1);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'DOURADOS', 67, 2);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'CAMPO GRANDE', 67, 2);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'SÃO PAULO', 11, 5);

insert into formasPagamento (codigoUsu, dataCad, dataUltAlt, formaPagamento) values (0, '09/11/2021 ', '09/11/2021 ', 'VISTA');
insert into formasPagamento (codigoUsu, dataCad, dataUltAlt, formaPagamento) values (0, '09/11/2021 ', '09/11/2021 ', 'BOLETO');

insert into condicoesPagamento (codigoUsu, dataCad, dataUltAlt, condicaoPagamento, totalParcelas, taxaJuros, multa, desconto) values (0, '09/11/2021 ', '09/11/2021 ', '30 DIAS', 1, 6.32, 12, 0);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '30 DIAS'), 1, 30, 100, 1);
insert into condicoesPagamento (codigoUsu, dataCad, dataUltAlt, condicaoPagamento, totalParcelas, taxaJuros, multa, desconto) values (0, '09/11/2021 ', '09/11/2021 ', '30 60 DIAS', 2, 6.23, 12, 0);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '30 60 DIAS'), 1, 30, 50, 1);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '30 60 DIAS'), 2, 60, 50, 2);
insert into condicoesPagamento (codigoUsu, dataCad, dataUltAlt, condicaoPagamento, totalParcelas, taxaJuros, multa, desconto) values (0, '09/11/2021 ', '09/11/2021 ', '7 14 21 DIAS', 3, 5.26, 12.32, 0);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '7 14 21 DIAS'), 1, 7, 33.33, 1);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '7 14 21 DIAS'), 2, 14, 33.33, 1);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '7 14 21 DIAS'), 3, 21, 33.34, 2);

insert into marcas (codigoUsu, dataCad, dataUltAlt, marca) values (0, '09/11/2021 ', '09/11/2021 ', 'HP');
insert into marcas (codigoUsu, dataCad, dataUltAlt, marca) values (0, '09/11/2021 ', '09/11/2021 ', 'EPSON');

insert into modelos (codigoUsu, dataCad, dataUltAlt, modelo, descricao, codigoMarca) values (0, '09/11/2021 ', '09/11/2021 ', 'L4260 WI-FI DUPLEX', '', 2);
insert into modelos (codigoUsu, dataCad, dataUltAlt, modelo, descricao, codigoMarca) values (0, '09/11/2021 ', '09/11/2021 ', 'DESKJET 3022', '', 1);
insert into modelos (codigoUsu, dataCad, dataUltAlt, modelo, descricao, codigoMarca) values (0, '09/11/2021 ', '09/11/2021 ', 'CARTUCHO 664XL', 'CARTUCHO HP 664XL PRETO ORIGINAL (F6V31AB) PARA HP DESKJET 2136, 2676, 3776, 5076, 5276 CX 1 UN', 1);

insert into grupos (codigoUsu, dataCad, dataUltAlt, grupo) values (0, '09/11/2021 ', '09/11/2021 ', 'IMPRESSORAS');
insert into grupos (codigoUsu, dataCad, dataUltAlt, grupo) values (0, '09/11/2021 ', '09/11/2021 ', 'CARTUCHOS');

insert into subgrupos (codigoUsu, dataCad, dataUltAlt, subgrupo, codigoGrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'RESIDENCIAL', 1);
insert into subgrupos (codigoUsu, dataCad, dataUltAlt, subgrupo, codigoGrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'SEMI PROFISSIONAL', 1);
insert into subgrupos (codigoUsu, dataCad, dataUltAlt, subgrupo, codigoGrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'PROFISSIONAL', 1);
insert into subgrupos (codigoUsu, dataCad, dataUltAlt, subgrupo, codigoGrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'TINTA', 2);
insert into subgrupos (codigoUsu, dataCad, dataUltAlt, subgrupo, codigoGrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'LASER', 2);

insert into fornecedores (codigoUsu, dataCad, dataUltAlt, logradouro, numero, complemento, bairro, cep, tel_Celular, email, codigoCidade, cnpj_cpf, inscEst_rg, dataFund_Nasc, fornecedor, codigoCondPag) values (0, '09/11/2021 ', '09/11/2021 ', 'ORFANATO', 760, '', 'VILA PRUDENTE', '03131-010', 1140047751, 'ATENDIMENTO@UNITECSYS.COM.BR', 9, '12.167.810/0001-16', 16146546151, '01/01/1938', 'HEWLETT-PACKARD DEVELOPMENT COMPANY, L.P. (HP)', 1);

insert into produtos (codigoUsu, dataCad, dataUltAlt, produto, referencia, codigoBarras, custo, unidade, saldo, peso_bruto, peso_liquid, precoUltCompra, codigoModelo, codigoSubgrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'IMPRESSORA DESKJET 3022', 'SDADSA', 7578575785785876786, 0, 'UND', 0, 60, 50, 0, 2, 2);
	insert into produto_fornecedor (codigoProduto, codigoFornecedor) values ((select codigo from produtos where produto = 'IMPRESSORA DESKJET 3022'), 1);
insert into produtos (codigoUsu, dataCad, dataUltAlt, produto, referencia, codigoBarras, custo, unidade, saldo, peso_bruto, peso_liquid, precoUltCompra, codigoModelo, codigoSubgrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'CARTUCHO HP 664XL PRETO', 'F6V31AB', 165313313651563, 0, 'UND', 0, 0.013, 0.010, 0, 3, 4);
	insert into produto_fornecedor (codigoProduto, codigoFornecedor) values ((select codigo from produtos where produto = 'CARTUCHO HP 664XL PRETO'), 1);
insert into produtos (codigoUsu, dataCad, dataUltAlt, produto, referencia, codigoBarras, custo, unidade, saldo, peso_bruto, peso_liquid, precoUltCompra, codigoModelo, codigoSubgrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'CARTUCHO HP 664XL COLORIDO', 'F6V28AB', 956565655, 0, 'UND', 0, 0.013, 0.010, 0, 3, 4);
	insert into produto_fornecedor (codigoProduto, codigoFornecedor) values ((select codigo from produtos where produto = 'CARTUCHO HP 664XL COLORIDO'), 1);
