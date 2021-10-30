using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlProdutos : ctrl
    {
        public const string camposSelect = "produtos.codigo, " +
                                           "produto, " +
                                           "custo, " +
                                           "unidade, " +
                                           "saldo, " +
                                           "peso_bruto as Peso_bruto, " +
                                           "peso_liquid as Peso_liquido, " +
                                           "precoUltCompra as Ultima_compra, " +
                                           "referencia as referência, " +
                                           "codigoBarras, " +
                                           "modelo, " +
                                           "subgrupo, " +
                                           "produtos.codigoUsu as usuário, " +
                                           "produtos.dataCad as cadastro, " +
                                           "produtos.dataUltAlt as ultima_Alteração";
        public const string camposSelectProduto_Forn = "codigoFornecedor, codigoProduto";

        private ctrlSubgrupos umaCtrlSubgrupo;
        private ctrlModelos umaCtrlModelo;
        private ctrlFornecedores umCtrlFornecedor;

        private DAOs.daoProdutos umDaoProdutos;

        public ctrlProdutos(BancoDados.conexoes pUmaConexao, DAOs.daoProdutos pDaoProduto,
            Controllers.ctrlModelos pCtrlModelo, Controllers.ctrlSubgrupos pCtrlSubgrupo,
            Controllers.ctrlFornecedores pCtrlForn)
        {
            umDaoProdutos = pDaoProduto;
            umaCtrlModelo = pCtrlModelo;
            umCtrlFornecedor = pCtrlForn;
            umaCtrlSubgrupo = pCtrlSubgrupo;

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
        public string Alterar(List<Classes.itensCompra> pListaProdutos, bool pSql)
        {
            var vlInserir = "";
            foreach (Classes.itensCompra vlItem in pListaProdutos)
            {
                vlInserir += umDaoProdutos.Alterar(vlItem.UmProduto) +
                             umDaoProdutos.AlterarProdForn(vlItem.UmProduto.ListaFornecedores, vlItem.UmProduto.Codigo);
            }
            if (pSql)
                return vlInserir;
            else
            {
                var msg = ExecucaoComandQuery(vlInserir);
                if (msg == "sucesso")
                {
                    return $"Produto alterado com {msg}!";
                }
                if (msg.Contains("DELETE conflitou"))
                {
                    return $"Existe um registro que depende do produto\n" +
                           $"Não foi possivel excluir o produto!";
                }
                return msg;
            }

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
        public List<Classes.produtos> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("produtos.", "");
            camposSelList = camposSelList.Replace("subgrupo", "codigoSubgrupo");
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoProdutos.PesquisarToString("produtos",
                       camposSelList.Replace("modelo", "codigoModelo"), "", ""), out pMsg);

            if (vlTabelaCondicoesPagamento.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.produtos> lista = new List<Classes.produtos>();
                foreach (DataRow row in vlTabelaCondicoesPagamento.Rows)
                {
                    var vlProduto = new
                        Classes.produtos((int)row[0], (int)row[12],
                                         (string)row[13], (string)row[14],
                                         (string)row[1], (string)row[8],
                                         (string)row[9],
                                         decimal.Parse(row[2].ToString(), vgEstilo, vgProv),
                                         (string)row[3], (int)row[4],
                                         decimal.Parse(row[5].ToString(), vgEstilo, vgProv),
                                         decimal.Parse(row[6].ToString(), vgEstilo, vgProv),
                                         decimal.Parse(row[7].ToString(), vgEstilo, vgProv));
                    vlProduto.UmModelo = (Classes.modelos)umaCtrlModelo.Pesquisar("codigo",
                                                                                  ((int)row[10]).ToString(),
                                                                                  out string vlMsgModelo,
                                                                                  true);
                    string vlMsgSubgrupo = "";
                    if (row.IsNull("codigoSubgrupo"))
                    {
                        vlProduto.UmSubgrupo = (Classes.subgrupos)umaCtrlSubgrupo.Pesquisar("codigo",
                                                                                            ((int)row[11]).ToString(),
                                                                                            out vlMsgSubgrupo,
                                                                                            true);
                    }
                    vlProduto.ListaFornecedores = PesquisarCollection(vlProduto.Codigo, out string vlMsgForn);

                    pMsg += (vlMsgModelo == "" ? "" : vlMsgModelo) +
                            (vlMsgSubgrupo == "" ? "" : "\n" + vlMsgSubgrupo) +
                            (vlMsgForn == "" ? "" : "\n" + 
                            $"\nErro ao carrgar fornecedores do produto '{vlProduto.Produto}'\n-->" + vlMsgForn);

                    lista.Add(vlProduto);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("produtos.", "");
            camposSelList = camposSelList.Replace("subgrupo", "codigoSubgrupo");
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoProdutos.PesquisarToString("produtos",
                       camposSelList.Replace("modelo", "codigoModelo"), pCampo, pValor, default, pValorIgual),
                       out pMsg);

            if (vlTabelaCondicoesPagamento.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCondicoesPagamento.Rows[0];
                var vlProduto = new
                        Classes.produtos((int)row[0], (int)row[12],
                                         (string)row[13], (string)row[14],
                                         (string)row[1], (string)row[8],
                                         (string)row[9],
                                         decimal.Parse(row[2].ToString(), vgEstilo, vgProv),
                                         (string)row[3], (int)row[4],
                                         decimal.Parse(row[5].ToString(), vgEstilo, vgProv),
                                         decimal.Parse(row[6].ToString(), vgEstilo, vgProv),
                                         decimal.Parse(row[7].ToString(), vgEstilo, vgProv));
                vlProduto.UmModelo = (Classes.modelos)umaCtrlModelo.Pesquisar("codigo",
                                                                              ((int)row[10]).ToString(),
                                                                              out string vlMsgModelo,
                                                                              true);
                string vlMsgSubgrupo = "";
                if (row.IsNull("codigoSubgrupo"))
                {
                    vlProduto.UmSubgrupo = (Classes.subgrupos)umaCtrlSubgrupo.Pesquisar("codigo",
                                                                                        ((int)row[11]).ToString(),
                                                                                        out vlMsgSubgrupo,
                                                                                        true);
                }
                vlProduto.ListaFornecedores = PesquisarCollection(vlProduto.Codigo, out string vlMsgForn);

                pMsg += (vlMsgModelo == "" ? "" : vlMsgModelo) +
                        (vlMsgSubgrupo == "" ? "" : "\n" + vlMsgSubgrupo) +
                        (vlMsgForn == "" ? "" : "\n" +
                        $"\nErro ao carrgar fornecedores do produto '{vlProduto.Produto}'\n-->" + vlMsgForn);

                return vlProduto;
            }
        }

        public List<Classes.fornecedores> PesquisarCollection(int pCodigoProduto, out string pMsg)
        {
            DataTable vlTabelaParcalasCondPag =
                ExecuteComandSearchQuery(
                    umDaoProdutos.PesquisarToString("produto_fornecedor",
                                                   camposSelectProduto_Forn,
                                                   "codigoProduto", pCodigoProduto.ToString()), out string vlMsg);
            var vlListaForn = umCtrlFornecedor.PesquisarCollection(out string vlMsgForn);
            pMsg = vlMsg + '\n' + vlMsgForn;
            if (vlTabelaParcalasCondPag.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                var listaFornecedores = new List<Classes.fornecedores>();
                foreach (DataRow row in vlTabelaParcalasCondPag.Rows)
                {
                    var vlCodigoForn = (int)row[0];
                    foreach (Classes.fornecedores vlForn in vlListaForn)
                    {
                        if (vlForn.Codigo == vlCodigoForn)
                        { listaFornecedores.Add(vlForn); }
                    }
                }
                return listaFornecedores;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlProduto = new Classes.produtos();
            DataTable vlTable = ExecuteComandSearchQuery(
                                    umDaoProdutos.PesquisarToString("produtos, subgrupos, modelos",
                                    camposSelect, pCampo, pValor, vlProduto.toStringSearchPesquisa()), out pMsg);
            return vlTable;
        }
    }
}
