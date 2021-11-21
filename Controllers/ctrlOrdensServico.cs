using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    class ctrlOrdensServico : ctrl
    {
        public const string camposSelect = "ordens_servico.codigo, ordens_servico.dataEntrega," +
                                           "ordens_servico.dataRealizacao, ordens_servico.numeroSerie," +
                                           "ordens_servico.garantia, cliente, condicaoPagamento," +
                                           "equipamento";

        public const string camposSelectItensServico = "codigoOS, codigoServico, codigoFuncionario," +
                                                       "quantidade";

        public const string camposSelectItensProduto = "codigoOS, produto, desconto, quantidade";

        private ctrlEquipamentos umaCtrlEquip;
        private ctrlClientes umaCtrlCliente;
        private ctrlProdutos umaCtrlProduto;
        private ctrlServicos umaCtrlServico;
        private ctrlFuncionarios umaCtrlFunc;
        private ctrlContasReceber umaCtrlContaReceber;

        private DAOs.daoOrdensServico umDaoOS;

        public ctrlOrdensServico(BancoDados.conexoes pUmaConexao, DAOs.daoOrdensServico pDaoOS,
                            ctrlEquipamentos pumaCtrlEquip, ctrlServicos pumaCtrlServico,
                            ctrlClientes pCtrlCliente, ctrlProdutos pCtrlProduto,
                            ctrlFuncionarios pCtrFuncionario, 
                            ctrlContasReceber pCtrlContaReceber)
        {
            umaCtrlEquip = pumaCtrlEquip;
            umaCtrlServico = pumaCtrlServico;
            umaCtrlCliente = pCtrlCliente;
            umaCtrlProduto = pCtrlProduto;
            umDaoOS = pDaoOS;
            umaCtrlContaReceber = pCtrlContaReceber;
            UmaConexao = pUmaConexao;
            umaCtrlFunc = pCtrFuncionario;
        }

        public ctrlEquipamentos CTRLEquipamento
        { get => umaCtrlEquip; }
        public ctrlFuncionarios CTRLFuncionario
        { get => umaCtrlFunc; }
        public ctrlServicos CTRLServico
        { get => umaCtrlServico; }
        public ctrlContasReceber CTRLContasReceber
        { get => umaCtrlContaReceber; }
        public ctrlClientes CTRLCliente
        { get => umaCtrlCliente; }
        public ctrlProdutos CTRLProduto
        { get => umaCtrlProduto; }

        public override string Inserir(object pObjeto)
        {
            var conn = new SqlCommand();
            string vlTitle = this.ToString().Replace("Projeto_ICI.Controllers.ctrl", "Controller ") + ":\n";
            var vlMsg = "";
            try
            {
                if (conn == null && conn.Transaction == null)
                { return "Erro ao conectar ao banco de dados"; }

                vlMsg = vlTitle + "Erro ao conectar ao banco de dados (linhas: 54-55)\n";
                conn.Connection = conexao.OpenConnection;
                conn.Transaction = conexao.OpenConnection.BeginTransaction();

                var vlVenda = (Classes.ordensServico)pObjeto;
                conn.CommandText = umDaoOS.Inserir(pObjeto);

                vlVenda.Codigo = (int)conn.ExecuteScalar();
                vlVenda.setCodigoListasOS();

                conn.CommandText = umDaoOS.InserirItensProdutos(vlVenda.UmaListaItensProduto) +
                                   umDaoOS.InserirItensServicos(vlVenda.UmaListaItensServico) +
                                   umaCtrlContaReceber.Inserir(vlVenda.UmaListaContasReceber, true); 

                vlMsg = vlTitle + "Erro ao finalizar execução no Bando de dados (linhas: 62-64)\n";
                conn.ExecuteNonQuery();
                conn.Transaction.Commit();
                conexao.CloseConnection();
                return "sucesso";
            }
            catch (SqlException e)
            {
                if (conn.Transaction != null)
                { conn.Transaction.Rollback(); }
                return vlMsg + e.Message;
            }
        }

        public override string Alterar(object pObjeto)
        {
            var vlVenda = (Classes.ordensServico)pObjeto;
            vlVenda.setCodigoListasOS();
            var vlInserir = umDaoOS.Alterar(pObjeto) +
                            umDaoOS.AlterarItensProdutos(vlVenda.UmaListaItensProduto) +
                            umDaoOS.AlterarItensServicos(vlVenda.UmaListaItensServico);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Venda alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlVenda = (Classes.ordensServico)pObjeto;
            vlVenda.setCodigoListasOS();
            var vlInserir = umaCtrlContaReceber.Excluir(vlVenda.UmaListaContasReceber, true) +
                            umDaoOS.ExcluirItensProdutos(vlVenda.UmaListaItensProduto) +
                            umDaoOS.ExcluirItensServicos(vlVenda.UmaListaItensServico) +
                            umDaoOS.Excluir(pObjeto);

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
                       umDaoOS.PesquisarToString("vendas",
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

                    //pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                    //vlVenda.UmaCondicaoPag =
                    //    (Classes.funcionarios)uma.Pesquisar("codigo",
                    //                                                         ((int)row[10]).ToString(),
                    //                                                         out string vlMsgCondPag,
                    //                                                         true);
                    //pMsg += vlMsgCondPag == "" ? "" : "\n" + vlMsgCondPag;
                    vlVenda.UmaListaItens = PesquisarCollection(vlVenda.ToStringPK, vlVenda.PK, out string vlMsgParc);


                    vlVenda.UmaListaContasReceber = CTRLContasReceber.PesquisarCollection(vlVenda.ToStringPK.Split(';'),
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
                    umDaoOS.PesquisarToString("produtos_venda",
                    "",
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
                       umDaoOS.PesquisarToString("vendas",
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
                //pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                //string pMsgTrans = "";
                //if ((int)row[9] != 0)
                //    vlVenda.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("codigo",
                //                                                                        ((int)row[9]).ToString(),
                //                                                                        out pMsgTrans,
                //                                                                        true);
                //pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                //vlVenda.UmaCondicaoPag =
                //    (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                //                                                         ((int)row[10]).ToString(),
                //                                                         out string vlMsgCondPag,
                //                                                         true);
                //pMsg += vlMsgCondPag == "" ? "" : "\n" + vlMsgCondPag;
                vlVenda.UmaListaItens = PesquisarCollection(vlVenda.ToStringPK, vlVenda.PK, out string vlMsgParc);


                vlVenda.UmaListaContasReceber = CTRLContasReceber.PesquisarCollection(vlVenda.ToStringPK.Split(';'),
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
                       umDaoOS.PesquisarToString("vendas",
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
                //pMsg += pMsgForn == "" ? "" : "\n" + pMsgForn;
                //string pMsgTrans = "";
                //if ((int)row[9] != 0)
                //    vlVenda.UmaTransportadora = (Classes.transportadoras)umaCtrlTransp.Pesquisar("codigo",
                //                                                                        ((int)row[9]).ToString(),
                //                                                                        out pMsgTrans,
                //                                                                        true);
                //pMsg += pMsgTrans == "" ? "" : "\n" + pMsgTrans;
                //vlVenda.UmaCondicaoPag =
                //    (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                //                                                         ((int)row[10]).ToString(),
                //                                                         out string vlMsgCondPag,
                //                                                         true);
                //pMsg += vlMsgCondPag == "" ? "" : "\n" + vlMsgCondPag;
                vlVenda.UmaListaItens = PesquisarCollection(vlVenda.ToStringPK, vlVenda.PK, out string vlMsgParc);


                vlVenda.UmaListaContasReceber = CTRLContasReceber.PesquisarCollection(vlVenda.ToStringPK.Split(';'),
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
                          umDaoOS.PesquisarToString("vendas, clientes, condicoesPagamento",
                          camposSelect, pCampo, pValor, vlVenda.toStringSearchPesquisa(), pValorIgual),
                          out pMsg);
            return vlTable;
        }
        public override DataTable Pesquisar(string[] pCampo, string[] pValor, bool pValorIgual, out string pMsg)
        {
            var vlVenda = new Classes.vendas();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoOS.PesquisarToString("vendas, clientes, condicoesPagamento",
                          camposSelect, pCampo, pValor, vlVenda.toStringSearchPesquisa(), pValorIgual),
                          out pMsg);
            return vlTable;
        }
    }
}
