using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class depositos : pai
    {
        private string Fdeposito;
        private string Flogradouro;
        private string Fnumero;
        private string Fcomplemento;
        private string Fbairro;
        private string Fcep;
        private cidades umaCidade;
        private List<produtos> listaProd;
        public depositos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fdeposito = "";
            Flogradouro = "";
            Fnumero = "";
            Fcomplemento = "";
            Fbairro = "";
            Fcep = "";
            umaCidade = new cidades();
        }
        public depositos(string pDeposito, string pLograd, string pNumero, string pCpl,
                         string pBairro, string pCEP)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fdeposito = pDeposito;
            Flogradouro = pLograd;
            Fnumero = pNumero;
            Fcomplemento = pCpl;
            Fbairro = pBairro;
            Fcep = pCEP;
            umaCidade = new cidades();
        }
        public depositos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                         string pDeposito, string pLograd, string pNumero, string pCpl,
                         string pBairro, string pCEP)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fdeposito = pDeposito;
            Flogradouro = pLograd;
            Fnumero = pNumero;
            Fcomplemento = pCpl;
            Fbairro = pBairro;
            Fcep = pCEP;
            umaCidade = new cidades();
        }

        public string Deposito
        { get => Fdeposito; set => Fdeposito = value; }
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
        public cidades UmaCidade
        { get => umaCidade; set => umaCidade = value; }
        public List<produtos> ListaProd
        { get => listaProd; set => listaProd = value; }

        public List<produtos> cloneListaProd()
        {
            var listaClone = new List<produtos>();
            foreach (produtos produto in listaProd)
            {
                listaClone.Add(produto);
            }
            return listaClone;
        }

        public depositos ThisDeposito
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Fdeposito = ((depositos)pObj).Deposito;
            Flogradouro = ((depositos)pObj).Logradouro;
            Fnumero = ((depositos)pObj).Numero;
            Fcomplemento = ((depositos)pObj).Complemento;
            Fbairro = ((depositos)pObj).Bairro;
            Fcep = ((depositos)pObj).Bairro;
            umaCidade = ((depositos)pObj).UmaCidade.ThisCidade;
        }

        public depositos Clone()
        {
            var clone = new depositos(Codigo, CodigoUsu, DataCad, DataUltAlt, Deposito,
                                      Logradouro, Numero, Complemento, Bairro, CEP);
            clone.UmaCidade = umaCidade.ThisCidade;
            clone.ListaProd = cloneListaProd();
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Deposito + ';' +
                   Logradouro + ';' +
                   Numero + ';' +
                   Complemento + ';' +
                   Bairro + ';' +
                   CEP + ';' +
                   UmaCidade.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "deposito" + ';' +
                   "logradouro" + ';' +
                   "numero" + ';' +
                   "complemento" + ';' +
                   "bairro" + ';' +
                   "cep" + ';' +
                   "codigoCidade";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoCidade = cidades.codigo" };
        }
    }
}