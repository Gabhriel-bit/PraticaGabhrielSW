using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.DAOs
{
    public class daoContasPagar : daos
    {
        public const string nameTable = "contas_pagar";
        public daoContasPagar()
        { }
        public override string Inserir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Contas a pagar está nula!";
            }
            else
            {
                Classes.contasPagar vlConta = (Classes.contasPagar)pObj;
                return InserirToString(nameTable, vlConta.arrayStringCampos(),
                                       vlConta.arrayStringValores(), true);
            }
        }
        public override string Inserir(List<object> pObj)
        {
            if (pObj.Count == 0)
            {
                return "Erro: Lista de contas a pagar está vazia!";
            }
            else
            {
                string vlMsg = "";
                foreach (object Conta in pObj)
                {
                    var vlConta = (Classes.contasPagar)Conta;
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
                return "Erro: Conta a pagar  está nula!";
            }
            else
            {
                Classes.contasPagar vlConta = (Classes.contasPagar)pObj;
                return AlterarToString(nameTable, vlConta.arrayStringCampos(),
                                             vlConta.arrayStringValores());
            }
        }

        public override string Excluir(object pObj)
        {
            if (pObj == null)
            {
                return "Erro: Conta a pagar está nula!";
            }
            else
            {
                var vlConta = (Classes.contasPagar)pObj;
                return ExcluirToString(nameTable, vlConta.ToStringPK.Split(';'),
                                                  vlConta.PK.Split(';'));
            }
        }
    }
}
