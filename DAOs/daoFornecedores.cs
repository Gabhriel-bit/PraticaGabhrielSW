using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoFornecedores : daos
    {
        public const string nameTable = "fornecedores";
        public daoFornecedores()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Fornecedor está nulo!";
            }
            else
            {
                Classes.fornecedores vlFornecedor = (Classes.fornecedores)pObj;
                return InserirToString(nameTable, vlFornecedor.arrayStringCampos(),
                                       vlFornecedor.arrayStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Fornecedor está nulo!";
            }
            else
            {
                Classes.fornecedores vlFornecedor = (Classes.fornecedores)pObj;
                return AlterarToString(nameTable, vlFornecedor.arrayStringCampos(),
                                             vlFornecedor.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Fornecedor está nulo!";
            }
            else
            {
                Classes.fornecedores vlFornecedor = (Classes.fornecedores)pObj;
                return ExcluirToString(nameTable, "codigo", vlFornecedor.Codigo.ToString());
            }
        }
    }
}
