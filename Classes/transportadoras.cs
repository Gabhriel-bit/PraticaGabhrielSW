using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class transportadoras : pessoas
    {
        private string Ftransportadora;
        public transportadoras()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Ftransportadora = "";

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
        }

        public transportadoras(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                            string pTransportadora, string pLograd, string pNumero, string pCpl,
                            string pBairro, string pCEP, string pTel_Celular, string pEmail,
                            string pCNPJ_CPF, string pInscEst_RG, string pDataFund_Nasc)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Ftransportadora = pTransportadora;
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
        }

        public string Transportadora
        { get => Ftransportadora; set => Ftransportadora = value; }

        public transportadoras ThisTransportadora
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Transportadora = ((transportadoras)pObj).Transportadora;
        }
        private transportadoras Clone()
        {
            var clone = new transportadoras(Codigo, CodigoUsu, DataCad, DataUltAlt, Transportadora,
                                           Logradouro, Numero, Complemento, Bairro, CEP, Tel_celular,
                                           Email, CNPJ_CPF, InscEst_RG, DataFund_Nasc);
            clone.UmaCidade = UmaCidade.ThisCidade;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Transportadora;
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "transportadora";
        }
    }
}
