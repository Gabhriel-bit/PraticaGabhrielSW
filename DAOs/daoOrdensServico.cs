using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    class daoOrdensServico :daos
    {
        public const string nameTable = "os_servicos";
        public daoOrdensServico()
        { }


        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Ordem de serviço está nula!";
            }
            else
            {
                Classes.ordensServico vlOS = (Classes.ordensServico)pObj;
                return InserirToString(nameTable,
                                       vlOS.arrayStringCampos(),
                                       vlOS.arrayStringValores(), true);
            }
        }

        public string InserirItensServicos(List<Classes.itensOSServico> listaItens)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                string insertion = "";
                foreach (Classes.itensOSServico vlItem in listaItens)
                {
                    insertion += InserirToString("os_servicos",
                                                 vlItem.arrayStringCampos(),
                                                 vlItem.arrayStringValores(), true)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public string InserirItensProdutos(List<Classes.itensOSProdutos> listaItens)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                string insertion = "";
                foreach(Classes.itensOSProdutos vlItem in listaItens)
                {
                    insertion += InserirToString("os_produtos",
                                                 vlItem.arrayStringCampos(),
                                                 vlItem.arrayStringValores(), true)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: País está nulo!";
            }
            else
            {
                Classes.ordensServico vlPais = (Classes.ordensServico)pObj;
                return AlterarToString(nameTable, 
                                       vlPais.arrayStringCampos(),
                                       vlPais.arrayStringValores());
            }
        }

        public string AlterarItensServicos(List<Classes.itensOSServico> listaItens)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                string insertion = "\n" + "delete from os_servico where " +
                                        $"codigoOS = {listaItens[0].CodigoOS};\n";
                foreach (Classes.itensOSServico vlItem in listaItens)
                {
                    insertion += InserirToString("os_servico",
                                                 vlItem.arrayStringCampos(),
                                                 vlItem.arrayStringValores(), true)
                                                 + '\n';
                }
                return insertion;
            }
        }
        public string AlterarItensProdutos(List<Classes.itensOSProdutos> listaItens)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                string insertion = "\n" + "delete from os_produto where " +
                                        $"codigoOS = {listaItens[0].CodigoOS};\n";
                foreach (Classes.itensOSProdutos vlItem in listaItens)
                {
                    insertion += InserirToString("os_produto",
                                                 vlItem.arrayStringCampos(),
                                                 vlItem.arrayStringValores(), true)
                                                 + '\n';
                }
                return insertion;
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Produdo está nula!";
            }
            else
            {
                Classes.ordensServico vlProduto = (Classes.ordensServico)pObj;
                return ExcluirToString(nameTable, "codigo", vlProduto.Codigo.ToString());
            }
        }

        public string ExcluirItensServicos(List<Classes.itensOSServico> listaItens)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                return ExcluirToString("os_produtos",
                                       "codigoOS",
                                       listaItens[0].CodigoOS.ToString());
            }
        }

        public string ExcluirItensProdutos(List<Classes.itensOSProdutos> listaItens)
        {
            if (listaItens == null)
            {
                return "Erro: Lista de itens está nula!";
            }
            else
            {
                return ExcluirToString("os_produtos",
                                       "codigoOS",
                                       listaItens[0].CodigoOS.ToString());
            }
        }
    }
}
