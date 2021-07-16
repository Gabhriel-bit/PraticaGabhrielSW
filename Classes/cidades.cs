using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class cidades : pai
    {
        private string Fcidade;
        private string Fddd;
        private estados umEstado;
        public cidades()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fcidade = "";
            Fddd = "";
            umEstado = new estados();
        }
        public cidades(string pCidade, string pDDD)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fcidade = pCidade;
            Fddd = pDDD;
            umEstado = new estados();
        }
        public cidades(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                       string pCidade, string pDDD)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fcidade = pCidade;
            Fddd = pDDD;
            umEstado = new estados();
        }

        public string Cidade
        { get => Fcidade; set => Fcidade = value; }
        public string DDD
        { get => Fddd; set => Fddd = value; }
        public estados UmEstado
        { get => umEstado; set => umEstado = value; }

        public cidades ThisCidade
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Cidade = ((cidades)pObj).Cidade;
            DDD = ((cidades)pObj).DDD;
            UmEstado = ((cidades)pObj).UmEstado.ThisEstado;
        }

        private cidades Clone()
        {
            var clone = new cidades(Codigo, CodigoUsu, DataCad, DataUltAlt, Cidade, DDD);
            clone.UmEstado = umEstado.ThisEstado;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Cidade + ';' +
                   DDD + ';' +
                   UmEstado.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "cidade" + ';' +
                   "ddd" + ';' +
                   "codigoEstado";
        }
        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoEstado = estados.codigo" };
        }
    }
}
