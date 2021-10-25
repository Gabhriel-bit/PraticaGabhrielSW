using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoEstados : daos
    {
        public const string nameTable = "estados";
        public daoEstados(){ }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Estado está nulo!";
            }
            else
            {
                Classes.estados vlEstado = (Classes.estados)pObj;
                return InserirToString(nameTable, vlEstado.arrayStringCampos(),
                                       vlEstado.arrayStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Estado está nulo!";
            }
            else
            {
                Classes.estados vlEstado = (Classes.estados)pObj;
                return AlterarToString(nameTable, vlEstado.arrayStringCampos(),
                                             vlEstado.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Estado está nulo!";
            }
            else
            {
                Classes.estados vlEstado = (Classes.estados)pObj;
                return ExcluirToString(nameTable, "codigo", vlEstado.Codigo.ToString());
            }
        }
    }
}
