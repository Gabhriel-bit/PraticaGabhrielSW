using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoFuncionarios : daos
    {
        public const string nameTable = "funcionarios";
        public daoFuncionarios()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Funcionário está nulo!";
            }
            else
            {
                Classes.funcionarios vlFunc = (Classes.funcionarios)pObj;
                return InserirToString(nameTable, vlFunc.arrayStringCampos(),
                                       vlFunc.arrayStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Funcionário está nulo!";
            }
            else
            {
                Classes.funcionarios vlFunc = (Classes.funcionarios)pObj;
                return AlterarToString(nameTable, vlFunc.arrayStringCampos(),
                                             vlFunc.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Funcionário está nulo!";
            }
            else
            {
                Classes.funcionarios vlFunc = (Classes.funcionarios)pObj;
                return ExcluirToString(nameTable, "codigo", vlFunc.Codigo.ToString());
            }
        }
    }
}
