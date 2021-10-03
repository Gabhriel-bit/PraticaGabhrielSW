using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlClientes : ctrl
    {
        public const string camposSelect = "clientes.codigo, cliente, " +
                                           "condicaoPagamento as condição_pagamento, " +
                                           "tel_Celular as telefone_Celular, email, cidade, bairro, " +
                                           "logradouro, numero, complemento, cep as CEP, " +
                                           "cnpj_cpf as CPF_CNPJ, inscEst_rg as inscriçãoEst_RG, " +
                                           "dataFund_Nasc as fundação_Nascimento, " +
                                           "clientes.codigoUsu as usuário, clientes.dataCad as cadastro, " +
                                           "clientes.dataUltAlt as ultima_alteração";
        private DAOs.daoClientes umDaoCliente;
        private ctrlCidades umaCtrlCidade;
        private ctrlCondicoesPagamento umaCtrlCondPag;

        public ctrlClientes(BancoDados.conexoes pUmaConexao, Controllers.ctrlCidades pCtrlCidade,
            Controllers.ctrlCondicoesPagamento pCtrlCondPag, DAOs.daoClientes pDaoCliente)
        {
            umDaoCliente = pDaoCliente;
            umaCtrlCidade = pCtrlCidade;
            umaCtrlCondPag = pCtrlCondPag;
            UmaConexao = pUmaConexao;
        }

        public ctrlCondicoesPagamento CTRLCondPag
        { get => umaCtrlCondPag; }
        public ctrlCidades CTRLCidade
        { get => umaCtrlCidade; }

        public override string Inserir(object pObjeto)
        {
            var vlCliente = (Classes.clientes)pObjeto;
            var msg = ExecucaoComandQuery(umDaoCliente.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Cliente '{vlCliente.Cliente}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Cliente '{vlCliente.Cliente}' já esta cadastrado!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoCliente.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlCliente = (Classes.clientes)pObjeto;
                return $"Cliente '{vlCliente.Cliente}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoCliente.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlCliente = (Classes.clientes)pObjeto;
                return $"Cliente '{vlCliente.Cliente}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlCliente = (Classes.clientes)pObjeto;
                return $"Existe um registro que depende do cliente '{vlCliente.Cliente}'\n" +
                       $"Não foi possivel excluir o cliente!";
            }
            return msg;
        }
        public List<Classes.clientes> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("clientes.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento " + 
                                                  "as condição_pagamento", "codigoCondPag");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoCliente.PesquisarToString("clientes",
                       camposSelList.Replace("cidade", "codigoCidade"), "", ""), out pMsg);
            if (vlTabelaFunc.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.clientes> lista = new List<Classes.clientes>();
                foreach (DataRow row in vlTabelaFunc.Rows)
                {
                    var vlCliente = new Classes.clientes((int)row[0], (int)row[14],
                                                          (string)row[15], (string)row[16],
                                                          (string)row[1], (string)row[7],
                                                          (string)row[8], (string)row[9],
                                                          (string)row[6], (string)row[10],
                                                          (string)row[3], (string)row[4],
                                                          (string)row[11], (string)row[12],
                                                          (string)row[13]);
                    vlCliente.UmaCondPag =
                        (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                             ((int)row[2]).ToString(),
                                                                             out string vlMsgCondPag,
                                                                             true);
                    vlCliente.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                                   ((int)row[5]).ToString(),
                                                                                   out string vlMsgCidade,
                                                                                   true);
                    pMsg += (vlMsgCondPag == "" ? "" : vlMsgCondPag) +
                           (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade);

                    lista.Add(vlCliente);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("clientes.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento " +
                                                  "as condição_pagamento", "codigoCondPag");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoCliente.PesquisarToString("clientes",
                                                      camposSelList.Replace("cidade", "codigoCidade"),
                                                      pCampo, pValor, default, pValorIgual),
                       out pMsg);
            if (vlTabelaFunc.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaFunc.Rows[0];
                var vlCliente = new Classes.clientes((int)row[0], (int)row[14],
                                                     (string)row[15], (string)row[16],
                                                     (string)row[1], (string)row[7],
                                                     (string)row[8], (string)row[9],
                                                     (string)row[6], (string)row[10],
                                                     (string)row[3], (string)row[4],
                                                     (string)row[11], (string)row[12],
                                                     (string)row[13]);
                vlCliente.UmaCondPag = 
                    (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                         ((int)row[2]).ToString(),
                                                                         out string vlMsgCondPag,
                                                                         true);
                vlCliente.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                               ((int)row[5]).ToString(),
                                                                               out string vlMsgCidade,
                                                                               true);
                pMsg = (vlMsgCondPag == "" ? "" : vlMsgCondPag) + 
                       (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade);

                return vlCliente;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlClientes = new Classes.clientes();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoCliente.PesquisarToString("clientes, cidades, condicoesPagamento",
                          camposSelect, pCampo, pValor, vlClientes.toStringSearchPesquisa(), pValorIgual),
                          out pMsg);
            return vlTable;
        }
    }
}
