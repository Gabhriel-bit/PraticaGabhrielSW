using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlContasReceber:ctrl
    {
        public const string camposSelect = "modelo, serie, numero_nf, cliente, " +
                                            "parcela, vencimento, formaPagamento, " +
                                            "valorTotal, valorPago, dataPagamento, " +
                                            "contas_receber.dataCad, contas_receber.codigoUsu, " +
                                            "descontoPag as Desconto, taxaJuros as Juros, multa";

        private ctrlFormasPagamento umCtrlFormaPag;
        private ctrlClientes umCtrlCliente;

        private DAOs.daoContasReceber umDaoContasReceb;

        public ctrlContasReceber(BancoDados.conexoes pUmaConexao, DAOs.daoContasReceber pDaoContaPag,
            Controllers.ctrlClientes pCtrlCliente, Controllers.ctrlFormasPagamento pCtrlFomaPag)
        {
            umDaoContasReceb = pDaoContaPag;
            umCtrlFormaPag = pCtrlFomaPag;
            umCtrlCliente = pCtrlCliente;
            UmaConexao = pUmaConexao;
        }

        public ctrlFormasPagamento CTRLFormaPag
        { get => umCtrlFormaPag; }
        public ctrlClientes CTRLForn
        { get => umCtrlCliente; }

        public override string Inserir(object pObjeto)
        {
            var vlConta = (Classes.contasReceber)pObjeto;
            var msg = ExecucaoComandQuery(umDaoContasReceb.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Conta a receber inserida com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Conta a receber já esta cadastrada!";
            }
            return msg;
        }

        public string Inserir(List<Classes.contasReceber> pListContas, bool pSql)
        {
            var msg = "";
            foreach (Classes.contasReceber vlConta in pListContas)
            {
                msg += umDaoContasReceb.Inserir(vlConta) + '\n';
            }
            if (pSql)
                return msg;
            else
            {
                msg = ExecucaoComandQuery(msg);
                if (msg == "sucesso")
                {
                    return $"Conta a receber inserida com {msg}!";
                }
                else if (msg.Contains("chave duplicada"))
                {
                    return $"Conta a receber já esta cadastrada!";
                }
                return msg;
            }
        }
        public string Excluir(List<Classes.contasReceber> pListContas, bool pSql)
        {
            var msg = "";
            foreach (Classes.contasReceber vlConta in pListContas)
            {
                msg += umDaoContasReceb.Excluir(vlConta) + '\n';
            }
            if (pSql)
                return msg;
            else
            {
                msg = ExecucaoComandQuery(msg);
                if (msg == "sucesso")
                {
                    return $"Conta a receber cancelada com {msg}!";
                }
                if (msg.Contains("DELETE conflitou"))
                {
                    return $"Existe um registro que depende de uma das parcelas das " +
                           $"contas a receber relacionadas a chave:\n" +
                           $"Modelo:    {pListContas[0].PK.Split(';')[0]}\n" +
                           $"Serie:     {pListContas[0].PK.Split(';')[1]}\n" +
                           $"Número NF: {pListContas[0].PK.Split(';')[2]}\n" +
                           $"Clientes:  {pListContas[0].UmCliente.Cliente}\n" +
                           $"Parcelas:  1-{pListContas.Count()}\n" +
                           $"Não foi possivel excluir as parcelas das contas a receber!";
                }
                return msg;
            }
        }
        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoContasReceb.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlConta = (Classes.contasReceber)pObjeto;
                return $"Conta a receber alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoContasReceb.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlConta = (Classes.contasReceber)pObjeto;
                return $"Conta a receber excluida com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlConta = (Classes.contasReceber)pObjeto;
                return $"Existe um registro que depende desta conta a receber\n" +
                       $"Não foi possivel excluir a conta a receber!";
            }
            return msg;
        }
        public List<Classes.contasReceber> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("contas_receber.", "");
            camposSelList = camposSelList.Replace("formaPagamento", "codigoFormaPag");
            DataTable vlTabelaCidades =
                 ExecuteComandSearchQuery(
                       umDaoContasReceb.PesquisarToString("contas_Pagar",
                       camposSelList.Replace("cliente", "codigoCliente"), "", ""), out pMsg);

            if (vlTabelaCidades.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.contasReceber> lista = new List<Classes.contasReceber>();
                foreach (DataRow row in vlTabelaCidades.Rows)
                {
                    var vlConta = new Classes.contasReceber((string)row[0], (string)row[1], (string)row[2],
                                                          (int)row[4], (string)row[5], (string)row[9],
                                                          decimal.Parse(row[7].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                                          (int)row[11], (string)row[10],
                                                          decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[13].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[14].ToString(), vgEstilo, vgProv));

                    vlConta.UmCliente = (Classes.clientes)umCtrlCliente.Pesquisar("codigo",
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
        public List<Classes.contasReceber> PesquisarCollection(string[] pCampo, string[] pValor, out string pMsg)
        {
            var camposSelList = camposSelect.Replace("contas_receber.", "");
            camposSelList = camposSelList.Replace("formaPagamento", "codigoFormaPag");
            DataTable vlTabelaCidades =
                 ExecuteComandSearchQuery(
                       umDaoContasReceb.PesquisarToString("contas_receber",
                       camposSelList.Replace("cliente", "codigoCliente"), pCampo, pValor, default, true),
                       out pMsg);
            if (vlTabelaCidades.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                var vlListaContasPag = new List<Classes.contasReceber>();
                foreach (DataRow row in vlTabelaCidades.Rows)
                {
                    var vlConta = new Classes.contasReceber((string)row[0], (string)row[1], (string)row[2],
                                                          (int)row[4], (string)row[5], (string)row[9],
                                                          decimal.Parse(row[7].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                                          (int)row[11], (string)row[10],
                                                          decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[13].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[14].ToString(), vgEstilo, vgProv));

                    vlConta.UmCliente = (Classes.clientes)umCtrlCliente.Pesquisar("codigo",
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
            var camposSelList = camposSelect.Replace("contas_receber.", "");
            camposSelList = camposSelList.Replace("formaPagamento", "codigoFormaPag");
            DataTable vlTabelaCidades =
                 ExecuteComandSearchQuery(
                       umDaoContasReceb.PesquisarToString("contas_receber",
                       camposSelList.Replace("cliente", "codigoCliente"), pCampo, pValor, default, pValorIgual),
                       out pMsg);
            if (vlTabelaCidades.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCidades.Rows[0];
                var vlConta = new Classes.contasReceber((string)row[0], (string)row[1], (string)row[2],
                                                      (int)row[4], (string)row[5], (string)row[9],
                                                      decimal.Parse(row[7].ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[8].ToString(), vgEstilo, vgProv),
                                                      (int)row[11], (string)row[10],
                                                      decimal.Parse(row[12].ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[13].ToString(), vgEstilo, vgProv),
                                                      decimal.Parse(row[14].ToString(), vgEstilo, vgProv));

                vlConta.UmCliente = (Classes.clientes)umCtrlCliente.Pesquisar("codigo",
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
            var vlConta = new Classes.contasReceber();
            var vlTable = ExecuteComandSearchQuery(
                       umDaoContasReceb.PesquisarToString("contas_receber, formasPagamento, clientes", camposSelect,
                       pCampo, pValor, vlConta.toStringSearchPesquisa(), pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
