using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class estados : pai
    {
        private string Festado;
        private string Fuf;
        private paises umPais;
        public estados()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Festado = "";
            Fuf = "";
            umPais = new paises();
        }
        public estados(string pEstado, string pUF)
        {
            Codigo = 0;
            DataCad = "";
            CodigoUsu = 0;
            DataUltAlt = "";

            Festado = pEstado;
            Fuf = pUF;
            umPais = new paises();
        }
        public estados(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                       string pEstado, string pUF)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Festado = pEstado;
            Fuf = pUF;
            umPais = new paises();
        }

        public string Estado
        { get => Festado; set => Festado = value; }
        public string UF
        { get => Fuf; set => Fuf = value; }
        public paises UmPais
        { get => umPais; set => umPais = value; }

        public estados ThisEstado
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Estado = ((estados)pObj).Estado;
            UF = ((estados)pObj).UF;
            UmPais = ((estados)pObj).UmPais.ThisPais;
        }

        private estados Clone()
        {
            var clone = new estados(Codigo, CodigoUsu, DataCad, DataUltAlt, Estado, UF);
            clone.UmPais = UmPais.ThisPais;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Estado + ';' +
                   UF + ';' +
                   UmPais.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "estado" + ';' +
                   "uf" + ';' +
                   "codigoPais";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoPais = paises.codigo" };
        }
    }
}
