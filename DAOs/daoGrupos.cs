using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoGrupos : daos
    {
        public const string nameTable = "grupos";
        public daoGrupos() { }

        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Grupo está nulo!";
            }
            else
            {
                Classes.grupos vlGrupo = (Classes.grupos)pObj;
                return InserirToString(nameTable, vlGrupo.arrayStringCampos(),
                                       vlGrupo.arryStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Grupo está nulo!";
            }
            else
            {
                Classes.grupos vlGrupo = (Classes.grupos)pObj;
                return AlterarToString(nameTable, vlGrupo.arrayStringCampos(),
                                       vlGrupo.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Grupo está nulo!";
            }
            else
            {
                Classes.grupos vlGrupo = (Classes.grupos)pObj;
                return ExcluirToString(nameTable, "codigo", vlGrupo.Codigo.ToString());
            }
        }
    }
}
