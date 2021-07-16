using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoPaises : daos
    {
        public const string nameTable = "paises";
        public daoPaises() { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: País está nulo!";
            }
            else
            {
                Classes.paises vlPais = (Classes.paises)pObj;
                return InserirToString(nameTable, vlPais.arrayStringCampos(),
                                       vlPais.arryStringValores());
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
                Classes.paises vlPais = (Classes.paises)pObj;
                return AlterarToString(nameTable, vlPais.arrayStringCampos(),
                                       vlPais.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: País está nulo!";
            }
            else
            {
                Classes.paises vlPais = (Classes.paises)pObj;
                return ExcluirToString(nameTable, "codigo", vlPais.Codigo.ToString());
            }
        }
    }
}
