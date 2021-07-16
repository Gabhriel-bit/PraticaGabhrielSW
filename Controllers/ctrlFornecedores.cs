using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Controllers
{
    public class ctrlFornecedores : controllers
    {
        public const string camposSelect = "fornecedores.codigo, fornecedor, " +
                                           "condicaoPagamento as condição_pagamento, " +
                                           "tel_Celular as telefone_Celular, email, cidade, bairro, " +
                                           "logradouro, numero, complemento, cep as CEP, " +
                                           "cnpj_cpf as CPF_CNPJ, inscEst_rg as inscriçãoEst_RG, " +
                                           "dataFund_Nasc as fundação_Nascimento, " +
                                           "fornecedores.codigoUsu as usuário, " +
                                           "fornecedores.dataCad as cadastro, " +
                                           "fornecedores.dataUltAlt as ultima_alteração";
        private DAOs.daoFornecedores umDaoForn;
        private ctrlCidades umaCtrlCidade;
        private ctrlCondicoesPagamento umaCtrlCondPag;

        public ctrlFornecedores()
        {
            umDaoForn = new DAOs.daoFornecedores();
            umaCtrlCidade = new ctrlCidades();
            umaCtrlCondPag = new ctrlCondicoesPagamento();
        }

        public ctrlFornecedores(BancoDados.conexoes pUmaConexao)
        {
            umDaoForn = new DAOs.daoFornecedores();
            umaCtrlCidade = new ctrlCidades(pUmaConexao);
            umaCtrlCondPag = new ctrlCondicoesPagamento(pUmaConexao);
            UmaConexao = pUmaConexao;
        }

        public ctrlCondicoesPagamento CTRLCondPag
        { get => umaCtrlCondPag; }
        public ctrlCidades CTRLCidade
        { get => umaCtrlCidade; }

        public override string Inserir(object pObjeto)
        {
            var vlForn = (Classes.fornecedores)pObjeto;
            var msg = ExecucaoComandQuery(umDaoForn.Inserir(pObjeto));
            if (msg == "sucesso")
            {
                return $"Fornecedor '{vlForn.Fornecedor}' inserido com {msg}!";
            }
            else if (msg.Contains("chave duplicada"))
            {
                return $"Fornecedor '{vlForn.Fornecedor}' já esta cadastrado!";
            }
            if (msg.Contains("DELETE conflitou"))
            {
                return $"Existe um registro que depende do fornecedor '{vlForn.Fornecedor}'\n" +
                       $"Não foi possivel excluir o fornecedor!";
            }
            return msg;
        }

        public override string Alterar(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoForn.Alterar(pObjeto));
            if (msg == "sucesso")
            {
                var vlForn = (Classes.fornecedores)pObjeto;
                return $"Fornecedor '{vlForn.Fornecedor}' alterado com {msg}!";
            }
            return msg;
        }

        public override string Excluir(object pObjeto)
        {
            var msg = ExecucaoComandQuery(umDaoForn.Excluir(pObjeto));
            if (msg == "sucesso")
            {
                var vlForn = (Classes.fornecedores)pObjeto;
                return $"Fornecedor '{vlForn.Fornecedor}' excluido com {msg}!";
            }
            return msg;
        }
        public List<Classes.fornecedores> PesquisarCollection()
        {
            var camposSelList = camposSelect.Replace("fornecedores.", "");
            camposSelList = camposSelList.Replace("condicaoPagamento as condição_pagamento", "codigoCondPag");
            DataTable vlTabelaFunc =
                 ExecuteComandSearchQuery(
                       umDaoForn.PesquisarToString("fornecedores",
                       camposSelList.Replace("cidade", "codigoCidade"), "", ""));
            var vlListaCidades = umaCtrlCidade.PesquisarCollection();
            var vlListaCondPag = umaCtrlCondPag.PesquisarCollection();
            if (vlTabelaFunc == null)
            {
                return null;
            }
            else
            {
                List<Classes.fornecedores> lista = new List<Classes.fornecedores>();
                foreach (DataRow row in vlTabelaFunc.Rows)
                {
                    var vlForn = new Classes.fornecedores((int)row[0], (int)row[14],
                                                          (string)row[15], (string)row[16],
                                                          (string)row[1], (string)row[7],
                                                          (string)row[8], (string)row[9],
                                                          (string)row[6], (string)row[10],
                                                          (string)row[3], (string)row[4],
                                                          (string)row[11], (string)row[12],
                                                          (string)row[13]);
                    vlForn.UmaCondPag.Codigo = (int)row[2];
                    vlForn.UmaCidade.Codigo = (int)row[5];
                    foreach (Classes.condicoesPagamento vlCondPag in vlListaCondPag)
                    {
                        if (vlCondPag.Codigo == vlForn.UmaCondPag.Codigo)
                        { vlForn.UmaCondPag.ThisCondPag = vlCondPag; }
                    }
                    foreach (Classes.cidades vlCidade in vlListaCidades)
                    {
                        if (vlCidade.Codigo == vlForn.UmaCidade.Codigo)
                        { vlForn.UmaCidade.ThisCidade = vlCidade; }
                    }
                    lista.Add(vlForn);
                }
                return lista;
            }
        }

        public override DataTable Pesquisar(string pCampo = "", string pValor = "")
        {
            var vlForn = new Classes.fornecedores();
            var t = umDaoForn.PesquisarToString("condicoesPagamento, fornecedores, cidades",
                       camposSelect, pCampo, pValor, vlForn.toStringSearchPesquisa());
            return ExecuteComandSearchQuery(t);
        }
    }
}
