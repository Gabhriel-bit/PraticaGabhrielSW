using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoEquipamentos : daos
    {
        public const string nameTable = "equipamentos";
        public daoEquipamentos(){ }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Equipamento está nulo!";
            }
            else
            {
                Classes.equipamentos vlEquip = (Classes.equipamentos)pObj;
                return InserirToString(nameTable, vlEquip.arrayStringCampos(),
                                       vlEquip.arryStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Equipamento está nulo!";
            }
            else
            {
                Classes.equipamentos vlEquip = (Classes.equipamentos)pObj;
                return AlterarToString(nameTable, vlEquip.arrayStringCampos(),
                                             vlEquip.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Equipamento está nulo!";
            }
            else
            {
                Classes.equipamentos vlEquip = (Classes.equipamentos)pObj;
                return ExcluirToString(nameTable, "codigo", vlEquip.Codigo.ToString());
            }
        }
    }
}
