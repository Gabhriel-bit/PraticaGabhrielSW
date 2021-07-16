using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class condicoesPagamento : pai
    {
        private string FcondicaoPag;
        private int FtotalParcela;
        private decimal FtaxaJuros;
        private decimal Fmulta;
        private decimal Fdesconto;
        private List<parcelasCondPag> FlistaParcelas;

        public condicoesPagamento()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            FcondicaoPag = "";
            FtotalParcela = 0;
            FtaxaJuros = 0;
            Fmulta = 0;
            Fdesconto = 0;
            FlistaParcelas = new List<parcelasCondPag>();
        }
        public condicoesPagamento(string pCondicaoP, int pTotalParcela, decimal pTaxaJuros,
                                  decimal pMulta, decimal pDesconto)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            FcondicaoPag = pCondicaoP;
            FtotalParcela = pTotalParcela;
            FtaxaJuros = pTaxaJuros;
            Fmulta = pMulta;
            Fdesconto = pDesconto;
            FlistaParcelas = new List<parcelasCondPag>();

        }
        public condicoesPagamento(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltData,
                                  string pCondicaoP, int pTotalParcela, decimal pTaxaJuros, decimal pMulta,
                                  decimal pDesconto)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltData;

            FcondicaoPag = pCondicaoP;
            FtotalParcela = pTotalParcela;
            FtaxaJuros = pTaxaJuros;
            Fmulta = pMulta;
            Fdesconto = pDesconto;
            FlistaParcelas = new List<parcelasCondPag>();
        }

        public string CondicaoPag
        { get => FcondicaoPag; set => FcondicaoPag = value; }

        public int TotalParcelas
        { get => FtotalParcela; set => FtotalParcela = value; }

        public decimal TaxaJuros
        { get => FtaxaJuros; set => FtaxaJuros = Math.Round(value, 4); }

        public decimal Multa
        { get => Fmulta; set => Fmulta = Math.Round(value, 4); }

        public decimal Desconto
        { get => Fdesconto; set => Fdesconto = Math.Round(value, 4); }

        public List<parcelasCondPag> ListaParcelas
        { get => CloneListaParcelas(); set => FlistaParcelas = value; }

        private List<parcelasCondPag> CloneListaParcelas()
        {
            if (FlistaParcelas.Count == 0)
            {
                return null;
            }
            else
            {
                var lista = new List<parcelasCondPag>();
                foreach (parcelasCondPag parcela in FlistaParcelas)
                {
                    lista.Add(parcela.ThisParcelasCondPag);
                }
                return lista;
            }
        }

        public condicoesPagamento ThisCondPag
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            CondicaoPag = ((condicoesPagamento)pObj).CondicaoPag;
            TotalParcelas = ((condicoesPagamento)pObj).TotalParcelas;
            TaxaJuros = ((condicoesPagamento)pObj).TaxaJuros;
            Multa = ((condicoesPagamento)pObj).Multa;
            Desconto = ((condicoesPagamento)pObj).Desconto;
            ListaParcelas = ((condicoesPagamento)pObj).ListaParcelas;
        }
        private condicoesPagamento Clone(bool pRetornaListaParcela = true)
        {
            var vlCondPag = new condicoesPagamento(Codigo, CodigoUsu, DataCad, DataUltAlt,
                                                   CondicaoPag, TotalParcelas, TaxaJuros,
                                                   Multa, Desconto);
            if (pRetornaListaParcela)
            {
                vlCondPag.ListaParcelas = CloneListaParcelas();
            }
            return vlCondPag;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   CondicaoPag + ';' +
                   TotalParcelas.ToString() + ';' +
                   TaxaJuros.ToString() + ';' +
                   Multa.ToString() + ';' +
                   Desconto.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "condicaoPagamento" + ';' +
                   "totalParcelas" + ';' +
                   "taxaJuros" + ';' +
                   "multa" + ';' +
                   "desconto";
        }
    }
}
