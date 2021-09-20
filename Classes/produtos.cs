using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class produtos : pai
    {
        private string Fproduto;
        private string Freferencia;
        private string FcodigoBarras;
        private decimal Fcusto;
        private int Funidade;
        private int Fsaldo;
        private decimal FpesoBruto;
        private decimal FpesoLiquido;
        private modelos umModelo;
        private subgrupos umSubgrupo;
        private List<fornecedores> listaForn;

        public produtos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fproduto = "";
            Freferencia = "";
            FcodigoBarras = "";
            Fcusto = 0;
            Funidade = 0;
            Fsaldo = 0;
            umModelo = new modelos();
            umSubgrupo = new subgrupos();
            listaForn = new List<fornecedores>();
        }
        public produtos(string pProduto, string pReferencia, string pCodBarras, decimal pCusto,
                        int pUnidade, int pSaldo)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fproduto = pProduto;
            Freferencia = pReferencia;
            FcodigoBarras = pCodBarras;
            Fcusto = pCusto;
            Funidade = pUnidade;
            Fsaldo = pSaldo;
            umModelo = new modelos();
            umSubgrupo = new subgrupos();
            listaForn = new List<fornecedores>();
        }
        public produtos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                        string pProduto, string pReferencia, string pCodBarras, decimal pCusto,
                        int pUnidade, int pSaldo)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fproduto = pProduto;
            Freferencia = pReferencia;
            FcodigoBarras = pCodBarras;
            Fcusto = pCusto;
            Funidade = pUnidade;
            Fsaldo = pSaldo;
            umModelo = new modelos();
            umSubgrupo = new subgrupos();
            listaForn = new List<fornecedores>();
        }

        public string Produto
        { get => Fproduto; set => Fproduto = value; }
        public string Referencia
        { get => Freferencia; set => Freferencia = value; }
        public string CodigoBarras
        { get => FcodigoBarras; set => FcodigoBarras = value; }
        public decimal Custo
        { get => Fcusto; set => Fcusto = value; }
        public decimal PesoLiquido
        { get => FpesoLiquido; set => FpesoLiquido = value; }
        public decimal PesoBruto
        { get => FpesoBruto; set => FpesoBruto = value; }
        public int Unidade
        { get => Funidade; set => Funidade = value; }
        public int Saldo
        { get => Fsaldo; set => Fsaldo = value; }
        public modelos UmModelo
        { get => umModelo; set => umModelo = value; }
        public subgrupos UmSubgrupo
        { get => umSubgrupo; set => umSubgrupo = value; }
        public List<fornecedores> ListaFornecedores
        { get => listaForn; set => listaForn = value; }

        public List<fornecedores> CloneListaForn()
        {
            var lista = new List<fornecedores>();
            foreach (fornecedores item in listaForn)
            {
                lista.Add(item.ThisFornecedor);
            }
            return lista;
        }

        public produtos ThisProduto
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Fproduto = ((produtos)pObj).Produto;
            Freferencia = ((produtos)pObj).Referencia;
            FcodigoBarras = ((produtos)pObj).CodigoBarras;
            Fcusto = ((produtos)pObj).Custo;
            Funidade = ((produtos)pObj).Unidade;
            Fsaldo = ((produtos)pObj).Saldo;
            umModelo = ((produtos)pObj).UmModelo.ThisModelo;
            umSubgrupo = ((produtos)pObj).UmSubgrupo.ThisSubgrupo;
            listaForn = ((produtos)pObj).ListaFornecedores;
        }
        private produtos Clone()
        {
            var clone = new produtos(Codigo, CodigoUsu, DataCad, DataUltAlt, Produto, Referencia,
                                     CodigoBarras, Custo, Unidade, Saldo);
            clone.UmModelo = umModelo.ThisModelo;
            clone.umSubgrupo = umSubgrupo.ThisSubgrupo;
            clone.ListaFornecedores = CloneListaForn();
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Produto + ';' +
                   Referencia + ';' +
                   CodigoBarras + ';' +
                   Custo.ToString() + ';' +
                   Unidade.ToString() + ';' +
                   Saldo.ToString() + ';' +
                   UmModelo.Codigo.ToString() + ';' +
                   UmSubgrupo.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "produto" + ';' +
                   "referencia" + ';' +
                   "codigoBarras" + ';' +
                   "custo" + ';' +
                   "unidade" + ';' +
                   "saldo" + ';' +
                   "codigoModelo" + ';' +
                   "codigoSubgrupo";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoModelo = modelos.codigo",
                                  "codigoSubgrupo = subgrupos.codigo"};
        }
    }
}
