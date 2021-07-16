using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlFuncionarios : controllers
    {
        public const string camposSelect = "funcionarios.codigo, funcionario, cargo, " +
                                           "tel_Celular as telefone_Celular, email, " +
                                           "cidade, bairro, logradouro, numero, complemento, " +
                                           "cep as CEP, cnpj_cpf as CPF_CNPJ, inscEst_rg as inscriçãoEst_RG, " +
                                           "funcionarios.cnh as CNH, dataVencCNH as vencimento_CNH, " +
                                           "dataFund_Nasc as fundação_Nascimento, " +
                                           "funcionarios.codigoUsu as usuário, " +
                                           "funcionarios.dataCad as cadastro, " +
                                           "funcionarios.dataUltAlt as ultima_alteração";
        private DAOs.daoFuncionarios umDaoFunc;
        private ctrlCidades umaCtrlCidade;
        private ctrlCargos umaCtrlCargo;

        public ctrlFuncionarios()
        {
            umDaoFunc = new DAOs.daoFuncionarios();
            umaCtrlCidade = new ctrlCidades();
            umaCtrlCargo = new ctrlCargos();
        }

        public ctrlFuncionarios(BancoDados.conexoes pUmaConexao)
        {
            umDaoFunc = new DAOs.daoFuncionarios();
            umaCtrlCidade = new ctrlCidades(pUmaConexao);
            umaCtrlCargo = new ctrlCargos(pUmaConexao);
            UmaConexao = pUmaConexao;
        }

        public ctrlCargos CTRLCargo
        { get => umaCtrlCargo; }
        public ctrlCidades CTRLCidade
        { get => umaCtrlCidade; }

        public override string Inserir(object pObjeto)
        {
            var vlFunc = (Classes.funcionarios)pObjeto;
            var msg = ExecucaoComandQuery(umDaoFunc.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Funcionário '{vlFunc.Funcionario}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Funcionário '{vlFunc.Funcionario}' já esta cadastrado!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do funcionário '{vlFunc.Funcionario}'\n" +
                       $"Não foi possivel excluir o funcionário!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoFunc.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlFunc = (Classes.funcionarios)pObjeto;
                return $"Funcionário '{vlFunc.Funcionario}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoFunc.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlFunc = (Classes.funcionarios)pObjeto;
                return $"Funcionário '{vlFunc.Funcionario}' excluido com {msg}!";
            }
            return msg;
        }
        public List<Classes.funcionarios> PesquisarCollection()
        {
            var camposSelList = camposSelect.Replace("funcionarios.", "");
            camposSelList = camposSelList.Replace("cargo", "codigoCargo");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoFunc.PesquisarToString("funcionarios",
                       camposSelList.Replace("cidade", "codigoCidade"), "", ""));
            var vlListaCidades = umaCtrlCidade.PesquisarCollection();
            var vlListaCargos = umaCtrlCargo.PesquisarCollection();
            if (vlTabelaFunc == null)
            {
                return null;
            }
            else
            {
                List<Classes.funcionarios> lista = new List<Classes.funcionarios>();
                foreach (DataRow row in vlTabelaFunc.Rows)
                {
                    var vlFunc = new Classes.funcionarios((int)row[0], (int)row[19],
                                                          (string)row[20], (string)row[21],
                                                          (string)row[1], (string)row[7],
                                                          (string)row[8], (string)row[9],
                                                          (string)row[6], (string)row[10],
                                                          (string)row[3], (string)row[4],
                                                          (string)row[11], (string)row[12],
                                                          (string)row[15],
                                                          decimal.Parse(row[16].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[17].ToString(), vgEstilo, vgProv),
                                                          decimal.Parse(row[18].ToString(), vgEstilo, vgProv),
                                                          (string)row[13], (string)row[14]);
                    vlFunc.UmCargo.Codigo = (int)row[2];
                    vlFunc.UmaCidade.Codigo = (int)row[5];
                    foreach (Classes.cargos vlCargo in vlListaCargos)
                    {
                        if (vlCargo.Codigo == vlFunc.UmCargo.Codigo)
                        { vlFunc.UmCargo.ThisCargo = vlCargo; }
                    }
                    foreach (Classes.cidades vlCidade in vlListaCidades)
                    {
                        if (vlCidade.Codigo == vlFunc.UmaCidade.Codigo)
                        { vlFunc.UmaCidade.ThisCidade = vlCidade; }
                    }
                    lista.Add(vlFunc);
                }
                return lista;
            }
        }

        public override DataTable Pesquisar(string pCampo = "", string pValor = "")
        {
            var vlFunc = new Classes.funcionarios();
            return ExecuteComandSearchQuery(
                       umDaoFunc.PesquisarToString("funcionarios, cidades, cargos", camposSelect,
                       pCampo, pValor, vlFunc.toStringSearchPesquisa()));
        }
    }
}
