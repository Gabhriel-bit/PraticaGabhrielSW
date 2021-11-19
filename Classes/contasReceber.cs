using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class contasReceber
    {
		private string Fmodelo;
		private string Fserie;
		private string Fnumero_nf;

		private clientes FumCliente;

		private int Fparcela;
		private string Fvencimento;
		private string FdataPagament;
		private decimal FvalorTotal;
		private decimal FvalorPago;
		private formasPagamento FumaFormaPag;

		private decimal FdescontoPag;
		private decimal FtaxaJuros;
		private decimal Fmulta;

		private int FcodigoUsu;
		private string FdataCad;

		public contasReceber()
		{
			Fmodelo = "";
			Fserie = "";
			Fnumero_nf = "";
			Fparcela = 0;
			Fvencimento = "";
			FdataPagament = "";
			FvalorTotal = 0;
			FvalorPago = 0;

			FcodigoUsu = 0;
			FdataCad = "";

			FdescontoPag = 0;
			FtaxaJuros = 0;
			Fmulta = 0;

			FumCliente = new clientes();
			FumaFormaPag = new formasPagamento();
		}

		public contasReceber(string pModelo, string pSerie, string pNumNF, int pParcela,
						   string pVencimento, string pDataPag, decimal pValorTotal,
						   decimal pValorPago, int pCodigoUsu, string pDataCad, decimal pDescontoPag,
						   decimal pTaxaJuros, decimal pMulta)
		{
			Fmodelo = pModelo;
			Fserie = pSerie;
			Fnumero_nf = pNumNF;
			Fparcela = pParcela;
			Fvencimento = pVencimento;
			FdataPagament = pDataPag;
			FvalorTotal = pValorTotal;
			FvalorPago = pValorPago;

			FcodigoUsu = pCodigoUsu;
			FdataCad = pDataCad;

			FdescontoPag = pDescontoPag;
			FtaxaJuros = pTaxaJuros;
			Fmulta = pMulta;

			FumCliente = new clientes();
			FumaFormaPag = new formasPagamento();
		}

		public string PK
		{ get => Fmodelo + ';' + Fserie + ';' + Fnumero_nf + ';' + FumCliente.Codigo.ToString(); }
		public string ToStringPK
		{ get => "modelo;" + "serie;" + "numero_nf;" + "codigoCliende"; }

		public string Modelo
		{ set => Fmodelo = value; get => Fmodelo; }
		public string Serie
		{ set => Fserie = value; get => Fserie; }
		public string NumeroNF
		{ set => Fnumero_nf = value; get => Fnumero_nf; }
		public int Parcela
		{ set => Fparcela = value; get => Fparcela; }
		public string Vencimento
		{ set => Fvencimento = value; get => Fvencimento; }
		public string DataPagamento
		{ set => FdataPagament = value; get => FdataPagament; }
		public decimal ValorTotal
		{ set => FvalorTotal = value; get => FvalorTotal; }
		public decimal ValorPago
		{ set => FvalorPago = value; get => FvalorPago; }
		public int CodigoUsu
		{ set => FcodigoUsu = value; get => FcodigoUsu; }
		public string DataCadastro
		{ set => FdataCad = value; get => FdataCad; }
		public clientes UmCliente
		{ set => FumCliente = value; get => FumCliente; }
		public formasPagamento UmaFormaPag
		{ set => FumaFormaPag = value; get => FumaFormaPag; }
		public decimal DescontoPag
		{ get => FdescontoPag; set => FdescontoPag = value; }
		public decimal TaxaJuros
		{ get => FtaxaJuros; set => FtaxaJuros = value; }
		public decimal Multa
		{ get => Fmulta; set => Fmulta = value; }

		public contasReceber ThisContaReceber
		{
			get => clone();
			set => SetObj(value);
		}

		protected contasReceber clone()
		{
			var vlConta = new contasReceber(Modelo, Serie, NumeroNF, Parcela, Vencimento, DataPagamento,
								   ValorTotal, ValorPago, CodigoUsu, DataCadastro, DescontoPag,
								   TaxaJuros, Multa);
			vlConta.UmaFormaPag = UmaFormaPag.ThisFormPag;
			vlConta.UmCliente = UmCliente.ThisCliente;
			return vlConta;
		}

		protected void SetObj(object pObj)
		{
			var vlUmaContaPagar = (contasReceber)pObj;
			Fmodelo = vlUmaContaPagar.Modelo;
			Fserie = vlUmaContaPagar.Serie;
			Fnumero_nf = vlUmaContaPagar.NumeroNF;
			Fparcela = vlUmaContaPagar.Parcela;
			Fvencimento = vlUmaContaPagar.Vencimento;
			FdataPagament = vlUmaContaPagar.DataPagamento;
			FvalorTotal = vlUmaContaPagar.ValorTotal;
			FvalorPago = vlUmaContaPagar.ValorPago;

			FcodigoUsu = vlUmaContaPagar.CodigoUsu;
			FdataCad = vlUmaContaPagar.DataCadastro;

			FdescontoPag = vlUmaContaPagar.DescontoPag;
			FtaxaJuros = vlUmaContaPagar.TaxaJuros;
			Fmulta = vlUmaContaPagar.Multa;

			UmCliente = vlUmaContaPagar.UmCliente.ThisCliente;
			UmaFormaPag = vlUmaContaPagar.UmaFormaPag.ThisFormPag;
		}

		public string toString()
		{
			return Modelo + ';' +
				   Serie + ';' +
				   NumeroNF + ';' +
				   UmCliente.Codigo.ToString() + ';' +
				   Parcela.ToString() + ';' +
				   Vencimento + ';' +
				   DataPagamento + ';' +
				   ValorTotal.ToString() + ';' +
				   ValorPago.ToString() + ';' +
				   CodigoUsu.ToString() + ';' +
				   DataCadastro + ';' +
				   UmaFormaPag.Codigo.ToString() + ';' +
				   DescontoPag.ToString() + ';' +
				   TaxaJuros.ToString() + ';' +
				   Multa.ToString();
		}

		public string toStringAttribute()
		{
			return "modelo" + ';' +
				   "serie" + ';' +
				   "numero_nf" + ';' +
				   "codigoCliente" + ';' +
				   "parcela" + ';' +
				   "vencimento" + ';' +
				   "dataPagamento" + ';' +
				   "valorTotal" + ';' +
				   "valorPago" + ';' +
				   "codigoUsu" + ';' +
				   "dataCad" + ';' +
				   "codigoFormaPag" + ';' +
				   "descontoPag" + ';' +
				   "taxaJuros" + ';' +
				   "multa";
		}


		public string[] arrayStringValores()
		{
			return toString().Split(';');
		}
		public string[] arrayStringCampos()
		{
			return toStringAttribute().Split(';');
		}
		public string[] toStringSearchPesquisa()
		{
			return new string[] { "codigoCliente = clientes.codigo", "codigoFormaPag = formasPagamento.codigo" };
		}
	}
}
