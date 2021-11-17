using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlContasPagar : ctrl
    {
        public const string camposSelect =  "modelo, serie, numero_nf, fornecedor, " +
                                            "parcela, vencimento, formaPagamento, " +
                                            "valorTotal, valorPago, dataPagamento, " +
                                            "contas_Pagar.dataCad, contas_Pagar.codigoUsu, " +
                                            "descontoPag as Desconto, taxaJuros as Juros, multa";

        private ctrlFormasPagamento umCtrlFormaPag;
        private ctrlFornecedores umCtrlForn;

        private DAOs.daoContasPagar umDaoContasPag;

        public ctrlContasPagar(BancoDados.conexoes pUmaConexao, DAOs.daoContasPagar pDaoContaPag,
            Controllers.ctrlFornecedores pCtrlForn, Controllers.ctrlFormasPagamento pCtrlFomaPag)
        {
            umDaoContasPag = pDaoContaPag;
            umCtrlFormaPag = pCtrlFomaPag;
            umCtrlForn = pCtrlForn;
            UmaConexao = pUmaConexao;
        }

        public ctrlFormasPagamento CTRLFormaPag
        { get => umCtrlFormaPag; }
        public ctrlFornecedores CTRLForn
        { get => umCtrlForn; }

        public override string Inserir(object pObjeto)
        {
            var vlConta = (Classes.contasPagar)pObjeto;
            var msg = ExecucaoComandQuery(umDaoContasPag.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Conta a pagar inserida com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Conta a pagar já esta cadastrada!";
            }
            return msg;
        }

        public string Inserir(List<Classes.contasPagar> pListContas, bool pSql)
        {
            var msg = "";
            foreach (Classes.contasPagar vlConta in pListContas)
            {
                msg += umDaoContasPag.Inserir(vlConta) + '\n';
            }
            if (pSql)
                return msg;
            else
            {
                msg = ExecucaoComandQuery(msg);
                if (msg == "sucesso")
                {
                    return $"Conta a pagar inserida com {msg}!";
                }
                else if (msg.Contains("chave duplicada"))
                {
                    return $"Conta a pagar já esta cadastrada!";
                }
                return msg;
            }
        }
        public string Excluir(List<Classes.contasPagar> pListContas, bool pSql)
        {
            var msg = "";
            foreach (Classes.contasPagar vlConta in pListContas)
            {
                msg += umDaoContasPag.Excluir(vlConta) + '\n';
            }
            if (pSql)
                return msg;
            else
            {
                msg = ExecucaoComandQuery(msg);
                if (msg == "sucesso")
                {
                    return $"Conta a pagar cancelada com {msg}!";
                }
                if (msg.Contains("DELETE conflitou"))
                {
                    return $"Existe um registro que depende de uma das parcelas das " +
                           $"contas a pagar relacionadas a chave:\n" +
                           $"Modelo:    {pListContas[0].PK.Split(';')[0]}\n" +
                           $"Serie:     {pListContas[0].PK.Split(';')[1]}\n" +
                           $"Número NF: {pListContas[0].PK.Split(';')[2]}\n" +
                           $"Parcelas:  {1}-{pListContas.Count()}\n" +
                           $"Não foi possivel excluir as parcelas das contas a pagar!";
                }
                return msg;
            }
        }
        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoContasPag.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlConta = (Classes.contasPagar)pObjeto;
                return $"Conta a pagar alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoContasPag.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlConta = (Classes.contasPagar)pObjeto;
                return $"Conta a pagar excluida com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlConta = (Classes.contasPagar)pObjeto;
                return $"Existe um registro que depende desta conta a pagar\n" +
                       $"Não foi possivel excluir a conta a pagar!";
            }
            return msg;
        }
        public List<Classes.contasPagar> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("contas_Pagar.", ""); 
            camposSelList = camposSelList.Replace("formaPagamento", "codigoFormaPag");
            DataTable vlTabelaCidades =
                 ExecuteComandSearchQuery(
                       umDaoContasPag.PesquisarToString("contas_Pagar",
                       camposSelList.Replace("fornecedor", "codigoForn"), "", ""), out pMsg);

            if (vlTabelaCidades.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.contasPagar> lista = new List<Classes.contasPagar>();
                foreach (DataRow row in vlTabelaCidades.Rows)
                {
                    var vlConta = new Classes.contasPagar((string)row[0], (string)row[1], (string)row[2],
                                                          (int)row[4], (string)row[5], (string)row[9],
                                                          decimal.Parse(row[7].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                                          (int)row[11], (string)row[10],
                                                          decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[13].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[14].ToString(), vgEstilo, vgProv));

                    vlConta.UmFornecedor = (Classes.fornecedores)umCtrlForn.Pesquisar("codigo",
                                                                            ((int)row[3]).ToString(),
                                                                            out string vlMsgForn,
                                                                            true);
                    vlConta.UmaFormaPag = (Classes.formasPagamento)umCtrlFormaPag.Pesquisar("codigo",
                                                                            ((int)row[6]).ToString(),
                                                                            out string vlMsgFormaPag,
                                                                            true);
                    pMsg += vlMsgForn + vlMsgFormaPag;
                    lista.Add(vlConta);
                }
                pMsg = "";
                return lista;
            }
        }
        public List<Classes.contasPagar> PesquisarCollection(string[] pCampo, string[] pValor, out string pMsg)
        {
            var camposSelList = camposSelect.Replace("contas_Pagar.", "");
            camposSelList = camposSelList.Replace("formaPagamento", "codigoFormaPag");
            DataTable vlTabelaCidades =
                 ExecuteComandSearchQuery(
                       umDaoContasPag.PesquisarToString("contas_Pagar",
                       camposSelList.Replace("fornecedor", "codigoForn"), pCampo, pValor, default, true),
                       out pMsg);
            if (vlTabelaCidades.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                var vlListaContasPag = new List<Classes.contasPagar>();
                foreach (DataRow row in vlTabelaCidades.Rows)
                {
                    var vlConta = new Classes.contasPagar((string)row[0], (string)row[1], (string)row[2],
                                                          (int)row[4], (string)row[5], (string)row[9],
                                                          decimal.Parse(row[7].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                                          (int)row[11], (string)row[10],
                                                          decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[13].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[14].ToString(), vgEstilo, vgProv));

                    vlConta.UmFornecedor = (Classes.fornecedores)umCtrlForn.Pesquisar("codigo",
                                                                            ((int)row[3]).ToString(),
                                                                            out string vlMsgForn,
                                                                            true);
                    vlConta.UmaFormaPag = (Classes.formasPagamento)umCtrlFormaPag.Pesquisar("codigo",
                                                                            ((int)row[6]).ToString(),
                                                                            out string vlMsgFormaPag,
                                                                            true);
                    pMsg += vlMsgForn + vlMsgFormaPag;
                    vlListaContasPag.Add(vlConta);
                }
                return vlListaContasPag;
            }
        }
        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("contas_Pagar.", "");
            camposSelList = camposSelList.Replace("formaPagamento", "codigoFormaPag");
            DataTable vlTabelaCidades =
                 ExecuteComandSearchQuery(
                       umDaoContasPag.PesquisarToString("contas_Pagar",
                       camposSelList.Replace("fornecedor", "codigoForn"), pCampo, pValor, default, pValorIgual),
                       out pMsg);
            if (vlTabelaCidades.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCidades.Rows[0];
                var vlConta = new Classes.contasPagar((string)row[0], (string)row[1], (string)row[2],
                                                      (int)row[4], (string)row[5], (string)row[9],
                                                      decimal.Parse(row[7].ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                                      (int)row[11], (string)row[10],
                                                      decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[13].ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[14].ToString(), vgEstilo, vgProv));

                vlConta.UmFornecedor = (Classes.fornecedores)umCtrlForn.Pesquisar("codigo",
                                                                        ((int)row[3]).ToString(),
                                                                        out string vlMsgForn,
                                                                        true);
                vlConta.UmaFormaPag = (Classes.formasPagamento)umCtrlFormaPag.Pesquisar("codigo",
                                                                        ((int)row[6]).ToString(),
                                                                        out string vlMsgFormaPag,
                                                                        true);
                pMsg += vlMsgForn + vlMsgFormaPag;
                return vlConta;
            }
        }
        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlConta = new Classes.contasPagar();
            var vlTable = ExecuteComandSearchQuery(
                       umDaoContasPag.PesquisarToString("contas_Pagar, formasPagamento, fornecedores", camposSelect,
                       pCampo, pValor, vlConta.toStringSearchPesquisa(), pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
