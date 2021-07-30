using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlEstados : controllers
    {
        public const string camposSelect = "estados.codigo, estado, uf as UF, pais as país, " +
                                           "estados.codigoUsu as usuário, " +
                                           "estados.dataCad as cadastro, " +
                                           "estados.dataUltAlt as ultima_Alteração";
        private ctrlPaises umaCtrlPais;

        private DAOs.daoEstados umDaoEstado;

        public ctrlEstados()
        {
            umDaoEstado = new DAOs.daoEstados();
            umaCtrlPais = new ctrlPaises();
        }

        public ctrlEstados(BancoDados.conexoes pUmaConexao)
        {
            umDaoEstado = new DAOs.daoEstados();
            umaCtrlPais = new ctrlPaises(pUmaConexao);
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
                       camposSelList.Replace("pais", "codigoPais"), "", ""), out string vlMsg);
            var vlListaPaises = umaCtrlPais.PesquisarCollection(out string vlMsgPaises);
            pMsg = vlMsg + "\n" + vlMsgPaises;
            if (vlTabelaEstados == null)
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
                    vlEstado.UmPais.Codigo = (int)row[3];
                    foreach (Classes.paises vlPais in vlListaPaises)
                    {
                        if (vlPais.Codigo == vlEstado.UmPais.Codigo)
                        { vlEstado.UmPais.ThisPais = vlPais; }
                    }
                    lista.Add(vlEstado);
                }
                pMsg = "";
                return lista;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, out string pMsg)
        {
            var vlEstado = new Classes.estados();
            var vlTable = ExecuteComandSearchQuery(
                          umDaoEstado.PesquisarToString("estados, paises", camposSelect,
                          pCampo, pValor, vlEstado.toStringSearchPesquisa()), out string vlMsg);
            pMsg = vlMsg;
            return vlTable;
        }
    }
}
