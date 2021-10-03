using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlFornecedores : ctrl
    {
        public const string camposSelect = "fornecedores.codigo, fornecedor, " +
                                           "condicaoPagamento as condição_pagamento, " +
                                           "tel_Celular as telefone_Celular, email, cidade, bairro, " +
                                           "logradouro, numero, complemento, cep as CEP, " +
                                           "cnpj_cpf as CPF_CNPJ, inscEst_rg as inscriçãoEst_RG, " +
                                           "dataFund_Nasc as fundação_Nascimento, " +
                                           "fornecedores.codigoUsu as usuário, " +
                                           "fornecedores.dataCad as cadastro, " +
                                           "fornecedores.dataUltAlt as ultima_alteração";
        private DAOs.daoFornecedores umDaoForn;
        private ctrlCidades umaCtrlCidade;
        private ctrlCondicoesPagamento umaCtrlCondPag;

        public ctrlFornecedores(BancoDados.conexoes pUmaConexao, DAOs.daoFornecedores pDaoForn,
            Controllers.ctrlCidades pCtrlCidade, Controllers.ctrlCondicoesPagamento pCtrlCondPag)
        {
            umDaoForn = pDaoForn;
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
            var vlForn = (Classes.fornecedores)pObjeto;
            var msg = ExecucaoComandQuery(umDaoForn.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Fornecedor '{vlForn.Fornecedor}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Fornecedor '{vlForn.Fornecedor}' já esta cadastrado!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do fornecedor '{vlForn.Fornecedor}'\n" +
                       $"Não foi possivel excluir o fornecedor!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoForn.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlForn = (Classes.fornecedores)pObjeto;
                return $"Fornecedor '{vlForn.Fornecedor}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoForn.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlForn = (Classes.fornecedores)pObjeto;
                return $"Fornecedor '{vlForn.Fornecedor}' excluido com {msg}!";
            }
            return msg;
        }
        public List<Classes.fornecedores> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("fornecedores.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento as condição_pagamento", "codigoCondPag");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoForn.PesquisarToString("fornecedores",
                       camposSelList.Replace("cidade", "codigoCidade"), "", ""), out pMsg);

            if (vlTabelaFunc.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.fornecedores> lista = new List<Classes.fornecedores>();
                foreach (DataRow row in vlTabelaFunc.Rows)
                {
                    var vlForn = new Classes.fornecedores((int)row[0], (int)row[14],
                                                          (string)row[15], (string)row[16],
                                                          (string)row[1], (string)row[7],
                                                          (string)row[8], (string)row[9],
                                                          (string)row[6], (string)row[10],
                                                          (string)row[3], (string)row[4],
                                                          (string)row[11], (string)row[12],
                                                          (string)row[13]);
                    vlForn.UmaCondPag =
                              (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                                   ((int)row[2]).ToString(),
                                                                                   out string vlMsgCondPag,
                                                                                   true);
                    vlForn.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                                ((int)row[5]).ToString(),
                                                                                out string vlMsgCidade,
                                                                                true);
                    pMsg += (vlMsgCondPag == "" ? "" : vlMsgCondPag) +
                            (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade);
                    lista.Add(vlForn);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            var camposSelList = camposSelect.Replace("fornecedores.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento as condição_pagamento", "codigoCondPag");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoForn.PesquisarToString("fornecedores",
                       camposSelList.Replace("cidade", "codigoCidade"), pCampo, pValor, default, pDisponivel),
                       out pMsg);

            if (vlTabelaFunc.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaFunc.Rows[0];
                var vlForn = new Classes.fornecedores((int)row[0], (int)row[14],
                                                        (string)row[15], (string)row[16],
                                                        (string)row[1], (string)row[7],
                                                        (string)row[8], (string)row[9],
                                                        (string)row[6], (string)row[10],
                                                        (string)row[3], (string)row[4],
                                                        (string)row[11], (string)row[12],
                                                        (string)row[13]);
                vlForn.UmaCondPag =
                          (Classes.condicoesPagamento)umaCtrlCondPag.Pesquisar("codigo",
                                                                               ((int)row[2]).ToString(),
                                                                               out string vlMsgCondPag,
                                                                               true);
                vlForn.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                            ((int)row[5]).ToString(),
                                                                            out string vlMsgCidade,
                                                                            true);
                pMsg = (vlMsgCondPag == "" ? "" : vlMsgCondPag) +
                       (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade);

                return vlForn;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlForn = new Classes.fornecedores();
            var vlTable = ExecuteComandSearchQuery(umDaoForn.PesquisarToString("fornecedores," +
                          " condicoesPagamento, cidades", camposSelect, pCampo, pValor,
                          vlForn.toStringSearchPesquisa(), pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
