using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlCargos : ctrl
    {
        public const string camposSelect = "codigo, cargo, descricao as descrição, " +
                                           "cnh as CNH, " +
                                           "codigoUsu as usuário, " +
                                           "dataCad as cadastro, " +
                                           "dataUltAlt as ultima_Ateração";
        private DAOs.daoCargos umDaoCargos;

        public ctrlCargos(BancoDados.conexoes pUmaConexa, DAOs.daoCargos pDaoCargo)
        {
            umDaoCargos = pDaoCargo;
            UmaConexao = pUmaConexa;
        }

        public ctrlCargos(DAOs.daoCargos pUmaDaoCargo)
        {
            umDaoCargos = pUmaDaoCargo;
        }

        public override string Inserir(object pObjeto)
        {
            var vlCargo = (Classes.cargos)pObjeto;
            var msg = ExecucaoComandQuery(umDaoCargos.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Cargo '{vlCargo.Cargo}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Cargo '{vlCargo.Cargo}' já esta cadastrado!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoCargos.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlCargo = (Classes.cargos)pObjeto;
                return $"Cargo '{vlCargo.Cargo}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoCargos.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlCargo = (Classes.cargos)pObjeto;
                return $"Cargo '{vlCargo.Cargo}' excluido com {msg}!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                var vlCargo = (Classes.cargos)pObjeto;
                return $"Existe um registro que depende do Cargo '{vlCargo.Cargo}'\n" +
                       $"Não foi possivel excluir o cargo!";
            }
            return msg;
        }
        public List<Classes.cargos> PesquisarCollection(out string pMsg)
        {
            DataTable vlTabelaCargos =
                          ExecuteComandSearchQuery(
                                 umDaoCargos.PesquisarToString("cargos",camposSelect, "", ""), out pMsg);
            if (vlTabelaCargos.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.cargos> lista = new List<Classes.cargos>();
                foreach (DataRow row in vlTabelaCargos.Rows)
                {
                    //   0       1        2      3       4         5        6
                    //codigo, cargo, descricao, cnh, codigoUsu, dataCad, dataUltAlt
                    var vlCargo = new Classes.cargos((int)row[0], (int)row[4],
                                                     (string)row[5], (string)row[6],
                                                     bool.Parse((string)row[3]),
                                                     (string)row[1], (string)row[2]);
                    lista.Add(vlCargo);
                }
                return lista;
            }
        }
        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pValorIgual)
        {
            DataTable vlTabelaCargos =
                          ExecuteComandSearchQuery(
                                 umDaoCargos.PesquisarToString("cargos", camposSelect, pCampo, pValor, default, pValorIgual),
                                 out pMsg);
            if (vlTabelaCargos.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaCargos.Rows[0];
                return new Classes.cargos((int)row[0], (int)row[4],
                                         (string)row[5], (string)row[6],
                                         bool.Parse((string)row[3]),
                                         (string)row[1], (string)row[2]);
            }
        }
        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlTable = ExecuteComandSearchQuery(
                          umDaoCargos.PesquisarToString("cargos", camposSelect, pCampo, pValor, default, pValorIgual),
                          out pMsg);
            return vlTable;
        }
    }
}
