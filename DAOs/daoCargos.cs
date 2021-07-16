using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoCargos : daos
    {
        public const string nameTable = "cargos";
        public daoCargos() { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cargo está nulo!";
            }
            else
            {
                Classes.cargos vlCargo = (Classes.cargos)pObj;
                return InserirToString(nameTable, vlCargo.arrayStringCampos(),
                                       vlCargo.arryStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cargo está nulo!";
            }
            else
            {
                Classes.cargos vlCargo = (Classes.cargos)pObj;
                return AlterarToString(nameTable, vlCargo.arrayStringCampos(),
                                       vlCargo.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Cargo está nulo!";
            }
            else
            {
                Classes.cargos vlCargo = (Classes.cargos)pObj;
                return ExcluirToString(nameTable, "codigo", vlCargo.Codigo.ToString());
            }
        }
    }
}
