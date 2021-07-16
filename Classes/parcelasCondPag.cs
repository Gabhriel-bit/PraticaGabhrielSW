using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class parcelasCondPag
    {
        private int FcodigoCondPag;
        private int Fnumero;
        private int Fdias;
        private decimal Fporcentagem;
        private Classes.formasPagamento FumaFormaPag;

        public parcelasCondPag()
        {
            FcodigoCondPag = 0;
            Fnumero = 0;
            Fdias = 0;
            Fporcentagem = 0;
            FumaFormaPag = new formasPagamento();
        }
        public parcelasCondPag(int pCodigoCondPag, int pNumero, int pDias, decimal pPorcenatgem)
        {
            FcodigoCondPag = pCodigoCondPag;
            Fnumero = pNumero;
            Fdias = pDias;
            Fporcentagem = pPorcenatgem;
            FumaFormaPag = new formasPagamento();
        }

        public int CodigoCondPag
        { get => FcodigoCondPag; set => FcodigoCondPag = value; }
        public int Numero
        { get => Fnumero; set => Fnumero = value; }
        public int Dias
        { get => Fdias; set => Fdias = value; }
        public decimal Porcentagem
        { get => Fporcentagem; set => Fporcentagem = Math.Round(value, 4); }
        public Classes.formasPagamento UmaFormaPag
        { get => FumaFormaPag; set => FumaFormaPag = value; }

        public parcelasCondPag ThisParcelasCondPag
        {
            get => Clone();
            set => SetObj(value);
        }

        protected void SetObj(object pObj)
        {
            FcodigoCondPag = ((parcelasCondPag)pObj).CodigoCondPag;
            Fnumero = ((parcelasCondPag)pObj).Numero;
            Fdias = ((parcelasCondPag)pObj).Dias;
            Fporcentagem = ((parcelasCondPag)pObj).Porcentagem;
            FumaFormaPag = ((parcelasCondPag)pObj).UmaFormaPag;
        }

        private parcelasCondPag Clone()
        {
            var vlObj = new parcelasCondPag(CodigoCondPag, Numero, Dias, Porcentagem);
            vlObj.UmaFormaPag = UmaFormaPag.ThisFormPag;
            return vlObj;
        }

        public string[] arrayStringValores(bool pFormatLV = false)
        {
            return toString(pFormatLV).Split(';');
        }

        public string[] arrayStringCampos(bool pFormatLV = false)
        {
            return toStringAttribute(pFormatLV).Split(';');
        }
        public string toString(bool pFormatLV = false)
        {
            if (pFormatLV)
            {
                return Numero.ToString() + ';' +
                       Dias.ToString() + ';' +
                       Porcentagem.ToString() + ';' +
                       UmaFormaPag.FormaPag;
            }
            return Numero.ToString() + ';' +
                   Dias.ToString() + ';' +
                   Porcentagem.ToString() + ';' +
                   UmaFormaPag.Codigo.ToString();
        }
        public string toStringAttribute(bool pFormatLV = false)
        {
            if (pFormatLV)
            {
                return "numero" + ';' +
                       "dias" + ';' +
                       "porcentagem" + ';' +
                       "codigoFormaPagamento";
            }
            return "codigoCondPag" + ';' +
                   "numero" + ';' +
                   "dias" + ';' +
                   "porcentagem" + ';' +
                   "codigoFormaPagamento";
        }
        public string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoFormaPagamento = formasPagamento.codigo" };
        }
    }
}
