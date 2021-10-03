using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlEquipamentos : ctrl
    {
        public const string camposSelect = "equipamentos.codigo, equipamento, voltagem, " +
                                           "obsTecnica as Observação_Tec, modelo, " +
                                           "equipamentos.codigoUsu as usuário, " +
                                           "equipamentos.dataCad as cadastro, " +
                                           "equipamentos.dataUltAlt as ultima_Alteração";
        private ctrlModelos umaCtrlModelo;

        private DAOs.daoEquipamentos umDaoEquip;

        public ctrlEquipamentos(BancoDados.conexoes pUmaConexao, DAOs.daoEquipamentos pDaoEquip,
            Controllers.ctrlModelos pCtrlModelo)
        {
            umDaoEquip = pDaoEquip;
            umaCtrlModelo = pCtrlModelo;
            UmaConexao = pUmaConexao;
        }

        public ctrlModelos CTRLModelo
        { get => umaCtrlModelo; }

        public override string Inserir(object pObjeto)
        {
            var vlEquip = (Classes.equipamentos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoEquip.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Equipamento '{vlEquip.Equipamento}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Equipamento '{vlEquip.Equipamento}' já esta cadastrado!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoEquip.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlEquip = (Classes.equipamentos)pObjeto;
                return $"Equipamento '{vlEquip.Equipamento}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var vlEquip = (Classes.equipamentos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoEquip.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Equipamento '{vlEquip.Equipamento}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do Equipamento '{vlEquip.Equipamento}'\n" +
                       $"Não foi possivel excluir o Equipamento!";
            }
            return msg;
        }
        public List<Classes.equipamentos> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("equipamentos.", "");
            DataTable vlTabelaEquip =
                 ExecuteComandSearchQuery(
                       umDaoEquip.PesquisarToString("equipamentos",
                       camposSelList.Replace("modelo", "codigoModelo"), "", ""), out pMsg);

            if (vlTabelaEquip.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.equipamentos> lista = new List<Classes.equipamentos>();
                foreach (DataRow row in vlTabelaEquip.Rows)
                {
                    var vlEquip = new Classes.equipamentos((int)row[0], (int)row[5],
                                                           (string)row[6], (string)row[7],
                                                           (string)row[1], (string)row[2],
                                                           (string)row[3]);

                    vlEquip.UmModelo = (Classes.modelos)umaCtrlModelo.Pesquisar("codigo",
                                                                              ((int)row[4]).ToString(),
                                                                              out string vlMsgMarca,
                                                                              true);
                    pMsg += vlMsgMarca;

                    lista.Add(vlEquip);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            var camposSelList = camposSelect.Replace("equipamentos.", "");
            DataTable vlTabelaEquip =
                 ExecuteComandSearchQuery(
                       umDaoEquip.PesquisarToString("equipamentos",
                       camposSelList.Replace("modelo", "codigoModelo"), pCampo, pValor, default, pDisponivel),
                       out pMsg);

            if (vlTabelaEquip.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaEquip.Rows[0];
                var vlEquip = new Classes.equipamentos((int)row[0], (int)row[5],
                                                       (string)row[6], (string)row[7],
                                                       (string)row[1], (string)row[2],
                                                       (string)row[3]);

                vlEquip.UmModelo = (Classes.modelos)umaCtrlModelo.Pesquisar("codigo",
                                                                          ((int)row[4]).ToString(),
                                                                          out string vlMsgMarca,
                                                                          true);
                pMsg = vlMsgMarca;
                return vlEquip;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlEquip = new Classes.equipamentos();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoEquip.PesquisarToString("equipamentos, modelos", camposSelect,
                          pCampo, pValor, vlEquip.toStringSearchPesquisa(), pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
