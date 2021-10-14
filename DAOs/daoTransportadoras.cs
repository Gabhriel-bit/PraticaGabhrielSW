using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoTransportadoras : daos
    {
        public const string nameTable = "transportadoras";
        public daoTransportadoras()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Transportadora está nulo!";
            }
            else
            {
                Classes.transportadoras vlTransportadora = (Classes.transportadoras)pObj;
                return InserirToString(nameTable, vlTransportadora.arrayStringCampos(),
                                       vlTransportadora.arryStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Transportadora está nulo!";
            }
            else
            {
                Classes.transportadoras vlTransportadora = (Classes.transportadoras)pObj;
                return AlterarToString(nameTable, vlTransportadora.arrayStringCampos(),
                                             vlTransportadora.arryStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Transportadora está nulo!";
            }
            else
            {
                Classes.transportadoras vlTransportadora = (Classes.transportadoras)pObj;
                return ExcluirToString(nameTable, "codigo", vlTransportadora.Codigo.ToString());
            }
        }
    }
}
