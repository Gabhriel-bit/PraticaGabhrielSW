using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoClientes : daos
    {
        public const string nameTable = "clientes";
        public daoClientes()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cliente está nulo!";
            }
            else
            {
                Classes.clientes vlCliente = (Classes.clientes)pObj;
                return InserirToString(nameTable, vlCliente.arrayStringCampos(),
                                       vlCliente.arryStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cliente está nulo!";
            }
            else
            {
                Classes.clientes vlCliente = (Classes.clientes)pObj;
                return AlterarToString(nameTable, vlCliente.arrayStringCampos(),
                                             vlCliente.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cliente está nulo!";
            }
            else
            {
                Classes.clientes vlCliente = (Classes.clientes)pObj;
                return ExcluirToString(nameTable, "codigo", vlCliente.Codigo.ToString());
            }
        }
    }
}
