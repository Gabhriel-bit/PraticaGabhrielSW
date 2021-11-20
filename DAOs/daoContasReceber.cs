using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoContasReceber:daos
    {
        public const string nameTable = "contas_receber";
        public daoContasReceber()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Contas a receber está nula!";
            }
            else
            {
                Classes.contasReceber vlConta = (Classes.contasReceber)pObj;
                return InserirToString(nameTable, vlConta.arrayStringCampos(),
                                       vlConta.arrayStringValores(), true);
            }
        }
        public override string Inserir(List<object> pObj)
        {
            if (pObj.Count == 0)
            {
                return "Erro: Lista de contas a receber está vazia!";
            }
            else
            {
                string vlMsg = "";
                foreach (object Conta in pObj)
                {
                    var vlConta = (Classes.contasReceber)Conta;
                    vlMsg += InserirToString(nameTable, vlConta.arrayStringCampos(),
                                       vlConta.arrayStringValores(), true) + '\n';
                }
                return vlMsg;
            }
        }
        public override string Alterar(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Conta a receber  está nula!";
            }
            else
            {
                Classes.contasReceber vlConta = (Classes.contasReceber)pObj;
                return AlterarToString(nameTable, vlConta.arrayStringCampos(),
                                             vlConta.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Conta a receber está nula!";
            }
            else
            {
                var vlConta = (Classes.contasReceber)pObj;
                return ExcluirToString(nameTable, vlConta.ToStringPK.Split(';'),
                                                  vlConta.PK.Split(';'), true);
            }
        }
    }
}
