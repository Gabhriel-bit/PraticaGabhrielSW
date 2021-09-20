using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlCondicoesPagamento : controllers
    {
        public const string camposSelect = "codigo, condicaoPagamento, totalParcelas, taxaJuros, " +
                                           "multa, desconto, codigoUsu, dataCad, dataUltAlt";
        public const string camposSelectParcelas = "codigoCondPag, numero, dias, porcentagem," +
                                                   "codigoFormaPagamento";
        private ctrlFormasPagamento umaCtrlFromaPag;

        private DAOs.daoCondicoesPagamento umDaoCondPag;

        public ctrlCondicoesPagamento(BancoDados.conexoes pUmaConexao,
            Controllers.ctrlFormasPagamento pCtrlFormPag, DAOs.daoCondicoesPagamento pDaoCondPag)
        {
            umDaoCondPag = pDaoCondPag;
            umaCtrlFromaPag = pCtrlFormPag;
            UmaConexao = pUmaConexao;
        }

        public ctrlFormasPagamento CTRLFormaPagamento
        { get => umaCtrlFromaPag; }

        public override string Inserir(object pObjeto)
        {
            var vlCondPag = (Classes.condicoesPagamento)pObjeto;
            var vlInserir = umDaoCondPag.Inserir(pObjeto) +
                            umDaoCondPag.InserirParcelas(vlCondPag.ListaParcelas,
                                vlCondPag.CondicaoPag);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Condição de pagamento '{vlCondPag.CondicaoPag}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Condição de pagamento '{vlCondPag.CondicaoPag}' já esta cadastrada!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var vlCondPag = (Classes.condicoesPagamento)pObjeto;
            var vlInserir = umDaoCondPag.Alterar(pObjeto) +
                            umDaoCondPag.AlterarParcelas(vlCondPag.ListaParcelas,
                                                         vlCondPag.CondicaoPag);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Condição de pagamento '{vlCondPag.CondicaoPag}' alterada com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende da condição de pagamento '{vlCondPag.CondicaoPag}'\n" +
                       $"Não foi possivel excluir a condição de pagamento!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlCondPag = (Classes.condicoesPagamento)pObjeto;
            var vlInserir = umDaoCondPag.ExcluirParcelas(vlCondPag.ListaParcelas) +
                            umDaoCondPag.Excluir(pObjeto);
            var msg = ExecucaoComandQuery(vlInserir);
            if (msg == "sucesso")
            {
                return $"Condição de pagamento '{vlCondPag.CondicaoPag}' excluida com {msg}!";
            }
            return msg;
        }
        public List<Classes.condicoesPagamento> PesquisarCollection(out string pMsg)
        {
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoCondPag.PesquisarToString("condicoesPagamento",
                            camposSelect, "", ""), out pMsg);
            if (vlTabelaCondicoesPagamento.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.condicoesPagamento> lista = new List<Classes.condicoesPagamento>();
                foreach (DataRow row in vlTabelaCondicoesPagamento.Rows)
                {
                    var vlCondPag = new
                        Classes.condicoesPagamento((int)row[0], (int)row[6],
                                                   (string)row[7], (string)row[8],
                                                   (string)row[1], (int)row[2],
                                                   decimal.Parse(row[3].ToString(), vgEstilo, vgProv),
                                                   decimal.Parse(row[4].ToString(), vgEstilo, vgProv),
                                                   decimal.Parse(row[5].ToString(), vgEstilo, vgProv));
                    vlCondPag.ListaParcelas = PesquisarCollection(vlCondPag.Codigo, out string vlMsgParc);
                    pMsg += vlMsgParc == "" ? "" : "Erro ao carrgar parcelas " +
                        $"da condição de pagamento '{vlCondPag.CondicaoPag}'\n-->" + vlMsgParc;
                    lista.Add(vlCondPag);
                }
                return lista;
            }
        }

        public List<Classes.parcelasCondPag> PesquisarCollection(int pCodigoCondPang, out string pMsg)
        {
            DataTable vlTabelaParcalasCondPag =
                ExecuteComandSearchQuery(
                    umDaoCondPag.PesquisarToString("parcelasCondicaoPagamento",
                                                   camposSelectParcelas,
                                                   "codigoCondPag", pCodigoCondPang.ToString()), out pMsg);
            if (vlTabelaParcalasCondPag.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                var listaParcelas = new List<Classes.parcelasCondPag>();
                foreach (DataRow row in vlTabelaParcalasCondPag.Rows)
                {
                    var vlParcela = new Classes.parcelasCondPag((int)row[0], (int)row[1],
                                                                (int)row[2],
                                                                decimal.Parse(row[3].ToString(),
                                                                vgEstilo, vgProv));
                    vlParcela.UmaFormaPag = 
                        (Classes.formasPagamento)umaCtrlFromaPag.Pesquisar("codigo",
                                                                           ((int)row[4]).ToString(),
                                                                           out string vlMsgFormPag,
                                                                           true);
                    pMsg += vlMsgFormPag;
                    listaParcelas.Add(vlParcela);
                }
                return listaParcelas;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoCondPag.PesquisarToString("condicoesPagamento",
                            camposSelect, pCampo, pValor, default, pValorIgual), out pMsg);

            if (vlTabelaCondicoesPagamento.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCondicoesPagamento.Rows[0];
                var vlCondPag = new
                    Classes.condicoesPagamento((int)row[0], (int)row[6],
                                                (string)row[7], (string)row[8],
                                                (string)row[1], (int)row[2],
                                                decimal.Parse(row[3].ToString(), vgEstilo, vgProv),
                                                decimal.Parse(row[4].ToString(), vgEstilo, vgProv),
                                                decimal.Parse(row[5].ToString(), vgEstilo, vgProv));
                vlCondPag.ListaParcelas = PesquisarCollection(vlCondPag.Codigo, out string vlMsgParc);
                pMsg = vlMsgParc == "" ? "" : "Erro ao carrgar parcelas " +
                    $"da condição de pagamento '{vlCondPag.CondicaoPag}'\n-->" + vlMsgParc;

                return vlCondPag;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlTable = ExecuteComandSearchQuery(
                          umDaoCondPag.PesquisarToString("condicoesPagamento",
                            camposSelect, pCampo, pValor, default, pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
