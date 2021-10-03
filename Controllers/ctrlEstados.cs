using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlEstados : ctrl
    {
        public const string camposSelect = "estados.codigo, estado, uf as UF, pais as país, " +
                                           "estados.codigoUsu as usuário, " +
                                           "estados.dataCad as cadastro, " +
                                           "estados.dataUltAlt as ultima_Alteração";
        private ctrlPaises umaCtrlPais;

        private DAOs.daoEstados umDaoEstado;

        public ctrlEstados(BancoDados.conexoes pUmaConexao, DAOs.daoEstados pDaoEstado,
            Controllers.ctrlPaises pCtrlPais)
        {
            umDaoEstado = pDaoEstado;
            umaCtrlPais = pCtrlPais;
            UmaConexao = pUmaConexao;
        }

        public ctrlPaises CTRLPais
        { get => umaCtrlPais; }

        public override string Inserir(object pObjeto)
        {
            var vlEstado = (Classes.estados)pObjeto;
            var msg = ExecucaoComandQuery(umDaoEstado.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Estado '{vlEstado.Estado}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Estado '{vlEstado.Estado}' já esta cadastrado!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoEstado.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlEstado = (Classes.estados)pObjeto;
                return $"Estado '{vlEstado.Estado}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlEstado = (Classes.estados)pObjeto;
            var msg = ExecucaoComandQuery(umDaoEstado.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Estado '{vlEstado.Estado}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do Estado '{vlEstado.Estado}'\n" +
                       $"Não foi possivel excluir o Estado!";
            }
            return msg;
        }
        public List<Classes.estados> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("estados.", "");
            DataTable vlTabelaEstados =
                 ExecuteComandSearchQuery(
                       umDaoEstado.PesquisarToString("estados",
                       camposSelList.Replace("pais", "codigoPais"), "", ""), out pMsg);

            if (vlTabelaEstados.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.estados> lista = new List<Classes.estados>();
                foreach (DataRow row in vlTabelaEstados.Rows)
                {
                    //    0       1     2        3          4         5         6
                    //"codigo, estado, uf, codigoPais, codigoUsu, dataCad, dataUltAlt";
                    var vlEstado = new Classes.estados((int)row[0], (int)row[4],
                                                       (string)row[5], (string)row[6],
                                                       (string)row[1], (string)row[2]);

                    vlEstado.UmPais = (Classes.paises)umaCtrlPais.Pesquisar("codigo",
                                                                            ((int)row[3]).ToString(),
                                                                            out string vlMsgPais,
                                                                            true);
                    pMsg += vlMsgPais; 

                    lista.Add(vlEstado);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            var camposSelList = camposSelect.Replace("estados.", "");
            DataTable vlTabelaEstados =
                 ExecuteComandSearchQuery(
                       umDaoEstado.PesquisarToString("estados",
                       camposSelList.Replace("pais", "codigoPais"), pCampo, pValor, default, pDisponivel),
                       out pMsg);

            if (vlTabelaEstados.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaEstados.Rows[0];
                var vlEstado = new Classes.estados((int)row[0], (int)row[4],
                                                    (string)row[5], (string)row[6],
                                                    (string)row[1], (string)row[2]);
                vlEstado.UmPais = (Classes.paises)umaCtrlPais.Pesquisar("codigo",
                                                                        ((int)row[3]).ToString(),
                                                                        out string vlMsgPais,
                                                                        true);
                pMsg = vlMsgPais;
                return vlEstado;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlEstado = new Classes.estados();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoEstado.PesquisarToString("estados, paises", camposSelect,
                          pCampo, pValor, vlEstado.toStringSearchPesquisa(), pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
