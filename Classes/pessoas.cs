using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class pessoas : pai
    {
        private string Flogradouro;
        private string Fnumero;
        private string Fcomplemento;
        private string Fbairro;
        private string Fcep;
        private string Ftel_celular;
        private string Femail;
        private cidades umaCidade;
        private string Fcnpj_cpf;
        private string FinscEst_rg;
        private string FdataFund_nasc;

        public string Logradouro
        { get => Flogradouro; set => Flogradouro = value; }
        public string Numero
        { get => Fnumero; set => Fnumero = value; }
        public string Complemento
        { get => Fcomplemento; set => Fcomplemento = value; }
        public string Bairro
        { get => Fbairro; set => Fbairro = value; }
        public string CEP
        { get => Fcep; set => Fcep = value; }
        public string Tel_celular
        { get => Ftel_celular; set => Ftel_celular = value; }
        public string Email
        { get => Femail; set => Femail = value; }
        public cidades UmaCidade
        { get => umaCidade; set => umaCidade = value; }
        public string CNPJ_CPF
        { get => Fcnpj_cpf; set => Fcnpj_cpf = value; }
        public string InscEst_RG
        { get => FinscEst_rg; set => FinscEst_rg = value; }
        public string DataFund_Nasc
        { get => FdataFund_nasc; set => FdataFund_nasc = value; }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            var vlPessoa = (pessoas)pObj;
            Flogradouro = vlPessoa.Logradouro;
            Fnumero = vlPessoa.Numero;
            Fcomplemento = vlPessoa.Complemento;
            Fbairro = vlPessoa.Bairro;
            Fcep = vlPessoa.CEP;
            Ftel_celular = vlPessoa.Tel_celular;
            Femail = vlPessoa.Email;
            umaCidade = vlPessoa.umaCidade.ThisCidade;
            Fcnpj_cpf = vlPessoa.Fcnpj_cpf;
            FinscEst_rg = vlPessoa.FinscEst_rg;
            FdataFund_nasc = vlPessoa.DataFund_Nasc;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Logradouro + ';' +
                   Numero + ';' +
                   Complemento + ';' +
                   Bairro + ';' +
                   CEP + ';' +
                   Tel_celular + ';' +
                   Email + ';' +
                   UmaCidade.Codigo.ToString() + ';' +
                   CNPJ_CPF + ';' +
                   InscEst_RG + ';' +
                   DataFund_Nasc;
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "logradouro" + ';' +
                   "numero" + ';' +
                   "complemento" + ';' +
                   "bairro" + ';' +
                   "cep" + ';' +
                   "tel_Celular" + ';' +
                   "email" + ';' +
                   "codigoCidade" + ';' +
                   "cnpj_cpf" + ';' +
                   "inscEst_rg" + ';' +
                   "dataFund_Nasc";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoCidade = cidades.codigo" };
        }
    }
}
