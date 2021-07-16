using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoCidades : daos
    {
        public const string nameTable = "cidades";
        public daoCidades()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cidade está nula!";
            }
            else
            {
                Classes.cidades vlCidade = (Classes.cidades)pObj;
                return InserirToString(nameTable, vlCidade.arrayStringCampos(),
                                       vlCidade.arryStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cidade está nula!";
            }
            else
            {
                Classes.cidades vlCidade = (Classes.cidades)pObj;
                return AlterarToString(nameTable, vlCidade.arrayStringCampos(),
                                             vlCidade.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cidade está nula!";
            }
            else
            {
                Classes.cidades vlCidade = (Classes.cidades)pObj;
                return ExcluirToString(nameTable, "codigo", vlCidade.Codigo.ToString());
            }
        }
    }
}
