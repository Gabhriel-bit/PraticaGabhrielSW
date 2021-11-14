using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlCompras : ctrl
    {
        public const string camposSelect = "modelo, serie, numero_nf, fornecedor, data_emissao as Emissão, " +
                                           "data_chegada as Chegada, total_nota as Total, " +
                                           "total_produtos as Total_Produtos, valor_frete as Frete, " +
                                           "valor_seguro as Seguro, out_desp as Outras_Deps, " +
                                           "compras.peso_bruto as Peso_Bruto, compras.peso_liquido as Peso_Liquido," +
                                           " transpotadora, condicaoPagamento as condição_pagamento, " +
                                           "compras.codigoUsu, chave_acesso";

        public const string camposSelectItens = "modelo, serie, numero_nf, codigoForn, codigoProd, " +
                                                "unidade, quantidade, valor_un, desconto";

        private ctrlCondicoesPagamento umaCtrlCondPag;
        private ctrlTransportadoras umaCtrlTransp;
        private ctrlFornecedores umaCtrlForn;
        private ctrlProdutos umaCtrlProduto;
        private ctrlContasPagar umaCtrlContaPagar;

        private DAOs.daoCompras umDaoCompra;

        public ctrlCompras(BancoDados.conexoes pUmaConexao, DAOs.daoCompras pDaoCondPag,
                           ctrlTransportadoras pCtrlTransp, ctrlCondicoesPagamento pCtrlCondPag,
                           ctrlFornecedores pCtrlForn, ctrlProdutos pCtrlProduto, ctrlContasPagar pCtrlContaPagar)
        {
            umaCtrlCondPag = pCtrlCondPag;
            umaCtrlTransp = pCtrlTransp;
            umaCtrlForn = pCtrlForn;
            umaCtrlProduto = pCtrlProduto;
            umDaoCompra = pDaoCondPag;
            umaCtrlContaPagar = pCtrlContaPagar;
            UmaConexao = pUmaConexao;
        }

        public ctrlCondicoesPagamento CTRLCondicaoPag
        { get => umaCtrlCondPag; }
        public ctrlTransportadoras CTRLTransport
        { get => umaCtrlTransp; }
        public ctrlContasPagar CTRLContasPag
        { get => umaCtrlContaPagar; }
        public ctrlFornecedores CTRLForn
        { get => umaCtrlForn; }
        public ctrlProdutos CTRLProduto
        { get => umaCtrlProduto; }

        public override string Inserir(object pObjeto)
        {
            var vlCompra = (Classes.compras)pObjeto;
            var vlInserir = umDaoCompra.Inserir(pObjeto) +
                            umDaoCompra.InserirItens(vlCompra.UmaListaItens,
                                                     vlCompra.PK) +
                            umaCtrlProduto.Alterar(vlCompra.UmaListaItens, true);
                            umaCtrlContaPagar.Inserir(vlCompra.UmaListaContasPagar, true);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Compra inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Compra já esta cadastrada!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var vlCompra = (Classes.compras)pObjeto;
            var vlInserir = umDaoCompra.Alterar(pObjeto) +
                            umDaoCompra.AlterarItens(vlCompra.UmaListaItens,
                                                     vlCompra.PK);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Compra alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlCompra = (Classes.compras)pObjeto;
            var vlInserir = umaCtrlContaPagar.Excluir(vlCompra.UmaListaContasPagar[0]) +
                            umDaoCompra.ExcluirItens(vlCompra.PK) +
                            umDaoCompra.Excluir(pObjeto);

            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Compra excluida com {msg}!";
            }
            return msg;
        }
        public List<Classes.compras> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("compras.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento " +
                                                  "as condição_pagamento", "codigoCondPag");
            camposSelList = camposSelect.Replace("transpotadora", "codigoTransp");

            DataTable vlTabelaCompras =
                 ExecuteComandSearchQuery(
                       umDaoCompra.PesquisarToString("compras",
                            camposSelect.Replace("fornecedor", "codigoForn"), "", ""), out pMsg);
            if (vlTabelaCompras.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.compras> lista = new List<Classes.compras>();
                foreach (DataRow row in vlTabelaCompras.Rows)
                {
                    var vlCompra = new
                        Classes.compras((string)row[0], (string)row[1], (string)row[2], (string)row[4],
                                        (string)row[5], (string)row[16],
                                        decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                        decimal.Parse(row[9].ToString(), vgEstilo, vgProv),
                                        decimal.Parse(row[10].ToString(), vgEstilo, vgProv), (int)row[15],
                                        decimal.Parse(row[11].ToString(), vgEstilo, vgProv),
                                        decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                        decimal.Parse(row[6].ToString(), vgEstilo, vgProv),
                                        decimal.Parse(row[7].ToString(), vgEstilo, vgProv));
                    vlCompra.UmFornecedor = (Classes.fornecedores)umaCtrlForn.Pesquisar("coddigo",
                                                                                        ((int)row[3]).ToString(),
                                                                                        out string pMsgForn,
                                                                                        true);
                    pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                    vlCompra.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("coddigo",
                                                                                        ((int)row[3]).ToString(),
                                                                                        out string pMsgTrans,
                                                                                        true);
                    pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                    vlCompra.UmaCondicaoPag =
                        (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                             ((int)row[2]).ToString(),
                                                                             out string vlMsgCondPag,
                                                                             true);
                    vlCompra.UmaListaItens = PesquisarCollection(vlCompra.ToStringPK, vlCompra.PK,
                                                                 out string vlMsgParc);
                    pMsg += vlMsgParc == "" ? "" : "\nErro ao carrgar itens da compra\n-->" + vlMsgParc;
                    lista.Add(vlCompra);
                }
                return lista;
            }
        }

        public List<Classes.itensCompra> PesquisarCollection(string pStrPK, string pPK, out string pMsg)
        {
            DataTable vlTabelaParcalasCondPag =
                ExecuteComandSearchQuery(
                    umDaoCompra.PesquisarToString("produtos_compra",
                                                   camposSelectItens,
                                                   pStrPK.Split(';'), pPK.Split(';')), out pMsg);
            if (vlTabelaParcalasCondPag.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                var listaItens = new List<Classes.itensCompra>();
                foreach (DataRow row in vlTabelaParcalasCondPag.Rows)
                {
                    var vlItem = new Classes.itensCompra((string)row[0], (string)row[1], (string)row[2],
                                                         (string)row[5], (int)row[6],
                                                         decimal.Parse(row[7].ToString(), vgEstilo, vgProv),
                                                         decimal.Parse(row[8].ToString(), vgEstilo, vgProv));
                    vlItem.UmFornecedor =
                        (Classes.fornecedores)umaCtrlForn.Pesquisar("codigo",
                                                                   ((int)row[3]).ToString(),
                                                                   out string vlMsgForn, true);
                    pMsg += vlMsgForn == "" ? "" : "\n" + vlMsgForn;
                    vlItem.UmProduto =
                        (Classes.produtos)umaCtrlProduto.Pesquisar("codigo",
                                                                   ((int)row[4]).ToString(),
                                                                   out string vlMsgProd, true);
                    pMsg += vlMsgProd == "" ? "" : "\n" + vlMsgProd;
                    listaItens.Add(vlItem);
                }
                return listaItens;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("compras.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento as condição_pagamento", "codigoCondPag");
            camposSelList = camposSelList.Replace("transpotadora", "codigoTransp");

            DataTable vlTabelaCompras =
                 ExecuteComandSearchQuery(
                       umDaoCompra.PesquisarToString("compras",
                            camposSelList.Replace("fornecedor", "codigoForn"), pCampo, pValor,
                            default, pValorIgual), out pMsg);

            if (vlTabelaCompras.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCompras.Rows[0];
                var vlCompra = new
                    Classes.compras((string)row[0], (string)row[1], (string)row[2], (string)row[4],
                                    (string)row[5], (string)row[16],
                                    decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[9].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[10].ToString(), vgEstilo, vgProv), (int)row[15],
                                    decimal.Parse(row[11].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[6].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[7].ToString(), vgEstilo, vgProv));
                vlCompra.UmFornecedor = (Classes.fornecedores)umaCtrlForn.Pesquisar("coddigo",
                                                                                    ((int)row[3]).ToString(),
                                                                                    out string pMsgForn,
                                                                                    true);
                pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                vlCompra.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("coddigo",
                                                                                    ((int)row[3]).ToString(),
                                                                                    out string pMsgTrans,
                                                                                    true);
                pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                vlCompra.UmaCondicaoPag =
                    (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                         ((int)row[2]).ToString(),
                                                                         out string vlMsgCondPag,
                                                                         true);
                vlCompra.UmaListaItens = PesquisarCollection(vlCompra.ToStringPK, vlCompra.PK, out string vlMsgParc);
                pMsg += vlMsgParc == "" ? "" : "\nErro ao carrgar itens da compra\n-->" + vlMsgParc;
                return vlCompra;
            }
        }

        public object Pesquisar(string[] pCampos, string[] pValores, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("compras.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento as condição_pagamento", "codigoCondPag");
            camposSelList = camposSelList.Replace("transpotadora", "codigoTransp");

            DataTable vlTabelaCompras =
                 ExecuteComandSearchQuery(
                       umDaoCompra.PesquisarToString("compras",
                            camposSelList.Replace("fornecedor", "codigoForn"), pCampos, pValores,
                            default, pValorIgual), out pMsg);

            if (vlTabelaCompras.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCompras.Rows[0];
                var vlCompra = new
                    Classes.compras((string)row[0], (string)row[1], (string)row[2], (string)row[4],
                                    (string)row[5], (string)row[16],
                                    decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[9].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[10].ToString(), vgEstilo, vgProv), (int)row[15],
                                    decimal.Parse(row[11].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[6].ToString(), vgEstilo, vgProv),
                                    decimal.Parse(row[7].ToString(), vgEstilo, vgProv));
                vlCompra.UmFornecedor = (Classes.fornecedores)umaCtrlForn.Pesquisar("coddigo",
                                                                                    ((int)row[3]).ToString(),
                                                                                    out string pMsgForn,
                                                                                    true);
                pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                vlCompra.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("coddigo",
                                                                                    ((int)row[3]).ToString(),
                                                                                    out string pMsgTrans,
                                                                                    true);
                pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                vlCompra.UmaCondicaoPag =
                    (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                         ((int)row[2]).ToString(),
                                                                         out string vlMsgCondPag,
                                                                         true);
                vlCompra.UmaListaItens = PesquisarCollection(vlCompra.ToStringPK, vlCompra.PK, out string vlMsgParc);
                pMsg += vlMsgParc == "" ? "" : "\nErro ao carrgar itens da compra\n-->" + vlMsgParc;
                return vlCompra;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlCompra = new Classes.compras();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoCompra.PesquisarToString("compras, fornecedores, transportadoras, condicoesPagamento",
                          camposSelect, pCampo, pValor, vlCompra.toStringSearchPesquisa(), pValorIgual),
                          out pMsg);
            return vlTable;
        }
    }
}
