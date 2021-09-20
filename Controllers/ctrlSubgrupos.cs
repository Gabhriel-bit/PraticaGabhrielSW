using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlSubgrupos : controllers
    {
        public const string camposSelect = "subgrupos.codigo, subgrupo, grupo, " +
                                           "subgrupos.codigoUsu as usuário, " +
                                           "subgrupos.dataCad as cadastro, " +
                                           "subgrupos.dataUltAlt as ultima_Alteração";
        private ctrlGrupos umaCtrlGrupo;

        private DAOs.daoSubgrupos umDaoSubgrupo;

        public ctrlSubgrupos(BancoDados.conexoes pUmaConexao, DAOs.daoSubgrupos pDaoSubgrupo,
            Controllers.ctrlGrupos pCtrlGrupo)
        {
            umDaoSubgrupo = pDaoSubgrupo;
            umaCtrlGrupo = pCtrlGrupo;
            UmaConexao = pUmaConexao;
        }

        public ctrlGrupos CTRLGrupo
        { get => umaCtrlGrupo; }

        public override string Inserir(object pObjeto)
        {
            var vlSubgrupo = (Classes.subgrupos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoSubgrupo.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Subgrupo '{vlSubgrupo.Subgrupo}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Subgrupo '{vlSubgrupo.Subgrupo}' já esta cadastrado!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoSubgrupo.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlSubgrupo = (Classes.subgrupos)pObjeto;
                return $"Subgrupo '{vlSubgrupo.Subgrupo}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlSubgrupo = (Classes.subgrupos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoSubgrupo.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                
                return $"Subgrupo '{vlSubgrupo.Subgrupo}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlPais = (Classes.paises)pObjeto;
                return $"Existe um registro que depende do subgrupo '{vlSubgrupo.Subgrupo}'\n" +
                       $"Não foi possivel excluir o subgrupo!";
            }
            return msg;
        }
        public List<Classes.subgrupos> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("subgrupos.", "");
            DataTable vlTabelaSubgrupos =
                 ExecuteComandSearchQuery(
                       umDaoSubgrupo.PesquisarToString("subgrupos",
                       camposSelList.Replace(", grupo, ", ", codigoGrupo, "), "", ""), out pMsg);

            if (vlTabelaSubgrupos.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.subgrupos> lista = new List<Classes.subgrupos>();
                foreach (DataRow row in vlTabelaSubgrupos.Rows)
                {
                    //    0        1            2          3          4         5
                    //"codigo, subgrupos, codigoGrupo, codigoUsu, dataCad, dataUltAlt";
                    var vlSubgrupo = new Classes.subgrupos((int)row[0], (int)row[3],
                                                        (string)row[4], (string)row[5],
                                                        (string)row[1]);

                    vlSubgrupo.UmGrupo = (Classes.grupos)umaCtrlGrupo.Pesquisar("codigo",
                                                                                ((int)row[2]).ToString(),
                                                                                out string vlMsgGrupo,
                                                                                true);
                    pMsg += vlMsgGrupo;

                    lista.Add(vlSubgrupo);
                }
                pMsg = "";
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("subgrupos.", "");
            DataTable vlTabelaSubgrupos =
                 ExecuteComandSearchQuery(
                       umDaoSubgrupo.PesquisarToString("subgrupos",
                       camposSelList.Replace(", grupo, ", ", codigoGrupo, "),
                       pCampo, pValor, default, pValorIgual),
                       out pMsg);

            if (vlTabelaSubgrupos.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaSubgrupos.Rows[0];
                var vlSubgrupo = new Classes.subgrupos((int)row[0], (int)row[3],
                                                    (string)row[4], (string)row[5],
                                                    (string)row[1]);
                vlSubgrupo.UmGrupo = (Classes.grupos)umaCtrlGrupo.Pesquisar("codigo",
                                                                            ((int)row[2]).ToString(),
                                                                            out string vlMsgGrupo,
                                                                            true);
                pMsg = vlMsgGrupo;
                return vlSubgrupo;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlSubgrupo = new Classes.subgrupos();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoSubgrupo.PesquisarToString("subgrupos, grupos", camposSelect,
                          pCampo, pValor, vlSubgrupo.toStringSearchPesquisa()), out pMsg);
            return vlTable;
        }
    }
}
