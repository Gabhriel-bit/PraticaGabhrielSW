use praticaDBGabhriel
insert into paises (codigoUsu, dataCad, dataUltAlt, pais, moeda, ddi, sigla) values (0, '09/11/2021 ', '09/11/2021 ', 'BRASIL', 'R$', '+55', 'BRA');

insert into estados (codigoUsu, dataCad, dataUltAlt, estado, uf, codigoPais) values (0, '09/11/2021 ', '09/11/2021 ', 'PARANÁ', 'PR', 1);
insert into estados (codigoUsu, dataCad, dataUltAlt, estado, uf, codigoPais) values (0, '09/11/2021 ', '09/11/2021 ', 'MATO GROSSO DO SUL', 'MS', 1);
insert into estados (codigoUsu, dataCad, dataUltAlt, estado, uf, codigoPais) values (0, '09/11/2021 ', '09/11/2021 ', 'SÃO PAULO', 'SP', 1);

insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'FOZ DO IGUAÇU', 45, 1);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'CASCAVEL', 45, 1);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'DOURADOS', 67, 2);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'CAMPO GRANDE', 67, 2);
insert into cidades (codigoUsu, dataCad, dataUltAlt, cidade, ddd, codigoEstado) values (0, '09/11/2021 ', '09/11/2021 ', 'SÃO PAULO', 11, 3);

insert into formasPagamento (codigoUsu, dataCad, dataUltAlt, formaPagamento) values (0, '09/11/2021 ', '09/11/2021 ', 'VISTA');
insert into formasPagamento (codigoUsu, dataCad, dataUltAlt, formaPagamento) values (0, '09/11/2021 ', '09/11/2021 ', 'BOLETO');

insert into condicoesPagamento (codigoUsu, dataCad, dataUltAlt, condicaoPagamento, totalParcelas, taxaJuros, multa, desconto) values (0, '09/11/2021 ', '09/11/2021 ', '30 DIAS', 1, 6.32, 12, 0);
insert into condicoesPagamento (codigoUsu, dataCad, dataUltAlt, condicaoPagamento, totalParcelas, taxaJuros, multa, desconto) values (0, '09/11/2021 ', '09/11/2021 ', '30 60 DIAS', 2, 6.23, 12, 0);
insert into condicoesPagamento (codigoUsu, dataCad, dataUltAlt, condicaoPagamento, totalParcelas, taxaJuros, multa, desconto) values (0, '09/11/2021 ', '09/11/2021 ', '7 14 21 DIAS', 3, 5.26, 12.32, 0);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '7 14 21 DIAS'), 1, 7, 33.33, 1);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '7 14 21 DIAS'), 2, 14, 33.33, 1);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '7 14 21 DIAS'), 3, 21, 33.34, 2);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '30 60 DIAS'), 1, 30, 50, 1);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '30 60 DIAS'), 2, 60, 50, 2);
	insert into parcelasCondicaoPagamento (codigoCondPag, numero, dias, porcentagem, codigoFormaPagamento) values ((select codigo from condicoesPagamento where condicaoPagamento = '30 DIAS'), 1, 30, 100, 1);

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

insert into fornecedores (codigoUsu, dataCad, dataUltAlt, logradouro, numero, complemento, bairro, cep, tel_Celular, email, codigoCidade, cnpj_cpf, inscEst_rg, dataFund_Nasc, fornecedor, codigoCondPag) values (0, '09/11/2021 ', '09/11/2021 ', 'ORFANATO', 760, '', 'VILA PRUDENTE', '03131-010', 1140047751, 'ATENDIMENTO@UNITECSYS.COM.BR', 5, '12.167.810/0001-16', 16146546151, '01/01/1938', 'HEWLETT-PACKARD DEVELOPMENT COMPANY, L.P. (HP)', 1);

insert into produtos (codigoUsu, dataCad, dataUltAlt, produto, referencia, codigoBarras, custo, precoVenda, unidade, saldo, peso_bruto, peso_liquid, precoUltCompra, codigoModelo, codigoSubgrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'IMPRESSORA DESKJET 3022', 'SDADSA', 7578575785785876786, 0, 32.65, 'UND', 0, 60, 50, 0, 2, 2);
insert into produtos (codigoUsu, dataCad, dataUltAlt, produto, referencia, codigoBarras, custo, precoVenda, unidade, saldo, peso_bruto, peso_liquid, precoUltCompra, codigoModelo, codigoSubgrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'CARTUCHO HP 664XL PRETO', 'F6V31AB', 165313313651563, 0, 35.55, 'UND', 0, 0.013, 0.010, 0, 3, 4);
insert into produtos (codigoUsu, dataCad, dataUltAlt, produto, referencia, codigoBarras, custo, precoVenda, unidade, saldo, peso_bruto, peso_liquid, precoUltCompra, codigoModelo, codigoSubgrupo) values (0, '09/11/2021 ', '09/11/2021 ', 'CARTUCHO HP 664XL COLORIDO', 'F6V28AB', 956565655, 0, 26.70, 'UND', 0, 0.013, 0.010, 0, 3, 4);
	insert into produto_fornecedor (codigoProduto, codigoFornecedor) values ((select codigo from produtos where produto = 'CARTUCHO HP 664XL COLORIDO'), 1);
	insert into produto_fornecedor (codigoProduto, codigoFornecedor) values ((select codigo from produtos where produto = 'IMPRESSORA DESKJET 3022'), 1);
	insert into produto_fornecedor (codigoProduto, codigoFornecedor) values ((select codigo from produtos where produto = 'CARTUCHO HP 664XL PRETO'), 1);


insert into compras (modelo, serie, numero_nf, codigoForn, data_emissao, data_chegada, total_nota, total_produtos, chave_acesso, codigoUsu, valor_frete, valor_seguro, out_desp, peso_bruto, peso_liquido, codigoTransp, codigoCondPag) values ('MODELO', 'SERIE', 123465789, 1, '17/11/2021', '17/11/2021', 4822.68, 4822.68, '', 0, 0, 0, 0, 60.0260, 50.0200, 0, 3);
insert into produtos_compra (modelo, serie, numero_nf, codigoForn, unidade, quantidade, valor_un, desconto, codigoProd) values ('MODELO', 'SERIE', 123465789, 1, 'UND', 3, 1548.05, 152.6, 1);
insert into produtos_compra (modelo, serie, numero_nf, codigoForn, unidade, quantidade, valor_un, desconto, codigoProd) values ('MODELO', 'SERIE', 123465789, 1, 'UND', 3, 98.23, 0, 2);
insert into produtos_compra (modelo, serie, numero_nf, codigoForn, unidade, quantidade, valor_un, desconto, codigoProd) values ('MODELO', 'SERIE', 123465789, 1, 'UND', 3, 129.20, 15.32, 3);
UPDATE produtos SET codigoUsu = 0, dataCad = '09/11/2021', dataUltAlt = '09/11/2021', produto = 'IMPRESSORA DESKJET 3022', referencia = 'SDADSA', codigoBarras = 7578575785785876786, custo = 1395.45, precoVenda = 32.6500, unidade = 'UND', saldo = 3, peso_bruto = 60.0000, peso_liquid = 50.0000, precoUltCompra = 1548.05, codigoModelo = 2, codigoSubgrupo = 2 WHERE codigo = 1; 
delete from produto_fornecedor where codigoProduto = 1;
insert into produto_fornecedor (codigoProduto, codigoFornecedor) values (1, 1);
UPDATE produtos SET codigoUsu = 0, dataCad = '09/11/2021', dataUltAlt = '09/11/2021', produto = 'CARTUCHO HP 664XL PRETO', referencia = 'F6V31AB', codigoBarras = 165313313651563, custo = 98.23, precoVenda = 35.5500, unidade = 'UND', saldo = 3, peso_bruto = 0.0130, peso_liquid = 0.0100, precoUltCompra = 98.23, codigoModelo = 3, codigoSubgrupo = 4 WHERE codigo = 2; 
delete from produto_fornecedor where codigoProduto = 2;
insert into produto_fornecedor (codigoProduto, codigoFornecedor) values (2, 1);
UPDATE produtos SET codigoUsu = 0, dataCad = '09/11/2021', dataUltAlt = '09/11/2021', produto = 'CARTUCHO HP 664XL COLORIDO', referencia = 'F6V28AB', codigoBarras = 956565655, custo = 113.88, precoVenda = 26.7000, unidade = 'UND', saldo = 3, peso_bruto = 0.0130, peso_liquid = 0.0100, precoUltCompra = 129.20, codigoModelo = 3, codigoSubgrupo = 4 WHERE codigo = 3; 
delete from produto_fornecedor where codigoProduto = 3;
insert into produto_fornecedor (codigoProduto, codigoFornecedor) values (3, 1);
insert into contas_pagar (modelo, serie, numero_nf, codigoForn, parcela, vencimento, dataPagamento, valorTotal, valorPago, codigoUsu, dataCad, codigoFormaPag, descontoPag, taxaJuros, multa) values ('MODELO', 'SERIE', 123465789, 1, 1, '24/11/2021', '', 1607.3992, 0, 0, '17/11/2021', 1, 0.0000, 5.2600, 12.3200);
insert into contas_pagar (modelo, serie, numero_nf, codigoForn, parcela, vencimento, dataPagamento, valorTotal, valorPago, codigoUsu, dataCad, codigoFormaPag, descontoPag, taxaJuros, multa) values ('MODELO', 'SERIE', 123465789, 1, 2, '01/12/2021', '', 1607.3992, 0, 0, '17/11/2021', 1, 0.0000, 5.2600, 12.3200);
insert into contas_pagar (modelo, serie, numero_nf, codigoForn, parcela, vencimento, dataPagamento, valorTotal, valorPago, codigoUsu, dataCad, codigoFormaPag, descontoPag, taxaJuros, multa) values ('MODELO', 'SERIE', 123465789, 1, 3, '08/12/2021', '', 1607.8815, 0, 0, '17/11/2021', 2, 0.0000, 5.2600, 12.3200);
