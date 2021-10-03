using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlModelos : ctrl
    {
        public const string camposSelect = "modelos.codigo, modelo, descricao as descrição, " +
                                           "marca, " +
                                           "modelos.codigoUsu as usuário, " +
                                           "modelos.dataCad as cadastro, " +
                                           "modelos.dataUltAlt as ultima_Alteração";
        private ctrlMarcas umaCtrlMarca;

        private DAOs.daoModelos umDaoModelo;

        public ctrlModelos(BancoDados.conexoes pUmaConexao, DAOs.daoModelos pDaoModelo,
            Controllers.ctrlMarcas pCtrlMarca)
        {
            umDaoModelo = pDaoModelo;
            umaCtrlMarca = pCtrlMarca;
            UmaConexao = pUmaConexao;
        }

        public ctrlMarcas CTRLMarca
        { get => umaCtrlMarca; }

        public override string Inserir(object pObjeto)
        {
            var vlModelo = (Classes.modelos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoModelo.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Modelo '{vlModelo.Modelo}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Modelo '{vlModelo.Modelo}' já esta cadastrado!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do modelo '{vlModelo.Modelo}'\n" +
                       $"Não foi possivel excluir o modelo!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoModelo.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlModelo = (Classes.modelos)pObjeto;
                return $"Modelo '{vlModelo.Modelo}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoModelo.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlModelo = (Classes.modelos)pObjeto;
                return $"Modelo '{vlModelo.Modelo}' excluido com {msg}!";
            }
            return msg;
        }
        public List<Classes.modelos> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("modelos.", "");
            DataTable vlTabelaModelo =
                 ExecuteComandSearchQuery(
                       umDaoModelo.PesquisarToString("modelos",
                       camposSelList.Replace("marca", "codigoMarca"), "", ""), out pMsg);

            if (vlTabelaModelo.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.modelos> lista = new List<Classes.modelos>();
                foreach (DataRow row in vlTabelaModelo.Rows)
                {
                    //    0       1         2          3          4         5         6
                    //"codigo, modelo, descricao, codigoPais, codigoUsu, dataCad, dataUltAlt";
                    var vlModelo = new Classes.modelos((int)row[0], (int)row[4],
                                                       (string)row[5], (string)row[6],
                                                       (string)row[1], (string)row[2]);
                    vlModelo.UmaMarca = (Classes.marcas)umaCtrlMarca.Pesquisar("codigo",
                                                                               ((int)row[3]).ToString(),
                                                                               out string vlMsgMarca,
                                                                               true);

                    pMsg += vlMsgMarca;
                    lista.Add(vlModelo);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            var camposSelList = camposSelect.Replace("modelos.", "");
            DataTable vlTabelaModelo =
                 ExecuteComandSearchQuery(
                       umDaoModelo.PesquisarToString("modelos",
                       camposSelList.Replace("marca", "codigoMarca"), pCampo, pValor, default, pValorIgual),
                                             out pMsg);

            if (vlTabelaModelo.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaModelo.Rows[0];
                var vlModelo = new Classes.modelos((int)row[0], (int)row[4],
                                                    (string)row[5], (string)row[6],
                                                    (string)row[1], (string)row[2]);
                vlModelo.UmaMarca = (Classes.marcas)umaCtrlMarca.Pesquisar("codigo",
                                                                           ((int)row[3]).ToString(),
                                                                           out string vlMsgMarca,
                                                                           true);
                pMsg = vlMsgMarca;
                return vlModelo;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlModelo = new Classes.modelos();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoModelo.PesquisarToString("modelos, marcas", camposSelect,
                          pCampo, pValor, vlModelo.toStringSearchPesquisa(), pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
