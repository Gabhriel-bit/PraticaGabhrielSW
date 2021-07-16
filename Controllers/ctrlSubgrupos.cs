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

        public ctrlSubgrupos()
        {
            umDaoSubgrupo = new DAOs.daoSubgrupos();
            umaCtrlGrupo = new ctrlGrupos(); ;
        }

        public ctrlSubgrupos(BancoDados.conexoes pUmaConexao)
        {
            umDaoSubgrupo = new DAOs.daoSubgrupos();
            umaCtrlGrupo = new ctrlGrupos(pUmaConexao);
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
        public List<Classes.subgrupos> PesquisarCollection()
        {
            var camposSelList = camposSelect.Replace("subgrupos.", "");
            DataTable vlTabelaSubgrupos =
                 ExecuteComandSearchQuery(
                       umDaoSubgrupo.PesquisarToString("subgrupos",
                       camposSelList.Replace(", grupo, ", ", codigoGrupo, "), "", ""));
            var vlListaGrupos = umaCtrlGrupo.PesquisarCollection();
            if (vlTabelaSubgrupos == null)
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
                    vlSubgrupo.UmGrupo.Codigo = (int)row[2];
                    foreach (Classes.grupos vlGrupo in vlListaGrupos)
                    {
                        if (vlGrupo.Codigo == vlSubgrupo.UmGrupo.Codigo)
                        { vlSubgrupo.UmGrupo.ThisGrupo = vlGrupo; }
                    }
                    lista.Add(vlSubgrupo);
                }
                return lista;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor)
        {
            var vlSubgrupo = new Classes.subgrupos();
            return ExecuteComandSearchQuery(
                       umDaoSubgrupo.PesquisarToString("subgrupos, grupos", camposSelect,
                       pCampo, pValor, vlSubgrupo.toStringSearchPesquisa()));
        }
    }
}
