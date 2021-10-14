using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class fornecedores : pessoas
    {
        private string Ffornecedor;
        private condicoesPagamento umaCondPag;

        public fornecedores()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Ffornecedor = "";
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

        public fornecedores(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                            string pFornecedor, string pLograd, string pNumero, string pCpl,
                            string pBairro, string pCEP, string pTel_Celular, string pEmail,
                            string pCNPJ_CPF, string pInscEst_RG, string pDataFund_Nasc)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Ffornecedor = pFornecedor;
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

        public string Fornecedor
        { get => Ffornecedor; set => Ffornecedor = value; }
        public condicoesPagamento UmaCondPag
        { get => umaCondPag; set => umaCondPag = value; }

        public fornecedores ThisFornecedor
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Fornecedor = ((fornecedores)pObj).Fornecedor;
            umaCondPag = ((fornecedores)pObj).UmaCondPag.ThisCondPag;
        }
        private fornecedores Clone()
        {
            var clone = new fornecedores(Codigo, CodigoUsu, DataCad, DataUltAlt, Fornecedor,
                                         Logradouro, Numero, Complemento, Bairro, CEP, Tel_celular,
                                         Email, CNPJ_CPF, InscEst_RG, DataFund_Nasc);
            clone.UmaCidade = UmaCidade.ThisCidade;
            clone.UmaCondPag = umaCondPag.ThisCondPag;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Fornecedor + ';' +
                   UmaCondPag.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "fornecedor" + ';' +
                   "codigoCondPag";
        }
        public override string[] toStringSearchPesquisa()
        {
            return new string[] { base.toStringSearchPesquisa()[0],
                                  "codigoCondPag = condicoesPagamento.codigo" };
        }
    }
}