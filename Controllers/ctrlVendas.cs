using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlVendas : ctrl
    {
        public const string camposSelect = "modelo, serie, numero_nf, cliente, data_emissao as Emissão, " +
                                          "data_saida as Saída, total_nota as Total, " +
                                          "vendas.peso_bruto as Peso_Bruto, vendas.peso_liquido as Peso_Liquido," +
                                          "codigoTransp, condicaoPagamento as condição_pagamento, " +
                                          "vendas.codigoUsu";

        public const string camposSelectItens = "modelo, serie, numero_nf, codigoCliente, codigoProd, " +
                                                "unidade, quantidade, valor_un, desconto";

        private ctrlCondicoesPagamento umaCtrlCondPag;
        private ctrlTransportadoras umaCtrlTransp;
        private ctrlClientes umaCtrlCliente;
        private ctrlProdutos umaCtrlProduto;
        private ctrlContasReceber umaCtrlContaReceber;

        private DAOs.daoVendas umDaoVenda;

        public ctrlVendas(BancoDados.conexoes pUmaConexao, DAOs.daoVendas pDaoVenda,
                           ctrlTransportadoras pCtrlTransp, ctrlCondicoesPagamento pCtrlCondPag,
                           ctrlClientes pCtrlCliente, ctrlProdutos pCtrlProduto, ctrlContasReceber pCtrlContaReceber)
        {
            umaCtrlCondPag = pCtrlCondPag;
            umaCtrlTransp = pCtrlTransp;
            umaCtrlCliente = pCtrlCliente;
            umaCtrlProduto = pCtrlProduto;
            umDaoVenda = pDaoVenda;
            umaCtrlContaReceber = pCtrlContaReceber;
            UmaConexao = pUmaConexao;
        }

        public ctrlCondicoesPagamento CTRLCondicaoPag
        { get => umaCtrlCondPag; }
        public ctrlTransportadoras CTRLTransport
        { get => umaCtrlTransp; }
        public ctrlContasReceber CTRLContasPag
        { get => umaCtrlContaReceber; }
        public ctrlClientes CTRLCliente
        { get => umaCtrlCliente; }
        public ctrlProdutos CTRLProduto
        { get => umaCtrlProduto; }

        public override string Inserir(object pObjeto)
        {
            var vlVenda = (Classes.vendas)pObjeto;
            var vlInserir = umDaoVenda.Inserir(pObjeto) +
                            umDaoVenda.InserirItens(vlVenda.UmaListaItens,
                                                     vlVenda.PK) +
                            umaCtrlContaReceber.Inserir(vlVenda.UmaListaContasReceber, true);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Venda inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Venda já esta cadastrada!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var vlVenda = (Classes.vendas)pObjeto;
            var vlInserir = umDaoVenda.Alterar(pObjeto) +
                            umDaoVenda.AlterarItens(vlVenda.UmaListaItens,
                                                     vlVenda.PK);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Venda alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlVenda = (Classes.vendas)pObjeto;
            var vlInserir = umaCtrlContaReceber.Excluir(vlVenda.UmaListaContasReceber, true) +
                            umDaoVenda.Excluir(pObjeto);

            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Venda excluida com {msg}!";
            }
            return msg;
        }
        public List<Classes.vendas> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("vendas.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento " +
                                                  "condicaoPagamento as condição_pagamento",
                                                  "vendas.codigoCondPag");

            DataTable vlTabelaVendas =
                 ExecuteComandSearchQuery(
                       umDaoVenda.PesquisarToString("vendas",
                            camposSelect.Replace("cliente", "codigoCliente"), "", ""), out pMsg);
            if (vlTabelaVendas.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.vendas> lista = new List<Classes.vendas>();
                foreach (DataRow row in vlTabelaVendas.Rows)
                {
                    var vlVenda = new
                    Classes.vendas((string)row[0], (string)row[1], (string)row[2], (string)row[4],
                                    (string)row[5], (int)row[11], rowToDecimal(row, 7),
                                    rowToDecimal(row, 8), rowToDecimal(row, 6));

                    vlVenda.UmCliente = (Classes.clientes)umaCtrlCliente.Pesquisar("codigo",
                                                                                   ((int)row[3]).ToString(),
                                                                                   out string pMsgForn,
                                                                                   true);
                    pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                    string pMsgTrans = "";
                    if ((int)row[9] != 0)
                        vlVenda.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("codigo",
                                                                                            ((int)row[9]).ToString(),
                                                                                            out pMsgTrans,
                                                                                            true);
                    pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                    vlVenda.UmaCondicaoPag =
                        (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                             ((int)row[10]).ToString(),
                                                                             out string vlMsgCondPag,
                                                                             true);
                    pMsg += vlMsgCondPag == "" ? "" : "\n" + vlMsgCondPag;
                    vlVenda.UmaListaItens = PesquisarCollection(vlVenda.ToStringPK, vlVenda.PK, out string vlMsgParc);


                    vlVenda.UmaListaContasReceber = CTRLContasPag.PesquisarCollection(vlVenda.ToStringPK.Split(';'),
                                                                                     vlVenda.PK.Split(';'),
                                                                                     out string vlMsgContasPag);

                    pMsg += vlMsgContasPag == "" ? "" : "\nErro ao carrgar itens da venda\n-->" + vlMsgContasPag;
                    lista.Add(vlVenda);
                }
                return lista;
            }
        }

        public List<Classes.itensVenda> PesquisarCollection(string pStrPK, string pPK, out string pMsg)
        {
            DataTable vlTabelaParcalasCondPag =
                ExecuteComandSearchQuery(
                    umDaoVenda.PesquisarToString("produtos_compra",
                                                   camposSelectItens,
                                                   pStrPK.Split(';'), pPK.Split(';')), out pMsg);
            if (vlTabelaParcalasCondPag.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                var listaItens = new List<Classes.itensVenda>();
                foreach (DataRow row in vlTabelaParcalasCondPag.Rows)
                {
                    var vlItem = new Classes.itensVenda((string)row[0], (string)row[1], (string)row[2],
                                                         (string)row[5], (int)row[6],
                                                         rowToDecimal(row, 7), rowToDecimal(row, 8));
                    vlItem.UmCliente =
                        (Classes.clientes)umaCtrlCliente.Pesquisar("codigo",
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
            var camposSelList = camposSelect.Replace("vendas.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento as condição_pagamento",
                                                  "vendas.codigoCondPag");

            DataTable vlTabelaVendas =
                 ExecuteComandSearchQuery(
                       umDaoVenda.PesquisarToString("vendas",
                            camposSelList.Replace("cliente", "codigoCliente"), pCampo, pValor,
                            default, pValorIgual), out pMsg);

            if (vlTabelaVendas.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaVendas.Rows[0];
                var vlVenda = new
                    Classes.vendas((string)row[0], (string)row[1], (string)row[2], (string)row[4],
                                    (string)row[5], (int)row[11], rowToDecimal(row, 7),
                                    rowToDecimal(row, 8), rowToDecimal(row, 6));

                vlVenda.UmCliente = (Classes.clientes)umaCtrlCliente.Pesquisar("codigo",
                                                                               ((int)row[3]).ToString(),
                                                                               out string pMsgForn,
                                                                               true);
                pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                string pMsgTrans = "";
                if ((int)row[9] != 0)
                    vlVenda.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("codigo",
                                                                                        ((int)row[9]).ToString(),
                                                                                        out pMsgTrans,
                                                                                        true);
                pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                vlVenda.UmaCondicaoPag =
                    (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                         ((int)row[10]).ToString(),
                                                                         out string vlMsgCondPag,
                                                                         true);
                pMsg += vlMsgCondPag == "" ? "" : "\n" + vlMsgCondPag;
                vlVenda.UmaListaItens = PesquisarCollection(vlVenda.ToStringPK, vlVenda.PK, out string vlMsgParc);


                vlVenda.UmaListaContasReceber = CTRLContasPag.PesquisarCollection(vlVenda.ToStringPK.Split(';'),
                                                                                 vlVenda.PK.Split(';'),
                                                                                 out string vlMsgContasPag);

                pMsg += vlMsgContasPag == "" ? "" : "\nErro ao carrgar itens da venda\n-->" + vlMsgContasPag;
                return vlVenda;
            }
        }

        public override object Pesquisar(string[] pCampos, string[] pValores, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("vendas.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento as condição_pagamento",
                                                  "vendas.codigoCondPag");
            camposSelList = camposSelList.Replace("transpotadora", "codigoTransp");

            DataTable vlTabelaVendas =
                 ExecuteComandSearchQuery(
                       umDaoVenda.PesquisarToString("vendas",
                            camposSelList.Replace("cliente", "codigoCliente"), pCampos, pValores,
                            default, pValorIgual), out pMsg);

            if (vlTabelaVendas.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaVendas.Rows[0];
                var vlVenda = new
                    Classes.vendas((string)row[0], (string)row[1], (string)row[2], (string)row[4],
                                    (string)row[5], (int)row[11], rowToDecimal(row, 7),
                                    rowToDecimal(row, 8), rowToDecimal(row, 6));

                vlVenda.UmCliente = (Classes.clientes)umaCtrlCliente.Pesquisar("codigo",
                                                                               ((int)row[3]).ToString(),
                                                                               out string pMsgForn,
                                                                               true);
                pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                string pMsgTrans = "";
                if ((int)row[9] != 0)
                    vlVenda.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("codigo",
                                                                                        ((int)row[9]).ToString(),
                                                                                        out pMsgTrans,
                                                                                        true);
                pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                vlVenda.UmaCondicaoPag =
                    (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                         ((int)row[10]).ToString(),
                                                                         out string vlMsgCondPag,
                                                                         true);
                pMsg += vlMsgCondPag == "" ? "" : "\n" + vlMsgCondPag;
                vlVenda.UmaListaItens = PesquisarCollection(vlVenda.ToStringPK, vlVenda.PK, out string vlMsgParc);


                vlVenda.UmaListaContasReceber = CTRLContasPag.PesquisarCollection(vlVenda.ToStringPK.Split(';'),
                                                                                 vlVenda.PK.Split(';'),
                                                                                 out string vlMsgContasPag);

                pMsg += vlMsgContasPag == "" ? "" : "\nErro ao carrgar itens da venda\n-->" + vlMsgContasPag;
                return vlVenda;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlVenda = new Classes.vendas();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoVenda.PesquisarToString("vendas, clientes, condicoesPagamento",
                          camposSelect, pCampo, pValor, vlVenda.toStringSearchPesquisa(), pValorIgual),
                          out pMsg);
            return vlTable;
        }
        public override DataTable Pesquisar(string[] pCampo, string[] pValor, bool pValorIgual, out string pMsg)
        {
            var vlVenda = new Classes.vendas();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoVenda.PesquisarToString("vendas, clientes, condicoesPagamento",
                          camposSelect, pCampo, pValor, vlVenda.toStringSearchPesquisa(), pValorIgual),
                          out pMsg);
            return vlTable;
        }
    }
}
