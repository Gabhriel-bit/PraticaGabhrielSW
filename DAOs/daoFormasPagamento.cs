using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoFormasPagamento : daos
    {
        public const string nameTable = "formasPagamento";
        public daoFormasPagamento() { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Forma de pagamento está nula!";
            }
            else
            {
                Classes.formasPagamento vlFormPag = (Classes.formasPagamento)pObj;
                return InserirToString(nameTable, vlFormPag.arrayStringCampos(),
                                       vlFormPag.arrayStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Forma de pagamento está nula!";
            }
            else
            {
                Classes.formasPagamento vlFormPag = (Classes.formasPagamento)pObj;
                return AlterarToString(nameTable, vlFormPag.arrayStringCampos(),
                                       vlFormPag.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Forma de pagamento está nula!";
            }
            else
            {
                Classes.formasPagamento vlFormPag = (Classes.formasPagamento)pObj;
                return ExcluirToString(nameTable, "codigo", vlFormPag.Codigo.ToString());
            }
        }
    }
}
