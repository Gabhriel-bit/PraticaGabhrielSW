using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlFormasPagamento : ctrl
    {
        public const string camposSelect = "codigo, formaPagamento as Foma_pagamento, " +
                                           "codigoUsu as usuário, " +
                                           "dataCad as cadastro, " +
                                           "dataUltAlt as ultima_Alteração";
        private DAOs.daoFormasPagamento umDaoFormPag;

        public ctrlFormasPagamento(BancoDados.conexoes pUmaConexa,
            DAOs.daoFormasPagamento pDaoFormPag)
        {
            umDaoFormPag = pDaoFormPag;
            UmaConexao = pUmaConexa;
        }

        public ctrlFormasPagamento(DAOs.daoFormasPagamento pUmaDaoFormaPag)
        {
            umDaoFormPag = pUmaDaoFormaPag;
        }

        public override string Inserir(object pObjeto)
        {
            var vlFormPag = (Classes.formasPagamento)pObjeto;
            var msg = ExecucaoComandQuery(umDaoFormPag.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Forma Pagamento '{vlFormPag.FormaPag}' inserida com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Forma Pagamento '{vlFormPag.FormaPag}' já esta cadastrada!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende da forma de pagamento '{vlFormPag.FormaPag}'\n" +
                       $"Não foi possivel excluir a forma de pagamento!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoFormPag.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlFormPag = (Classes.formasPagamento)pObjeto;
                return $"Forma Pagamento '{vlFormPag.FormaPag}' alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoFormPag.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlFormPag = (Classes.formasPagamento)pObjeto;
                return $"Forma Pagamento '{vlFormPag.FormaPag}' excluida com {msg}!";
            }
            return msg;
        }
        public List<Classes.formasPagamento> PesquisarCollection(out string pMsg)
        {
            DataTable vlTabelaFormaPag =
                          ExecuteComandSearchQuery(
                                 umDaoFormPag.PesquisarToString("formasPagamento",
                                 camposSelect, "", ""), out pMsg);

            if (vlTabelaFormaPag.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.formasPagamento> lista = new List<Classes.formasPagamento>();
                foreach (DataRow row in vlTabelaFormaPag.Rows)
                {
                    var vlFormPag = new Classes.formasPagamento((int)row[0], (int)row[2],
                                                    (string)row[3], (string)row[4],
                                                    (string)row[1]);
                    lista.Add(vlFormPag);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            DataTable vlTabelaFormaPag =
              ExecuteComandSearchQuery(
                     umDaoFormPag.PesquisarToString("formasPagamento",
                     camposSelect, pCampo, pValor, default, pDisponivel), out string vlMsg);
            pMsg = vlMsg;
            if (vlTabelaFormaPag.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaFormaPag.Rows[0];
                return new Classes.formasPagamento((int)row[0], (int)row[2],
                                                   (string)row[3], (string)row[4],
                                                   (string)row[1]);
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlTable = ExecuteComandSearchQuery(
                          umDaoFormPag.PesquisarToString("formasPagamento",
                          camposSelect, pCampo, pValor, default, pValorIgual), out string vlMsg);
            pMsg = vlMsg;
            return vlTable;
        }
    }
}
