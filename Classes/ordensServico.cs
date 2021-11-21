using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class ordensServico : pai
    {
        private string FnumeroSerie;
        private string Fgarantia;
        private clientes FumCliente;
        private condicoesPagamento FumaCondPag;
        private equipamentos FumEquipamento;
        private List<itensOSServico> FumaListaItensServico;
        private List<itensOSProdutos> FumaListaItensProduto;
        private List<contasReceber> FumListaContasReceber;

        public ordensServico()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            FnumeroSerie = "";
            Fgarantia = "";
            FumCliente = new clientes();
            FumaCondPag = new condicoesPagamento();
            FumEquipamento = new equipamentos();

            FumaListaItensServico = new List<itensOSServico>();
            FumaListaItensProduto = new List<itensOSProdutos>();
            FumListaContasReceber = new List<contasReceber>();
        }

        public ordensServico(int pCodigo, int pCodigoUsu, string pDataEntrada,
                             string pDataSaida, string pNumSerie, string pGarantia)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = pDataEntrada;
            DataUltAlt = pDataSaida;

            FnumeroSerie = pNumSerie;
            Fgarantia = pGarantia;
            FumCliente = new clientes();
            FumaCondPag = new condicoesPagamento();
            FumEquipamento = new equipamentos();

            FumaListaItensServico = new List<itensOSServico>();
            FumaListaItensProduto = new List<itensOSProdutos>();
            FumListaContasReceber = new List<contasReceber>();
        }

        public string contasReceberPKStr
        { get => "modelo;serie;num_nf;codigoCliente"; }
        public string contasReceberPK
        { get => $"OS-{Codigo};OS-{Codigo};{Codigo};{UmCliente.Codigo}"; }
        public string DataEntrada
        { get => DataCad; set => DataCad = value; }
        public string DataRealizacao
        { get => DataUltAlt; set => DataUltAlt = value; }
        public string NumeroSerie
        { get => FnumeroSerie; set => FnumeroSerie = value; }
        public string Garantia
        { get => Fgarantia; set => Fgarantia = value; }
        public clientes UmCliente
        { get => FumCliente; set => FumCliente = value; }
        public condicoesPagamento UmaCondPag
        { get => FumaCondPag; set => FumaCondPag = value; }
        public equipamentos UmEquipamento
        { get => FumEquipamento; set => FumEquipamento = value; }
        public List<itensOSProdutos> UmaListaItensProduto
        { get => FumaListaItensProduto; set => FumaListaItensProduto = value; }
        public List<itensOSServico> UmaListaItensServico
        { get => FumaListaItensServico; set => FumaListaItensServico = value; }
        public List<contasReceber> UmaListaContasReceber
        { get => CloneListaContas(); set => FumListaContasReceber = value; }

        public void setCodigoListasOS()
        {
            foreach (itensOSServico vlItem in UmaListaItensServico)
                vlItem.CodigoOS = Codigo;
            foreach (itensOSProdutos vlItem in UmaListaItensProduto)
                vlItem.CodigoOS = Codigo;
            foreach (contasReceber vlItem in UmaListaContasReceber)
            {
                vlItem.Modelo           = $"OS-{Codigo}";
                vlItem.Serie            = $"OS-{Codigo}";
                vlItem.NumeroNF         = Codigo.ToString();
                vlItem.UmCliente.Codigo = Codigo;
            }
        }

        private List<contasReceber> CloneListaContas()
        {
            var lista = new List<contasReceber>();
            foreach (contasReceber item in FumListaContasReceber)
            {
                lista.Add(item.ThisContaReceber);
            }
            return lista;
        }
        public List<itensOSProdutos> CloneListaProdutos()
        {
            var lista = new List<itensOSProdutos>();
            UmaListaItensProduto = (UmaListaItensProduto == null ? lista : UmaListaItensProduto);
            foreach (itensOSProdutos item in UmaListaItensProduto)
            {
                lista.Add(item.ThisItemOSProduto);
            }
            return lista;
        }

        public List<itensOSServico> CloneListaServicos()
        {
            var lista = new List<itensOSServico>();
            UmaListaItensServico = (UmaListaItensServico == null ? lista : UmaListaItensServico);
            foreach (itensOSServico item in UmaListaItensServico)
            {
                lista.Add(item.ThisItemOSServico);
            }
            return lista;
        }

        public ordensServico ThisProduto
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            var vlOS = (ordensServico)pObj;
            FnumeroSerie = vlOS.NumeroSerie;
            Fgarantia = vlOS.Garantia;
            FumCliente = vlOS.UmCliente.ThisCliente;
            FumaCondPag = vlOS.UmaCondPag.ThisCondPag;
            FumEquipamento = vlOS.UmEquipamento.ThisEquipemanto;

            FumaListaItensServico = vlOS.CloneListaServicos();
            FumaListaItensProduto = vlOS.CloneListaProdutos();
        }
        private ordensServico Clone()
        {
            var clone = new ordensServico(Codigo, CodigoUsu, DataCad, DataUltAlt, NumeroSerie, Garantia);
            clone.UmCliente = UmCliente.ThisCliente;
            clone.UmaCondPag = UmaCondPag.ThisCondPag;
            clone.UmEquipamento = UmEquipamento.ThisEquipemanto;
            clone.UmaListaItensServico = CloneListaServicos();
            clone.UmaListaItensProduto = CloneListaProdutos();
            return clone;
        }

        public override string toString()
        {
            return Codigo.ToString() + ';' +
                   CodigoUsu.ToString() + ';' +
                   DataEntrada + ';' +
                   DataRealizacao + ';' +
                   NumeroSerie + ';' +
                   Garantia + ';' +
                   UmCliente.Codigo.ToString() + ';' +
                   UmaCondPag.Codigo.ToString() + ';' +
                   UmEquipamento.Codigo.ToString();

        }

        public override string toStringAttribute()
        {
            return "codigo" +
                   ";codigoUsu" +
                   ";dataEntrega" +
                   ";dataRealizacao" +
                   ";numeroSerie" +
                   ";garantia" +
                   ";codigoCliente" +
                   ";codigoCondPag" +
                   "codigoEquipamento";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "ordens_servico.codigoCliente = cliente.codigo",
                                  "ordens_servico.codigoCondPag = condicaoPagamento.codigo" +
                                  "ordens_servico.codigoEquipamento = equipamento.codigo" };
        }

    }

    public class itensOSServico
    {
        private int FcodigoOS;
        private int Fquantidade;
        private funcionarios FumFuncionario;
        private servicos FumServico;

        public itensOSServico()
        {
            FcodigoOS = 0;
            Fquantidade = 0;
            FumFuncionario = new funcionarios();
            FumServico = new servicos();
        }
        public itensOSServico(int pCodigoCondPag, int pQuantidade)
        {
            FcodigoOS = pCodigoCondPag;
            Fquantidade = pQuantidade;
            FumFuncionario = new funcionarios();
            FumServico = new servicos();
        }

        public int CodigoOS
        { get => FcodigoOS; set => FcodigoOS = value; }
        public int Quantidade
        { get => Fquantidade; set => Fquantidade = value; }
        public funcionarios UmFuncionario
        { get => FumFuncionario; set => FumFuncionario = value; }
        public Classes.servicos UmServico
        { get => FumServico; set => FumServico = value; }

        public itensOSServico ThisItemOSServico
        {
            get => Clone();
            set => SetObj(value);
        }

        protected void SetObj(object pObj)
        {
            CodigoOS = ((itensOSServico)pObj).CodigoOS;
            Quantidade = ((itensOSServico)pObj).Quantidade;
            UmFuncionario = ((itensOSServico)pObj).UmFuncionario.ThisFunc;
            UmServico = ((itensOSServico)pObj).UmServico.ThisServico;
        }

        private itensOSServico Clone()
        {
            var vlObj = new itensOSServico(CodigoOS, Quantidade);
            vlObj.UmFuncionario = UmFuncionario.ThisFunc;
            return vlObj;
        }

        public string[] arrayStringValores()
        {
            return toString().Split(';');
        }

        public string[] arrayStringCampos()
        {
            return toStringAttribute().Split(';');
        }
        public string toString()
        {
            return CodigoOS.ToString() + ';' +
                   Quantidade.ToString() + ';' +
                   FumFuncionario.Codigo.ToString() + ';' +
                   UmServico.Codigo.ToString();
        }
        public string toStringAttribute()
        {
            return "codigoOS" + ';' +
                   "quantidade" + ';' +
                   "codigoFuncionario" + ';' +
                   "codigoServico";
        }
    }

    public class itensOSProdutos
    {
        private int FcodigoOS;
        private int Fquantidade;
        private decimal Fdesconto;
        private produtos FumProduto;

        public itensOSProdutos()
        {
            FcodigoOS = 0;
            Fquantidade = 0;
            Fdesconto = 0;
            FumProduto = new produtos();
        }
        public itensOSProdutos(int pCodigoCondPag, int pQuantidade, decimal pDesconto)
        {
            FcodigoOS = pCodigoCondPag;
            Fquantidade = pQuantidade;
            Fdesconto = pDesconto;
            FumProduto = new produtos();
        }

        public int CodigoOS
        { get => FcodigoOS; set => FcodigoOS = value; }
        public int Quantidade
        { get => Fquantidade; set => Fquantidade = value; }
        public decimal Desconto
        { get => Fdesconto; set => Fdesconto = value; }
        public Classes.produtos UmProduto
        { get => FumProduto; set => FumProduto = value; }

        public itensOSProdutos ThisItemOSProduto
        {
            get => Clone();
            set => SetObj(value);
        }

        protected void SetObj(object pObj)
        {
            CodigoOS = ((itensOSProdutos)pObj).CodigoOS;
            Quantidade = ((itensOSProdutos)pObj).Quantidade;
            FumProduto = ((itensOSProdutos)pObj).UmProduto.ThisProduto;
            Desconto = ((itensOSProdutos)pObj).Desconto;
        }

        private itensOSProdutos Clone()
        {
            var vlObj = new itensOSProdutos(CodigoOS, Quantidade, Desconto);
            vlObj.UmProduto = UmProduto.ThisProduto;
            return vlObj;
        }

        public string[] arrayStringValores()
        {
            return toString().Split(';');
        }

        public string[] arrayStringCampos()
        {
            return toStringAttribute().Split(';');
        }
        public string toString()
        {
            return CodigoOS.ToString() + ';' +
                   Quantidade.ToString() + ';' +
                   Desconto.ToString() + ';' +
                   UmProduto.Codigo.ToString();
        }
        public string toStringAttribute()
        {
            return "codigoOS" + ';' +
                   "quantidade" + ';' +
                   "desconto" + ';' +
                   "codigoProduto";
        }
    }
}
