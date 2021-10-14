using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlTransportadoras : ctrl
    {
        public const string camposSelect = "transportadoras.codigo, transportadora, " +
                                          "tel_Celular as telefone_Celular, email, cidade, bairro, " +
                                          "logradouro, numero, complemento, cep as CEP, " +
                                          "cnpj_cpf as CPF_CNPJ, inscEst_rg as inscriçãoEst_RG, " +
                                          "dataFund_Nasc as fundação_Nascimento, " +
                                          "transportadoras.codigoUsu as usuário, " +
                                          "transportadoras.dataCad as cadastro, " +
                                          "transportadoras.dataUltAlt as ultima_alteração";
        private DAOs.daoTransportadoras umDaoTranspot;
        private ctrlCidades umaCtrlCidade;

        public ctrlTransportadoras(BancoDados.conexoes pUmaConexao, DAOs.daoTransportadoras pDaoTransport,
                                   Controllers.ctrlCidades pCtrlCidade)
        {
            umDaoTranspot = pDaoTransport;
            umaCtrlCidade = pCtrlCidade;
            UmaConexao = pUmaConexao;
        }
        public ctrlCidades CTRLCidade
        { get => umaCtrlCidade; }

        public override string Inserir(object pObjeto)
        {
            var vlTranspot = (Classes.transportadoras)pObjeto;
            var msg = ExecucaoComandQuery(umDaoTranspot.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Transportadora '{vlTranspot.Transportadora}' inserida com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Transportadora '{vlTranspot.Transportadora}' já esta cadastrada!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do transportadora '{vlTranspot.Transportadora}'\n" +
                       $"Não foi possivel excluir a transportadora!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoTranspot.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlTranspot = (Classes.transportadoras)pObjeto;
                return $"Transportadora '{vlTranspot.Transportadora}' alterada com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoTranspot.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlTranspot = (Classes.transportadoras)pObjeto;
                return $"Transportadora '{vlTranspot.Transportadora}' excluida com {msg}!";
            }
            return msg;
        }
        public List<Classes.transportadoras> PesquisarCollection(out string pMsg)
        {
            var camposSelList = camposSelect.Replace("transportadoras.", "");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoTranspot.PesquisarToString("transportadoras",
                       camposSelList.Replace("cidade", "codigoCidade"), "", ""), out pMsg);

            if (vlTabelaFunc.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                List<Classes.transportadoras> lista = new List<Classes.transportadoras>();
                foreach (DataRow row in vlTabelaFunc.Rows)
                {
                    var vlTranspot = new Classes.transportadoras((int)row[0], (int)row[13],
                                                          (string)row[14], (string)row[15],
                                                          (string)row[1],  (string)row[6],
                                                          (string)row[7],  (string)row[8],
                                                          (string)row[5],  (string)row[9],
                                                          (string)row[2],  (string)row[3],
                                                          (string)row[10], (string)row[11],
                                                          (string)row[12]);
                    vlTranspot.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                                ((int)row[4]).ToString(),
                                                                                out string vlMsgCidade,
                                                                                true);
                    pMsg += (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade);
                    lista.Add(vlTranspot);
                }
                return lista;
            }
        }

        public override object Pesquisar(string pCampo, string pValor, out string pMsg, bool pDisponivel)
        {
            var camposSelList = camposSelect.Replace("transportadoras.", "");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoTranspot.PesquisarToString("transportadoras",
                       camposSelList.Replace("cidade", "codigoCidade"), pCampo, pValor, default, pDisponivel),
                       out pMsg);

            if (vlTabelaFunc.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = vlTabelaFunc.Rows[0];
                var vlTranspot = new Classes.transportadoras((int)row[0], (int)row[13],
                                                          (string)row[14], (string)row[15],
                                                          (string)row[1], (string)row[6],
                                                          (string)row[7], (string)row[8],
                                                          (string)row[5], (string)row[9],
                                                          (string)row[2], (string)row[3],
                                                          (string)row[10], (string)row[11],
                                                          (string)row[12]);
                vlTranspot.UmaCidade = (Classes.cidades)umaCtrlCidade.Pesquisar("codigo",
                                                                            ((int)row[4]).ToString(),
                                                                            out string vlMsgCidade,
                                                                            true);
                pMsg = (vlMsgCidade == "" ? "" : "\n" + vlMsgCidade);

                return vlTranspot;
            }
        }

        public override DataTable Pesquisar(string pCampo, string pValor, bool pValorIgual, out string pMsg)
        {
            var vlTranspot = new Classes.transportadoras();
            var vlTable = ExecuteComandSearchQuery(umDaoTranspot.PesquisarToString("transportadoras," +
                          " cidades", camposSelect, pCampo, pValor,
                          vlTranspot.toStringSearchPesquisa(), pValorIgual), out pMsg);
            return vlTable;
        }
    }
}
