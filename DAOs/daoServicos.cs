using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoServicos : daos
    {
        public const string nameTable = "servicos";
        public daoServicos() { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Serviço está nulo!";
            }
            else
            {
                Classes.servicos vlServico = (Classes.servicos)pObj;
                return InserirToString(nameTable, vlServico.arrayStringCampos(),
                                       vlServico.arrayStringValores());
            }
        }

        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Serviço está nulo!";
            }
            else
            {
                Classes.servicos vlServico = (Classes.servicos)pObj;
                return AlterarToString(nameTable, vlServico.arrayStringCampos(),
                                       vlServico.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Servico está nulo!";
            }
            else
            {
                Classes.servicos vlServico = (Classes.servicos)pObj;
                return ExcluirToString(nameTable, "codigo", vlServico.Codigo.ToString());
            }
        }
    }
}
