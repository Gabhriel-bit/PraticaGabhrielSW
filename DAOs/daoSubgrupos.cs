using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoSubgrupos : daos
    {
        public const string nameTable = "subgrupos";
        public daoSubgrupos()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Subgrupo está nulo!";
            }
            else
            {
                Classes.subgrupos vlSubgrupo = (Classes.subgrupos)pObj;
                return InserirToString(nameTable, vlSubgrupo.arrayStringCampos(),
                                       vlSubgrupo.arrayStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Subgrupo está nulo!";
            }
            else
            {
                Classes.subgrupos vlSubgrupo = (Classes.subgrupos)pObj;
                return AlterarToString(nameTable, vlSubgrupo.arrayStringCampos(),
                                             vlSubgrupo.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Subgrupo está nulo!";
            }
            else
            {
                Classes.subgrupos vlSubgrupo = (Classes.subgrupos)pObj;
                return ExcluirToString(nameTable, "codigo", vlSubgrupo.Codigo.ToString());
            }
        }
    }
}
