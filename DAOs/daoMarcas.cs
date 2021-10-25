using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoMarcas : daos
    {
        public const string nameTable = "marcas";
        public daoMarcas() { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Marca está nula!";
            }
            else
            {
                Classes.marcas vlMarca = (Classes.marcas)pObj;
                return InserirToString(nameTable, vlMarca.arrayStringCampos(),
                                       vlMarca.arrayStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Marca está nula!";
            }
            else
            {
                Classes.marcas vlMarca = (Classes.marcas)pObj;
                return AlterarToString(nameTable, vlMarca.arrayStringCampos(),
                                       vlMarca.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Marca está nula!";
            }
            else
            {
                Classes.marcas vlMarca = (Classes.marcas)pObj;
                return ExcluirToString(nameTable, "codigo", vlMarca.Codigo.ToString());
            }
        }
    }
}
