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

        public ctrlDepositos()
        {
            umDaoDeposito = new DAOs.daoDepositos();
            umaCtrlCidade = new ctrlCidades();
            umaCtrlProduto = new ctrlProdutos();
        }

        public ctrlDepositos(BancoDados.conexoes pUmaConexao)
        {
            umDaoDeposito = new DAOs.daoDepositos();
            umaCtrlCidade = new ctrlCidades(pUmaConexao);
            umaCtrlProduto = new ctrlProdutos(pUmaConexao);
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
        public List<Classes.depositos> PesquisarCollection()
        {
            var camposSelList = camposSelect.Replace("depositos.", "");
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoDeposito.PesquisarToString("depositos",
                       camposSelList.Replace("cidade", "codigoCidade"), "", ""));
            if (vlTabelaCondicoesPagamento == null)
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
                    vlDeposito.UmaCidade.Codigo = (int)row[7];
                    var vlListaCidade = umaCtrlCidade.PesquisarCollection();
                    foreach (Classes.cidades vlCidade in vlListaCidade)
                    {
                        if (vlCidade.Codigo == vlDeposito.UmaCidade.Codigo)
                        { vlDeposito.UmaCidade.ThisCidade = vlCidade; }
                    }
                    vlDeposito.ListaProd = PesquisarCollection(vlDeposito.Codigo);
                    lista.Add(vlDeposito);
                }
                return lista;
            }
        }

        public List<Classes.produtos> PesquisarCollection(int pCodigoProduto)
        {
            DataTable vlTabelaProdutoDeposito =
                ExecuteComandSearchQuery(
                    umDaoDeposito.PesquisarToString("deposito_produto",
                                                   camposSelectProduto_Forn,
                                                   "codigoDeposito", pCodigoProduto.ToString()));
            if (vlTabelaProdutoDeposito == null)
            {
                return null;
            }
            else
            {
                var listaProdutos = new List<Classes.produtos>();
                foreach (DataRow row in vlTabelaProdutoDeposito.Rows)
                {
                    var vlCodigoProd = (int)row[0];
                    var vlListaProd = umaCtrlProduto.PesquisarCollection();
                    foreach (Classes.produtos vlDeposito in vlListaProd)
                    {
                        if (vlDeposito.Codigo == vlCodigoProd)
                        { listaProdutos.Add(vlDeposito); }
                    }
                }
                return listaProdutos;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor)
        {
            var vlDeposito = new Classes.depositos();
            return ExecuteComandSearchQuery(
                       umDaoDeposito.PesquisarToString("depositos, cidades", camposSelect,
                       pCampo, pValor, vlDeposito.toStringSearchPesquisa())); ;
        }
    }
}
