using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class vendas
    {
        private string Fmodelo;
        private string Fserie;
        private string Fnumero_NF;
        private clientes FumCliente;

        private string FdataEmissao;
        private string FdataSaida;
        private int FcodigoUsu;

        private decimal FtotalNota;

        private transportadoras FumaTransportadora;
        private condicoesPagamento FumaCondPag;

        private decimal FpesoBruto;
        private decimal FpesoLiquido;

        private List<itensVenda> FumaListaItens;
        private List<contasReceber> FumaListaContas;

        public vendas()
        {
            Fmodelo = "";
            Fserie = "";
            Fnumero_NF = "";
            FumCliente = new clientes();

            FdataEmissao = "";
            FcodigoUsu = 0;
            FumaTransportadora = new transportadoras();
            FumaCondPag = new condicoesPagamento();

            FpesoBruto = 0;
            FpesoLiquido = 0;
            FumaListaItens = new List<itensVenda>();
            FumaListaContas = new List<contasReceber>();
        }

        public vendas(string pModelo, string pSerie, string pNumNF, string pDataEmissao, string pDataSaida,
                      int pCodigoUsu, decimal pPesoBruto, decimal pPesoLiq, decimal pTotalNota)
        {
            Fmodelo = pModelo;
            Fserie = pSerie;
            Fnumero_NF = pNumNF;
            FumCliente = new clientes();

            FdataEmissao = pDataEmissao;
            FdataSaida = pDataSaida;
            FtotalNota = pTotalNota;
            FcodigoUsu = pCodigoUsu;
            FumaTransportadora = new transportadoras();
            FumaCondPag = new condicoesPagamento();

            FpesoBruto = pPesoBruto;
            FpesoLiquido = pPesoLiq;
            FumaListaItens = new List<itensVenda>();
            FumaListaContas = new List<contasReceber>();
        }

        public string PK
        { get => Fmodelo + ';' + Fserie + ';' + Fnumero_NF + ';' + FumCliente.Codigo.ToString(); }
        public string ToStringPK
        { get => "modelo;" + "serie;" + "numero_nf;" + "codigoCliente"; }

        public string Modelo
        { get => Fmodelo; set => Fmodelo = value; }
        public string Serie
        { get => Fserie; set => Fserie = value; }
        public string NumeroNF
        { get => Fnumero_NF; set => Fnumero_NF = value; }
        public string Emissao
        { get => FdataEmissao; set => FdataEmissao = value; }
        public string Saida
        { get => FdataSaida; set => FdataSaida = value; }
        public int CodigoUsu
        { get => FcodigoUsu; set => FcodigoUsu = value; }
        public decimal TotalNota
        { get => FtotalNota; set => FtotalNota = value; }
        public decimal PesoBruto
        { get => FpesoBruto; set => FpesoBruto = value; }
        public decimal PesoLiquido
        { get => FpesoLiquido; set => FpesoLiquido = value; }
        public transportadoras UmaTransportadora
        { get => FumaTransportadora; set => FumaTransportadora = value; }
        public condicoesPagamento UmaCondicaoPag
        { get => FumaCondPag; set => FumaCondPag = value; }
        public clientes UmCliente
        { get => FumCliente; set => FumCliente = value; }
        public List<itensVenda> UmaListaItens
        { get => FumaListaItens; set => FumaListaItens = value; }
        public List<contasReceber> UmaListaContasReceber
        { get => CloneListaContas(); set => FumaListaContas = value; }
        public List<itensVenda> CloneListaItens()
        {
            if (FumaListaItens.Count == 0)
            {
                return null;
            }
            else
            {
                var lista = new List<itensVenda>();
                foreach (itensVenda item in FumaListaItens)
                {
                    lista.Add(item.ThisItenVenda);
                }
                return lista;
            }
        }
        private List<contasReceber> CloneListaContas()
        {
            if (FumaListaContas.Count == 0)
            {
                return null;
            }
            else
            {
                var lista = new List<contasReceber>();
                foreach (contasReceber item in FumaListaContas)
                {
                    lista.Add(item.ThisContaReceber);
                }
                return lista;
            }
        }

        public vendas resetToBasic()
        {
            var vlClone = Clone();
            var vlReset = new vendas();
            ThisCompra = vlReset;
            return vlClone;
        }

        public vendas ThisCompra
        {
            get => Clone();
            set => SetObj(value);
        }

        protected void SetObj(object pObj)
        {
            var vlCompra = (vendas)pObj;
            Fmodelo = vlCompra.Modelo;
            Fserie = vlCompra.Serie;
            Fnumero_NF = vlCompra.NumeroNF;
            FumCliente = vlCompra.UmCliente;

            FdataEmissao = vlCompra.Emissao;
            FdataSaida = vlCompra.Saida;
            FtotalNota = vlCompra.TotalNota;
            FcodigoUsu = vlCompra.CodigoUsu;
            FumaTransportadora = vlCompra.UmaTransportadora;
            FumaCondPag = vlCompra.UmaCondicaoPag;

            FpesoBruto = vlCompra.PesoBruto;
            FpesoLiquido = vlCompra.PesoLiquido;
            FumaListaItens = vlCompra.UmaListaItens;
            FumaListaContas = vlCompra.UmaListaContasReceber;
        }

        private vendas Clone()
        {
            var vlObj = new vendas(Modelo, Serie, NumeroNF, FdataEmissao, FdataSaida, CodigoUsu,
                                    PesoBruto, PesoLiquido, TotalNota);
            vlObj.UmaCondicaoPag = UmaCondicaoPag.ThisCondPag;
            vlObj.UmaTransportadora = UmaTransportadora.ThisTransportadora;
            vlObj.UmCliente = UmCliente.ThisCliente;
            vlObj.UmaListaItens = UmaListaItens;
            vlObj.UmaListaContasReceber = UmaListaContasReceber;
            return vlObj;
        }

        public string toString()
        {
            return
            Fmodelo + ';' +
            Fserie + ';' +
            Fnumero_NF + ';' +
            FumCliente.Codigo.ToString() + ';' +

            FdataEmissao + ';' +
            FdataSaida + ';' +
            FtotalNota.ToString() + ';' +
            FcodigoUsu.ToString() + ';' +
            FpesoBruto.ToString() + ';' +
            FpesoLiquido.ToString() + ';' +
            FumaTransportadora.Codigo.ToString() + ';' +
            FumaCondPag.Codigo.ToString();
        }

        public string toStringAttribute()
        {
            return
            "modelo" + ';' +
            "serie" + ';' +
            "numero_nf" + ';' +
            "codigoCliente" + ';' +

            "data_emissao" + ';' +
            "data_saida" + ';' +
            "total_nota" + ';' +
            "codigoUsu" + ';' +
            "peso_bruto" + ';' +
            "peso_liquido" + ';' +
            "codigoTransp" + ';' +
            "codigoCondPag";
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
            return new string[] { "codigoCliente = clientes.codigo",
                                  "compras.codigoCondPag = condicoesPagamento.codigo"  };
        }
    }

    public class itensVenda
    {
        private string Fmodelo;
        private string Fserie;
        private string Fnumero_NF;
        private clientes FumCliente;

        private string Funidade;
        private int Fquantidade;
        private decimal FprecoUn;
        private decimal Fdesconto;
        private produtos FumProduto;

        public itensVenda()
        {
            Fmodelo = "";
            Fserie = "";
            Fnumero_NF = "";
            FumCliente = new clientes();

            Funidade = "";
            Fquantidade = 0;
            FprecoUn = 0;
            Fdesconto = 0;
            FumProduto = new produtos();
        }

        public itensVenda(string pModelo, string pSerie, string pNumNF, string pUnidade,
                           int pQuant, decimal pPrecoUn, decimal pDesconto)
        {
            Fmodelo = pModelo;
            Fserie = pSerie;
            Fnumero_NF = pNumNF;
            FumCliente = new clientes();

            Funidade = pUnidade;
            Fquantidade = pQuant;
            FprecoUn = pPrecoUn;
            Fdesconto = pDesconto;
            FumProduto = new produtos();
        }
        public string PK
        {
            get => Fmodelo + ';' + Fserie + ';' + Fnumero_NF + ';' +
                   FumCliente.Codigo.ToString() + ';' + FumProduto.Codigo.ToString();
        }
        public string Modelo
        { get => Fmodelo; set => Fmodelo = value; }
        public string Serie
        { get => Fserie; set => Fserie = value; }
        public string NumeroNF
        { get => Fnumero_NF; set => Fnumero_NF = value; }
        public string Unidade
        { get => Funidade; set => Funidade = value; }
        public int Quantidade
        { get => Fquantidade; set => Fquantidade = value; }
        public decimal PrecoUnidade
        { get => FprecoUn; set => FprecoUn = value; }
        public decimal Desconto
        { get => Fdesconto; set => Fdesconto = value; }
        public produtos UmProduto
        { get => FumProduto; set => FumProduto = value; }
        public clientes UmCliente
        { get => FumCliente; set => FumCliente = value; }

        public itensVenda ThisItenVenda
        {
            get => Clone();
            set => SetObj(value);
        }

        protected void SetObj(object pObj)
        {
            var vlItem = (itensVenda)pObj;
            Fmodelo = vlItem.Modelo;
            Fserie = vlItem.Serie;
            Fnumero_NF = vlItem.NumeroNF;

            Funidade = vlItem.Unidade;
            Fquantidade = vlItem.Quantidade;
            FprecoUn = vlItem.PrecoUnidade;
            Fdesconto = vlItem.Desconto;

            FumProduto = vlItem.UmProduto.ThisProduto;
            FumCliente = vlItem.UmCliente.ThisCliente;
        }

        private itensVenda Clone()
        {
            var vlObj = new itensVenda(Modelo, Serie, NumeroNF, Unidade, Quantidade,
                                        PrecoUnidade, Desconto);
            vlObj.UmCliente = UmCliente.ThisCliente;
            vlObj.UmProduto = UmProduto.ThisProduto;
            return vlObj;
        }

        public string toString()
        {
            return
            Fmodelo + ';' +
            Fserie + ';' +
            Fnumero_NF + ';' +
            FumCliente.Codigo.ToString() + ';' +

            Funidade + ';' +
            Fquantidade.ToString() + ';' +
            FprecoUn.ToString() + ';' +
            Fdesconto.ToString() + ';' +
            FumProduto.Codigo.ToString();
        }

        public string toStringAttribute()
        {
            return
            "modelo" + ';' +
            "serie" + ';' +
            "numero_nf" + ';' +
            "codigoCliente" + ';' +
            "unidade" + ';' +
            "quantidade" + ';' +
            "valor_un" + ';' +
            "desconto" + ';' +
            "codigoProd";
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
            return new string[] { "codigoCliente = clientes.codigo", "codigoProd = produtos.codigo" };
        }
    }
}