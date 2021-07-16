using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class clientes : pessoas
    {
        private string Fcliente;
        private condicoesPagamento umaCondPag;

        public clientes()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fcliente = "";
            Logradouro = "";
            Numero = "";
            Complemento = "";
            Bairro = "";
            CEP = "";
            Tel_celular = "";
            Email = "";
            CNPJ_CPF = "";
            InscEst_RG = "";
            DataFund_Nasc = "";

            UmaCidade = new cidades();
            umaCondPag = new condicoesPagamento();
        }
        public clientes(string pCliente)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fcliente = pCliente;
            Logradouro = "";
            Numero = "";
            Complemento = "";
            Bairro = "";
            CEP = "";
            Tel_celular = "";
            Email = "";
            CNPJ_CPF = "";
            InscEst_RG = "";
            DataFund_Nasc = "";

            UmaCidade = new cidades();
            umaCondPag = new condicoesPagamento();
        }

        public clientes(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                            string pCliente, string pLograd, string pNumero, string pCpl,
                            string pBairro, string pCEP, string pTel_Celular, string pEmail,
                            string pCNPJ_CPF, string pInscEst_RG, string pDataFund_Nasc)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fcliente = pCliente;
            Logradouro = pLograd;
            Numero = pNumero;
            Complemento = pCpl;
            Bairro = pBairro;
            CEP = pCEP;
            Tel_celular = pTel_Celular;
            Email = pEmail;
            CNPJ_CPF = pCNPJ_CPF;
            InscEst_RG = pInscEst_RG;
            DataFund_Nasc = pDataFund_Nasc;

            UmaCidade = new cidades();
            umaCondPag = new condicoesPagamento();
        }

        public string Cliente
        { get => Fcliente; set => Fcliente = value; }
        public condicoesPagamento UmaCondPag
        { get => umaCondPag; set => umaCondPag = value; }

        public clientes ThisCliente
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Cliente = ((clientes)pObj).Cliente;
            UmaCidade = ((clientes)pObj).UmaCidade.ThisCidade;
            UmaCondPag = ((clientes)pObj).UmaCondPag.ThisCondPag;
        }
        private clientes Clone()
        {
            var clone = new clientes(Codigo, CodigoUsu, DataCad, DataUltAlt, Cliente,
                                     Logradouro, Numero, Complemento, Bairro, CEP, Tel_celular,
                                     Email, CNPJ_CPF, InscEst_RG, DataFund_Nasc);
            clone.UmaCidade = UmaCidade.ThisCidade;
            clone.UmaCondPag = umaCondPag.ThisCondPag;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Cliente + ';' +
                   UmaCondPag.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "cliente" + ';' +
                   "codigoCondPag";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { base.toStringSearchPesquisa()[0],
                                  "codigoCondPag = condicoesPagamento.codigo" };
        }
    }
}
