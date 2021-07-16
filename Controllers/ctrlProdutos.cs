using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlProdutos : controllers
    {
        public const string camposSelect = "produtos.codigo, produto, custo, unidade, saldo, " +
                                           "referencia as referência, codigoBarras, " +
                                           "modelo, subgrupo, " +
                                           "produtos.codigoUsu as usuário, " +
                                           "produtos.dataCad as cadastro, " +
                                           "produtos.dataUltAlt as ultima_Alteração";
        public const string camposSelectProduto_Forn = "codigoFornecedor, codigoProduto";

        private ctrlSubgrupos umaCtrlSubgrupo;
        private ctrlModelos umaCtrlModelo;
        private ctrlFornecedores umCtrlFornecedor;

        private DAOs.daoProdutos umDaoProdutos;

        public ctrlProdutos()
        {
            umDaoProdutos = new DAOs.daoProdutos();
            umaCtrlModelo = new ctrlModelos();
            umCtrlFornecedor = new ctrlFornecedores();
            umaCtrlSubgrupo = new ctrlSubgrupos();
        }

        public ctrlProdutos(BancoDados.conexoes pUmaConexao)
        {
            umDaoProdutos = new DAOs.daoProdutos();
            umaCtrlModelo = new ctrlModelos(pUmaConexao);
            umCtrlFornecedor = new ctrlFornecedores(pUmaConexao);
            umaCtrlSubgrupo = new ctrlSubgrupos(pUmaConexao);

            UmaConexao = pUmaConexao;
        }

        public ctrlModelos CTRLModelo
        { get => umaCtrlModelo; }
        public ctrlFornecedores CTRLFornecedor
        { get => umCtrlFornecedor; }
        public ctrlSubgrupos CTRLSubgrupo
        { get => umaCtrlSubgrupo; }

        public override string Inserir(object pObjeto)
        {
            var vlProduto = (Classes.produtos)pObjeto;
            var vlInserir = umDaoProdutos.Inserir(pObjeto) +
                            umDaoProdutos.InserirProdForn(vlProduto.ListaFornecedores,
                                vlProduto.Produto);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Produto '{vlProduto.Produto}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Produto '{vlProduto.Produto}' já esta cadastrada!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var vlProduto = (Classes.produtos)pObjeto;
            var vlInserir = umDaoProdutos.Alterar(pObjeto) +
                            umDaoProdutos.AlterarProdForn(vlProduto.ListaFornecedores, vlProduto.Codigo);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Produto '{vlProduto.Produto}' alterado com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlPais = (Classes.paises)pObjeto;
                return $"Existe um registro que depende do produto '{vlProduto.Produto}'\n" +
                       $"Não foi possivel excluir o produto!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlProduto = (Classes.produtos)pObjeto;
            var vlInserir = umDaoProdutos.ExcluirProdForn(vlProduto.ListaFornecedores, vlProduto.Codigo) +
                            umDaoProdutos.Excluir(pObjeto);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Produto '{vlProduto.Produto}' excluido com {msg}!";
            }
            return msg;
        }
        public List<Classes.produtos> PesquisarCollection()
        {
            var camposSelList = camposSelect.Replace("produtos.", "");
            camposSelList = camposSelList.Replace("subgrupo", "codigoSubgrupo");
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoProdutos.PesquisarToString("produtos",
                       camposSelect.Replace("modelo", "codigoModelo"), "", ""));
            if (vlTabelaCondicoesPagamento == null)
            {
                return null;
            }
            else
            {
                List<Classes.produtos> lista = new List<Classes.produtos>();
                foreach (DataRow row in vlTabelaCondicoesPagamento.Rows)
                {
                    var vlProduto = new
                        Classes.produtos((int)row[0], (int)row[9],
                                         (string)row[10], (string)row[11],
                                         (string)row[1], (string)row[5],
                                         (string)row[6],
                                         decimal.Parse(row[2].ToString(), vgEstilo, vgProv),
                                         (int)row[3], (int)row[4]);
                    vlProduto.UmModelo.Codigo = (int)row[7];
                    var vlListaModelo = umaCtrlModelo.PesquisarCollection();
                    foreach (Classes.modelos vlModelo in vlListaModelo)
                    {
                        if (vlModelo.Codigo == vlProduto.UmModelo.Codigo)
                        { vlProduto.UmModelo.ThisModelo = vlModelo; }
                    }
                    vlProduto.UmSubgrupo.Codigo = (int)row[8];
                    var vlListaSubgrupo = umaCtrlSubgrupo.PesquisarCollection();
                    foreach (Classes.subgrupos vlSubgrupo in vlListaSubgrupo)
                    {
                        if (vlSubgrupo.Codigo == vlProduto.UmSubgrupo.Codigo)
                        { vlProduto.UmSubgrupo.ThisSubgrupo = vlSubgrupo; }
                    }
                    vlProduto.ListaFornecedores = PesquisarCollection(vlProduto.Codigo);
                    lista.Add(vlProduto);
                }
                return lista;
            }
        }

        public List<Classes.fornecedores> PesquisarCollection(int pCodigoProduto)
        {
            DataTable vlTabelaParcalasCondPag =
                ExecuteComandSearchQuery(
                    umDaoProdutos.PesquisarToString("produto_fornecedor",
                                                   camposSelectProduto_Forn,
                                                   "codigoProduto", pCodigoProduto.ToString()));
            if (vlTabelaParcalasCondPag == null)
            {
                return null;
            }
            else
            {
                var listaFornecedores = new List<Classes.fornecedores>();
                foreach (DataRow row in vlTabelaParcalasCondPag.Rows)
                {
                    var vlCodigoForn = (int)row[0];
                    var vlListaForn = umCtrlFornecedor.PesquisarCollection();
                    foreach (Classes.fornecedores vlForn in vlListaForn)
                    {
                        if (vlForn.Codigo == vlCodigoForn)
                        { listaFornecedores.Add(vlForn); }
                    }
                }
                return listaFornecedores;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor)
        {
            var vlProduto = new Classes.produtos();
            return ExecuteComandSearchQuery(
                       umDaoProdutos.PesquisarToString("produtos, subgrupos, modelos",
                       camposSelect, pCampo, pValor, vlProduto.toStringSearchPesquisa()));
        }
    }
}
