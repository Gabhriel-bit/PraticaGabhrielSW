using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class compras
    {
        private string Fmodelo;
        private string Fserie;
        private string Fnumero_NF;
        private fornecedores FumForn;

        private string FdataEmissao;
        private string FdataChegada;
        private string FchaveAcesso;
        private int FcodigoUsu;

        private decimal FtotalNota;
        private decimal FtotalProdutos;

        private decimal FvalorFrete;
        private decimal FvaloSeguro;
        private decimal FoutrasDeps;
        private transportadoras FumaTransportadora;
        private condicoesPagamento FumaCondPag;

        private decimal FpesoBruto;
        private decimal FpesoLiquido;

        private List<itensCompra> FumaListaItens;
        private List<contasPagar> FumaListaContas;

        public compras()
        {
            Fmodelo = "";
            Fserie = "";
            Fnumero_NF = "";
            FumForn = new fornecedores();

            FdataEmissao = "";
            FdataChegada = "";
            FchaveAcesso = "";
            FcodigoUsu = 0;
            FvalorFrete = 0;
            FvaloSeguro = 0;
            FoutrasDeps = 0;
            FumaTransportadora = new transportadoras();
            FumaCondPag = new condicoesPagamento();

            FpesoBruto = 0;
            FpesoLiquido = 0;
            FumaListaItens = new List<itensCompra>();
            FumaListaContas = new List<contasPagar>();
        }

        public compras(string pModelo, string pSerie, string pNumNF, string pDataEmissao, string pDataChegada,
                       string pChaveAcesso, decimal pFrete, decimal pSeguro,
                       decimal pOutrasDeps, int pCodigoUsu, decimal pPesoBruto, decimal pPesoLiq,
                       decimal pTotalNota, decimal pTotalProduto)
        {
            Fmodelo = pModelo;
            Fserie = pSerie;
            Fnumero_NF = pNumNF;
            FumForn = new fornecedores();

            FdataEmissao = pDataEmissao;
            FdataChegada = pDataChegada;
            FtotalNota = pTotalNota;
            FtotalProdutos = pTotalProduto;
            FchaveAcesso = pChaveAcesso;
            FcodigoUsu = pCodigoUsu;
            FvalorFrete = pFrete;
            FvaloSeguro = pSeguro;
            FoutrasDeps = pOutrasDeps;
            FumaTransportadora = new transportadoras();
            FumaCondPag = new condicoesPagamento();

            FpesoBruto = pPesoBruto;
            FpesoLiquido = pPesoLiq;
            FumaListaItens = new List<itensCompra>();
            FumaListaContas = new List<contasPagar>();
        }

        public string PK
        { get => Fmodelo + ';' + Fserie + ';' + Fnumero_NF + ';' + FumForn.Codigo.ToString(); }
        public string ToStringPK
        { get => "modelo;" + "serie;" + "numero_nf;" + "codigoForn"; }

        public string Modelo
        { get=> Fmodelo; set=> Fmodelo = value; }
        public string Serie
        { get=> Fserie; set=> Fserie = value; }
        public string NumeroNF
        { get => Fnumero_NF; set => Fnumero_NF = value; }
        public string Emissao
        { get => FdataEmissao; set => FdataEmissao = value; }
        public string Chegada
        { get => FdataChegada; set => FdataChegada = value; }
        public string ChaveAcesso
        { get => FchaveAcesso; set => FchaveAcesso = value; }
        public int CodigoUsu
        { get => FcodigoUsu; set => FcodigoUsu = value; }
        public decimal TotalNota
        { get => FtotalNota; set => FtotalNota = value; }
        public decimal TotalProdutos
        { get => FtotalProdutos; set => FtotalProdutos = value; }
        public decimal Frete
        { get => FvalorFrete; set => FvalorFrete = value; }
        public decimal Seguro
        { get => FvaloSeguro; set => FvaloSeguro = value; }
        public decimal OutrasDeps
        { get => FoutrasDeps; set => FoutrasDeps = value; }
        public decimal PesoBruto
        { get => FpesoBruto; set => FpesoBruto = value; }
        public decimal PesoLiquido
        { get => FpesoLiquido; set => FpesoLiquido = value; }
        public transportadoras UmaTransportadora
        { get => FumaTransportadora; set => FumaTransportadora = value; }
        public condicoesPagamento UmaCondicaoPag
        { get => FumaCondPag; set => FumaCondPag = value; }
        public fornecedores UmFornecedor
        { get => FumForn; set => FumForn = value; }
        public List<itensCompra> UmaListaItens
        { get => CloneListaItens(); set => FumaListaItens = value; }
        public List<contasPagar> UmaListaContasPagar
        { get => CloneListaContas(); set => FumaListaContas = value; }
        private List<itensCompra> CloneListaItens()
        {
            if (FumaListaItens.Count == 0)
            {
                return null;
            }
            else
            {
                var lista = new List<itensCompra>();
                foreach (itensCompra item in FumaListaItens)
                {
                    lista.Add(item.ThisItenCompra);
                }
                return lista;
            }
        }
        private List<contasPagar> CloneListaContas()
        {
            if (FumaListaContas.Count == 0)
            {
                return null;
            }
            else
            {
                var lista = new List<contasPagar>();
                foreach (contasPagar item in FumaListaContas)
                {
                    lista.Add(item.ThisContaPagar);
                }
                return lista;
            }
        }
        public compras ThisCompra
        {
            get => Clone();
            set => SetObj(value);
        }

        protected void SetObj(object pObj)
        {
            var vlCompra = (compras)pObj;
            Fmodelo = vlCompra.Modelo;
            Fserie = vlCompra.Serie;
            Fnumero_NF = vlCompra.NumeroNF;
            FumForn = vlCompra.UmFornecedor;

            FdataEmissao = vlCompra.Emissao;
            FdataChegada = vlCompra.Chegada;
            FtotalNota = vlCompra.TotalNota;
            FtotalProdutos = vlCompra.TotalProdutos;
            FchaveAcesso = vlCompra.ChaveAcesso;
            FcodigoUsu = vlCompra.CodigoUsu;
            FvalorFrete = vlCompra.Frete;
            FvaloSeguro = vlCompra.Seguro;
            FoutrasDeps = vlCompra.OutrasDeps;
            FumaTransportadora = vlCompra.UmaTransportadora;
            FumaCondPag = vlCompra.UmaCondicaoPag;

            FpesoBruto = vlCompra.PesoBruto;
            FpesoLiquido = vlCompra.PesoLiquido;
            FumaListaItens = vlCompra.UmaListaItens;
            FumaListaContas = vlCompra.UmaListaContasPagar;
        }

        private compras Clone()
        {
            var vlObj = new compras(Modelo, Serie, NumeroNF, FdataEmissao, FdataChegada, ChaveAcesso,
                                    Frete, Seguro, OutrasDeps, CodigoUsu, PesoBruto,
                                    PesoLiquido, TotalNota, TotalProdutos);
            vlObj.UmaCondicaoPag = UmaCondicaoPag.ThisCondPag;
            vlObj.UmaTransportadora = UmaTransportadora.ThisTransportadora;
            vlObj.UmFornecedor = UmFornecedor.ThisFornecedor;
            vlObj.UmaListaItens = UmaListaItens;
            vlObj.UmaListaContasPagar = UmaListaContasPagar;
            return vlObj;
        }

        public string toString()
        {
            return
            Fmodelo + ';' +
            Fserie + ';' +
            Fnumero_NF + ';' +
            FumForn.Codigo.ToString() + ';' +

            FdataEmissao + ';' +
            FdataChegada + ';' +
            FtotalNota.ToString() + ';' +
            FtotalProdutos.ToString() + ';' +
            FchaveAcesso + ';' +
            FcodigoUsu.ToString() + ';' +
            FvalorFrete.ToString() + ';' +
            FvaloSeguro.ToString() + ';' +
            FoutrasDeps.ToString() + ';' +
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
            "codigoForn" + ';' +

            "data_emissao" + ';' +
            "data_chegada" + ';' +
            "total_nota" + ';' +
            "total_produtos" + ';' +
            "chave_acesso" + ';' +
            "codigoUsu" + ';' +
            "valor_frete" + ';' +
            "valor_seguro" + ';' +
            "out_desp" + ';' +
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
            return new string[] { "codigoForn = fornecedores.codigo",
                                  "codigoTransp = transportadoras.codigo",
                                  "codigoCondPag = condicoesPagamento.codigo"  };
        }
    }

    public class itensCompra
    {
        private string Fmodelo;
        private string Fserie;
        private string Fnumero_NF;
        private fornecedores FumForn;

        private string Funidade;
        private int Fquantidade;
        private decimal FprecoUn;
        private decimal Fdesconto;
        private produtos FumProduto;

        public itensCompra()
        {
            Fmodelo = "";
            Fserie = "";
            Fnumero_NF = "";
            FumForn = new fornecedores();

            Funidade = "";
            Fquantidade = 0;
            FprecoUn = 0;
            Fdesconto = 0;
            FumProduto = new produtos();
        }

        public itensCompra(string pModelo, string pSerie, string pNumNF, string pUnidade,
                           int pQuant, decimal pPrecoUn, decimal pDesconto)
        {
            Fmodelo = pModelo;
            Fserie = pSerie;
            Fnumero_NF = pNumNF;
            FumForn = new fornecedores();

            Funidade = pUnidade;
            Fquantidade = pQuant;
            FprecoUn = pPrecoUn;
            Fdesconto = pDesconto;
            FumProduto = new produtos();
        }
        public string PK
        { get => Fmodelo + ';' + Fserie + ';' + Fnumero_NF + ';' +
                 FumForn.Codigo.ToString() + ';' + FumProduto.Codigo.ToString(); }
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
        { get => FumProduto; set => FumProduto = value;  }
        public fornecedores UmFornecedor
        { get => FumForn; set => FumForn = value; }

        public itensCompra ThisItenCompra
        {
            get => Clone();
            set => SetObj(value);
        }

        protected void SetObj(object pObj)
        {
            var vlItem = (itensCompra)pObj;
            Fmodelo = vlItem.Modelo;
            Fserie = vlItem.Serie;
            Fnumero_NF = vlItem.NumeroNF;

            Funidade = vlItem.Unidade;
            Fquantidade = vlItem.Quantidade;
            FprecoUn = vlItem.PrecoUnidade;
            Fdesconto = vlItem.Desconto;

            FumProduto = vlItem.UmProduto.ThisProduto;
            FumForn = vlItem.UmFornecedor.ThisFornecedor;
        }

        private itensCompra Clone()
        {
            var vlObj = new itensCompra(Modelo, Serie, NumeroNF, Unidade, Quantidade,
                                        PrecoUnidade, Desconto);
            vlObj.UmFornecedor = UmFornecedor.ThisFornecedor;
            vlObj.UmProduto = UmProduto.ThisProduto;
            return vlObj;
        }

        public string toString()
        {
            return
            Fmodelo + ';' +
            Fserie + ';' +
            Fnumero_NF + ';' +
            FumForn.Codigo.ToString() + ';' +

            Funidade + ';' +
            Fquantidade.ToString() + ';' +
            FprecoUn.ToString() + ';' +
            Fdesconto.ToString() + ';' +
            FumProduto.Codigo.ToString();
            ;
        }

        public string toStringAttribute()
        {
            return
            "modelo" + ';' +
            "serie" + ';' +
            "numero_nf" + ';' +
            "codigoForn" + ';' +
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
            return new string[] { "codigoForn = fornecedores.codigo", "codigoProd = produtos.codigo"};
        }
    }
}
