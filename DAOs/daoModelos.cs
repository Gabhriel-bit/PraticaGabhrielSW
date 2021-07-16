using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoModelos : daos
    {
        public const string nameTable = "modelos";
        public daoModelos()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Modelo está nulo!";
            }
            else
            {
                Classes.modelos vlModelo = (Classes.modelos)pObj;
                return InserirToString(nameTable, vlModelo.arrayStringCampos(),
                                       vlModelo.arryStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Modelo está nulo!";
            }
            else
            {
                Classes.modelos vlModelo = (Classes.modelos)pObj;
                return AlterarToString(nameTable, vlModelo.arrayStringCampos(),
                                             vlModelo.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Modelo está nulo!";
            }
            else
            {
                Classes.modelos vlModelo = (Classes.modelos)pObj;
                return ExcluirToString(nameTable, "codigo", vlModelo.Codigo.ToString());
            }
        }
    }
}
