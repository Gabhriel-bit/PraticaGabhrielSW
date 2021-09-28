using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlServicos : controllers
    {
        public const string camposSelect = "codigo, servico as Serviço, descricao as Descrição, " +
                                           "preco as Preço, " + "codigoUsu as usuário, " +
                                           "dataCad as cadastro, " + "dataUltAlt as ultima_Alteração";
        private DAOs.daoServicos umDaoServico;

        public ctrlServicos(BancoDados.conexoes pUmaConexa, DAOs.daoServicos pDaoServico)
        {
            umDaoServico = pDaoServico;
            UmaConexao = pUmaConexa;
        }

        public override string Inserir(object pObjeto)
        {
            var vlServico = (Classes.servicos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoServico.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Serviço '{vlServico.Servico}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Serviço '{vlServico.Servico}' já esta cadastrado!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoServico.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlServico = (Classes.servicos)pObjeto;
                return $"Serviço '{vlServico.Servico}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoServico.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlServico = (Classes.servicos)pObjeto;
                return $"Serviço '{vlServico.Servico}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlServico = (Classes.servicos)pObjeto;
                return $"Existe um registro que depende do serviço '{vlServico.Servico}'\n" +
                       $"Não foi possivel excluir o serviço!";
            }
            return msg;
        }
        public List<Classes.servicos> PesquisarCollection(out string pMsg)
        {
            DataTable vlTabelaServicos =
                          ExecuteComandSearchQuery(
                                 umDaoServico.PesquisarToString("servico", camposSelect, "", ""), out pMsg);
            if (vlTabelaServicos.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.servicos> lista = new List<Classes.servicos>();
                foreach (DataRow row in vlTabelaServicos.Rows)
                {
                    var vlServico = new Classes.servicos((int)row[0], (int)row[4],
                                                        (string)row[5], (string)row[6],
                                                        (string)row[1], (string)row[2],
                                                        decimal.Parse(row[3].ToString(), vgEstilo, vgProv));
                    lista.Add(vlServico);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            DataTable vlTabelaServicos =
              ExecuteComandSearchQuery(
                     umDaoServico.PesquisarToString("servicos", camposSelect, pCampo, pValor, default, pValorIgual),
                     out pMsg);

            if (vlTabelaServicos.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaServicos.Rows[0];
                return new Classes.servicos((int)row[0], (int)row[4],
                                            (string)row[5], (string)row[6],
                                            (string)row[1], (string)row[2],
                                             decimal.Parse(row[3].ToString(), vgEstilo, vgProv));
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlTable = ExecuteComandSearchQuery(
                          umDaoServico.PesquisarToString("servicos", camposSelect, pCampo, pValor, default, pValorIgual),
                          out pMsg);
            return vlTable;
        }
    }
}
