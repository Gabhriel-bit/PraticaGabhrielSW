using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlModelos : controllers
    {
        public const string camposSelect = "modelos.codigo, modelo, descricao as descrição, " +
                                           "marca, " +
                                           "modelos.codigoUsu as usuário, " +
                                           "modelos.dataCad as cadastro, " +
                                           "modelos.dataUltAlt as ultima_Alteração";
        private ctrlMarcas umaCtrlMarca;

        private DAOs.daoModelos umDaoModelo;

        public ctrlModelos()
        {
            umDaoModelo = new DAOs.daoModelos();
            umaCtrlMarca = new ctrlMarcas();
        }

        public ctrlModelos(BancoDados.conexoes pUmaConexao)
        {
            umDaoModelo = new DAOs.daoModelos();
            umaCtrlMarca = new ctrlMarcas(pUmaConexao);
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
                       camposSelList.Replace("marca", "codigoMarca"), "", ""), out string vlMsg);
            var vlListamarcas = umaCtrlMarca.PesquisarCollection(out string vlMsgMarca);
            pMsg = vlMsg + '\n' + vlMsgMarca;
            if (vlTabelaModelo == null)
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
                    vlModelo.UmaMarca.Codigo = (int)row[3];
                    foreach (Classes.marcas vlMarca in vlListamarcas)
                    {
                        if (vlMarca.Codigo == vlModelo.UmaMarca.Codigo)
                        { vlModelo.UmaMarca.ThisMarca = vlMarca; }
                    }
                    lista.Add(vlModelo);
                }
                pMsg = "";
                return lista;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, out string pMsg)
        {
            var vlModelo = new Classes.modelos();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoModelo.PesquisarToString("modelos, marcas", camposSelect,
                          pCampo, pValor, vlModelo.toStringSearchPesquisa()), out string vlMsg);
            pMsg = vlMsg;
            return vlTable;
        }
    }
}
