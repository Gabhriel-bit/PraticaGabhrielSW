using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class contasPagar
    {
		private string Fmodelo;
		private string Fserie;
		private string Fnumero_nf;

		private fornecedores FumForn;  

		private int Fparcela;     
		private string Fvencimento;
		private string FdataPagament;
		private decimal FvalorTotal;  
		private decimal FvalorPago;   

		private int FcodigoUsu;   
		private string FdataCad;

		public contasPagar()
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

			FumForn = new fornecedores();
		}

		public contasPagar(string pModelo, string pSerie, string pNumNF, int pParcela,
						   string pVencimento, string pDataPag, decimal pValorTotal,
						   decimal pValorPago, int pCodigoUsu, string pDataCad)
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

			FumForn = new fornecedores();
		}

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
		public fornecedores UmFornecedor
		{ set => FumForn = value; get => FumForn; }

		public contasPagar ThisContaPagar
		{
			get => new contasPagar(Modelo, Serie, NumeroNF, Parcela, Vencimento, DataPagamento,
				                   ValorTotal, ValorPago, CodigoUsu, DataCadastro);
			set => SetObj(value);
		}

		protected void SetObj(object pObj)
		{
			var vlUmaContaPagar = (contasPagar)pObj;
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

			UmFornecedor = vlUmaContaPagar.UmFornecedor.ThisFornecedor;
		}

		public string toString()
		{
			return Modelo + ';' +
				   Serie + ';' +
				   NumeroNF + ';' +
				   UmFornecedor.Codigo.ToString() + ';' +
				   Parcela.ToString() + ';' +
				   Vencimento + ';' +
				   DataPagamento + ';' +
				   ValorTotal.ToString() + ';' +
				   ValorPago.ToString() + ';' +
				   CodigoUsu.ToString() + ';' +
				   DataCadastro;
		}

		public string toStringAttribute()
		{
			return "modelo" + ';' +
				   "serie" + ';' +
				   "numero_nf" + ';' +
				   "codigoForn" + ';' +
				   "parcela" + ';' +
				   "vencimento" + ';' +
				   "dataPagamento" + ';' +
				   "valorTotal" + ';' +
				   "valorPago" + ';' +
				   "codigoUsu" + ';' +
				   "dataCad";
		}
	}
}
