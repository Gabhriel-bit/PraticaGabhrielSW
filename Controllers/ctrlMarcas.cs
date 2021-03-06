using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlMarcas : ctrl
    {
        public const string camposSelect = "codigo, marca, " +
                                           "codigoUsu as usuário, " +
                                           "dataCad as cadastro, " +
                                           "dataUltAlt as ultima_Alteração";
        private DAOs.daoMarcas umDaoMarca;

        public ctrlMarcas(BancoDados.conexoes pUmaConexa, DAOs.daoMarcas pDaoMarca)
        {
            umDaoMarca = pDaoMarca;
            UmaConexao = pUmaConexa;
        }

        public ctrlMarcas(DAOs.daoMarcas pUmaDaoMarca)
        {
            umDaoMarca = pUmaDaoMarca;
        }

        public override string Inserir(object pObjeto)
        {
            var vlMarca = (Classes.marcas)pObjeto;
            var msg = ExecucaoComandQuery(umDaoMarca.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Marca '{vlMarca.Marca}' inserida com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Marca '{vlMarca.Marca}' já esta cadastrada!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende da marca '{vlMarca.Marca}'\n" +
                       $"Não foi possivel excluir a marca!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoMarca.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlMarca = (Classes.marcas)pObjeto;
                return $"Marca '{vlMarca.Marca}' alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoMarca.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlMarca = (Classes.marcas)pObjeto;
                return $"Marca '{vlMarca.Marca}' excluida com {msg}!";
            }
            return msg;
        }
        public List<Classes.marcas> PesquisarCollection(out string pMsg)
        {
            DataTable vlTabelaMarcas =
                          ExecuteComandSearchQuery(
                                 umDaoMarca.PesquisarToString("marcas", camposSelect, "", ""), out pMsg);
            if (vlTabelaMarcas.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.marcas> lista = new List<Classes.marcas>();
                foreach (DataRow row in vlTabelaMarcas.Rows)
                {
                    var vlMarca = new Classes.marcas((int)row[0], (int)row[2],
                                                    (string)row[3], (string)row[4],
                                                    (string)row[1]);
                    lista.Add(vlMarca);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            DataTable vlTabelaMarcas =
                        ExecuteComandSearchQuery(
                               umDaoMarca.PesquisarToString("marcas", camposSelect, pCampo, pValor, default, pDisponivel),
                                                            out pMsg);
            if (vlTabelaMarcas.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaMarcas.Rows[0];
                return new Classes.marcas((int)row[0], (int)row[2],
                                          (string)row[3], (string)row[4],
                                          (string)row[1]);
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlTable = ExecuteComandSearchQuery(
                          umDaoMarca.PesquisarToString("marcas", camposSelect,
                            pCampo, pValor, default, pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
