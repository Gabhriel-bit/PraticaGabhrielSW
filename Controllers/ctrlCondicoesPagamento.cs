﻿using System;
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

        public ctrlCondicoesPagamento()
        {
            umDaoCondPag = new DAOs.daoCondicoesPagamento();
            umaCtrlFromaPag = new ctrlFormasPagamento();
        }

        public ctrlCondicoesPagamento(BancoDados.conexoes pUmaConexao)
        {
            umDaoCondPag = new DAOs.daoCondicoesPagamento();
            umaCtrlFromaPag = new ctrlFormasPagamento(pUmaConexao);
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
        public List<Classes.condicoesPagamento> PesquisarCollection()
        {
            DataTable vlTabelaCondicoesPagamento =
                 ExecuteComandSearchQuery(
                       umDaoCondPag.PesquisarToString("condicoesPagamento", camposSelect, "", ""));
            if (vlTabelaCondicoesPagamento == null)
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
                    vlCondPag.ListaParcelas = PesquisarCollection(vlCondPag.Codigo);
                    lista.Add(vlCondPag);
                }
                return lista;
            }
        }

        public List<Classes.parcelasCondPag> PesquisarCollection(int pCodigoCondPang)
        {
            DataTable vlTabelaParcalasCondPag =
                ExecuteComandSearchQuery(
                    umDaoCondPag.PesquisarToString("parcelasCondicaoPagamento",
                                                   camposSelectParcelas,
                                                   "codigoCondPag", pCodigoCondPang.ToString()));
            if (vlTabelaParcalasCondPag == null)
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
                                                                decimal.Parse(row[3].ToString(), vgEstilo, vgProv));
                    vlParcela.UmaFormaPag.Codigo = (int)row[4];
                    var vlListaFormaPag = umaCtrlFromaPag.PesquisarCollection();
                    foreach (Classes.formasPagamento vlFormPag in vlListaFormaPag)
                    {
                        if (vlFormPag.Codigo == vlParcela.UmaFormaPag.Codigo)
                        { vlParcela.UmaFormaPag.ThisFormPag = vlFormPag; }
                    }
                    listaParcelas.Add(vlParcela);
                }
                return listaParcelas;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor)
        {
            return ExecuteComandSearchQuery(
                       umDaoCondPag.PesquisarToString("condicoesPagamento", camposSelect, pCampo, pValor));
        }
    }
}
