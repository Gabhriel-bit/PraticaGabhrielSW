using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlGrupos : controllers
    {
        public const string camposSelect = "codigo, grupo, " +
                                           "codigoUsu as usuário, " +
                                           "dataCad as cadastro, " +
                                           "dataUltAlt as ultima_Alteração";
        private DAOs.daoGrupos umDaoGrupo;

        public ctrlGrupos(BancoDados.conexoes pUmaConexa, DAOs.daoGrupos pDaoGrupo)
        {
            umDaoGrupo = pDaoGrupo;
            UmaConexao = pUmaConexa;
        }

        public ctrlGrupos(DAOs.daoGrupos pUmaDaoPais)
        {
            umDaoGrupo = pUmaDaoPais;
        }

        public override string Inserir(object pObjeto)
        {
            var vlGrupo = (Classes.grupos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoGrupo.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Grupo '{vlGrupo.Grupo}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Grupo '{vlGrupo.Grupo}' já esta cadastrado!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do grupo '{vlGrupo.Grupo}'\n" +
                       $"Não foi possivel excluir o grupo!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoGrupo.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlGrupo = (Classes.grupos)pObjeto;
                return $"Grupo '{vlGrupo.Grupo}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoGrupo.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlGrupo = (Classes.grupos)pObjeto;
                return $"Grupo '{vlGrupo.Grupo}' excluido com {msg}!";
            }
            return msg;
        }
        public List<Classes.grupos> PesquisarCollection(out string pMsg)
        {
            DataTable vlTabelaGrupo =
                          ExecuteComandSearchQuery(
                                 umDaoGrupo.PesquisarToString("grupos", camposSelect, "", ""), out pMsg);
            if (vlTabelaGrupo.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.grupos> lista = new List<Classes.grupos>();
                foreach (DataRow row in vlTabelaGrupo.Rows)
                {
                    var vlGrupo = new Classes.grupos((int)row[0], (int)row[2],
                                                    (string)row[3], (string)row[4],
                                                    (string)row[1]);
                    lista.Add(vlGrupo);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            DataTable vlTabelaGrupo =
              ExecuteComandSearchQuery(
                     umDaoGrupo.PesquisarToString("grupos", camposSelect, pCampo, pValor, default, pDisponivel),
                                                  out pMsg);
            if (vlTabelaGrupo.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaGrupo.Rows[0];
               return new Classes.grupos((int)row[0], (int)row[2],
                                         (string)row[3], (string)row[4],
                                         (string)row[1]);
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlTable = ExecuteComandSearchQuery(
                          umDaoGrupo.PesquisarToString("grupos", camposSelect,
                             pCampo, pValor, default, pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
