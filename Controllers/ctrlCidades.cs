using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlCidades : controllers
    {
        public const string camposSelect = "cidades.codigo, cidade, ddd as DDD, " +
                                           "estado as Estado, " +
                                           "cidades.codigoUsu as usuário, " +
                                           "cidades.dataCad as cadastro, " +
                                           "cidades.dataUltAlt as ultima_Ateração";
        private ctrlEstados umaCtrlEstado;

        private DAOs.daoCidades umDaoCidade;

        public ctrlCidades()
        {
            umDaoCidade = new DAOs.daoCidades();
            umaCtrlEstado = new ctrlEstados();
        }

        public ctrlCidades(BancoDados.conexoes pUmaConexao)
        {
            umDaoCidade = new DAOs.daoCidades();
            umaCtrlEstado = new ctrlEstados(pUmaConexao);
            UmaConexao = pUmaConexao;
        }

        public ctrlEstados CTRLEstado
        { get => umaCtrlEstado; }

        public override string Inserir(object pObjeto)
        {
            var vlCidade = (Classes.cidades)pObjeto;
            var msg = ExecucaoComandQuery(umDaoCidade.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Cidade '{vlCidade.Cidade}' inserida com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Cidade '{vlCidade.Cidade}' já esta cadastrada!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoCidade.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlCidade = (Classes.cidades)pObjeto;
                return $"Cidade '{vlCidade.Cidade}' alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoCidade.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlCidade = (Classes.cidades)pObjeto;
                return $"Cidade '{vlCidade.Cidade}' excluida com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlCidade = (Classes.cidades)pObjeto;
                return $"Existe um registro que depende da cidade '{vlCidade.Cidade}'\n" +
                       $"Não foi possivel excluir a cidade!";
            }
            return msg;
        }
        public List<Classes.cidades> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("cidades.", "");
            DataTable vlTabelaCidades =
                 ExecuteComandSearchQuery(
                       umDaoCidade.PesquisarToString("cidades",
                       camposSelList.Replace("estado", "codigoEstado"), "", ""), out string vlMsg);
            var vlListaEstados = umaCtrlEstado.PesquisarCollection(out string vlMsgEstado);
            pMsg = vlMsg + '\n' + vlMsgEstado;
            if (vlTabelaCidades == null)
            {
                return null;
            }
            else
            {
                List<Classes.cidades> lista = new List<Classes.cidades>();
                foreach (DataRow row in vlTabelaCidades.Rows)
                {
                    //    0       1     2        3          4         5         6
                    //"codigo, cidade, ddd, codigoEstado, codigoUsu, dataCad, dataUltAlt";
                    var vlCidade = new Classes.cidades((int)row[0], (int)row[4],
                                                       (string)row[5], (string)row[6],
                                                       (string)row[1], (string)row[2]);
                    vlCidade.UmEstado.Codigo = (int)row[3];
                    foreach (Classes.estados vlEstado in vlListaEstados)
                    {
                        if (vlEstado.Codigo == vlCidade.UmEstado.Codigo)
                        { vlCidade.UmEstado.ThisEstado = vlEstado; }
                    }
                    lista.Add(vlCidade);
                }
                pMsg = "";
                return lista;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, out string pMsg)
        {
            var vlCidade = new Classes.cidades();
            var vlTable = ExecuteComandSearchQuery(
                       umDaoCidade.PesquisarToString("cidades, estados", camposSelect,
                       pCampo, pValor, vlCidade.toStringSearchPesquisa()), out string vlMsg);
            pMsg = vlMsg;
            return vlTable;
        }
    }
}
