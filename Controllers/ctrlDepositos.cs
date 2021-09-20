using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlDepositos : controllers
    {
        public const string camposSelect = "depositos.codigo, deposito, logradouro, numero, " +
                                           "complemento, bairro, cep as CEP, cidade, " +
                                           "depositos.codigoUsu as usuário, " +
                                           "depositos.dataCad as cadastro, " +
                                           "depositos.dataUltAlt as ultima_Alteração";
        public const string camposSelectProduto_Forn = "codigoProduto, codigoDeposito";

        private ctrlCidades umaCtrlCidade;
        private ctrlProdutos umaCtrlProduto;

        private DAOs.daoDepositos umDaoDeposito;

        public ctrlDepositos(BancoDados.conexoes pUmaConexao, DAOs.daoDepositos pDaoDeposito,
            Controllers.ctrlCidades pCtrlCidade, Controllers.ctrlProdutos pCtrlProduto)
        {
            umDaoDeposito = pDaoDeposito;
            umaCtrlCidade = pCtrlCidade;
            umaCtrlProduto = pCtrlProduto;
            UmaConexao = pUmaConexao;
        }

        public ctrlCidades CTRLCidade
        { get => umaCtrlCidade; }
        public ctrlProdutos CTRLProduto
        { get => umaCtrlProduto; }

        public override string Inserir(object pObjeto)
        {
            var vlDeposito = (Classes.depositos)pObjeto;
            var vlInserir = umDaoDeposito.Inserir(pObjeto) +
                            umDaoDeposito.InserirDepProd(vlDeposito.ListaProd,
                                vlDeposito.Deposito);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Produto '{vlDeposito.Deposito}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Produto '{vlDeposito.Deposito}' já esta cadastrada!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var vlDeposito = (Classes.depositos)pObjeto;
            var vlInserir = umDaoDeposito.Alterar(pObjeto) +
                            umDaoDeposito.AlterarDepProd(vlDeposito.ListaProd, vlDeposito.Codigo);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Deposito '{vlDeposito.Deposito}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlDeposito = (Classes.depositos)pObjeto;
            var vlInserir = umDaoDeposito.ExcluirProdForn(vlDeposito.ListaProd, vlDeposito.Codigo) +
                            umDaoDeposito.Excluir(pObjeto);

            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Deposito '{vlDeposito.Deposito}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do depósito '{vlDeposito.Deposito}'\n" +
                       $"Não foi possivel excluir o depósito!";
            }
            return msg;
        }
        public List<Classes.depositos> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("depositos.", "");
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoDeposito.PesquisarToString("depositos",
                       camposSelList.Replace("cidade", "codigoCidade"), "", ""), out pMsg);

            if (vlTabelaCondicoesPagamento.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.depositos> lista = new List<Classes.depositos>();
                foreach (DataRow row in vlTabelaCondicoesPagamento.Rows)
                {
                    var vlDeposito = new
                        Classes.depositos((int)row[0], (int)row[8],
                                         (string)row[9], (string)row[10],
                                         (string)row[1], (string)row[2],
                                         (string)row[3], (string)row[4],
                                         (string)row[5], (string)row[6]);
                    vlDeposito.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                                   ((int)row[7]).ToString(),
                                                                                   out string vlMsgCidade,
                                                                                   true);
                    
                    vlDeposito.ListaProd = PesquisarCollection(vlDeposito.Codigo, out string vlMsgProd);

                    pMsg += (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade) +
                            (vlMsgProd == "" ? "" :
                     $"\nErro ao carrgar produtos do Deposito '{vlDeposito.Deposito}'\n-->" + vlMsgProd);

                    lista.Add(vlDeposito);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            var camposSelList = camposSelect.Replace("depositos.", "");
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoDeposito.PesquisarToString("depositos",
                       camposSelList.Replace("cidade", "codigoCidade"), pCampo, pValor, default, pDisponivel),
                       out pMsg);

            if (vlTabelaCondicoesPagamento.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCondicoesPagamento.Rows[0];
                var vlDeposito = new
                    Classes.depositos((int)row[0], (int)row[8],
                                        (string)row[9], (string)row[10],
                                        (string)row[1], (string)row[2],
                                        (string)row[3], (string)row[4],
                                        (string)row[5], (string)row[6]);

                vlDeposito.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                                ((int)row[7]).ToString(),
                                                                                out string vlMsgCidade,
                                                                                true);

                vlDeposito.ListaProd = PesquisarCollection(vlDeposito.Codigo, out string vlMsgProd);

                pMsg = (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade) +
                        (vlMsgProd == "" ? "" :
                    $"\nErro ao carrgar produtos do Deposito '{vlDeposito.Deposito}'\n-->" + vlMsgProd);

                return vlDeposito;
            }
        }

        public List<Classes.produtos> PesquisarCollection(int pCodigoProduto, out string pMsg)
        {
            DataTable vlTabelaProdutoDeposito =
                ExecuteComandSearchQuery(
                    umDaoDeposito.PesquisarToString("deposito_produto",
                                                   camposSelectProduto_Forn,
                                                   "codigoDeposito", pCodigoProduto.ToString()), out string vlMsg);
            var vlListaProd = umaCtrlProduto.PesquisarCollection(out string vlMsgProd);
            pMsg = vlMsg + "\n-->" + vlMsgProd;
            if (vlTabelaProdutoDeposito.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                var listaProdutos = new List<Classes.produtos>();
                foreach (DataRow row in vlTabelaProdutoDeposito.Rows)
                {
                    var vlCodigoProd = (int)row[0];
                    foreach (Classes.produtos vlDeposito in vlListaProd)
                    {
                        if (vlDeposito.Codigo == vlCodigoProd)
                        { listaProdutos.Add(vlDeposito); }
                    }
                }
                return listaProdutos;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlDeposito = new Classes.depositos();
            var vlTable = ExecuteComandSearchQuery(
                         umDaoDeposito.PesquisarToString("depositos, cidades", camposSelect,
                         pCampo, pValor, vlDeposito.toStringSearchPesquisa(), pValorIgual), out string vlMsg);
            pMsg = vlMsg;
            return vlTable;
        }
    }
}
