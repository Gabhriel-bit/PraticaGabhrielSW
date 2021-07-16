using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class paises : pai
    {
        private string Fpais;
        private string Fmoeda;
        private string Fddi;
        private string Fsigla;
        public paises()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fpais = "";
            Fmoeda = "";
            Fddi = "";
            Fsigla = "";
        }
        public paises(string pPais, string pMoeda, string pDDI, string pSigla)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fpais = pPais;
            Fmoeda = pMoeda;
            Fddi = pDDI;
            Fsigla = pSigla;
        }
        public paises(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                      string pPais, string pMoeda, string pDDI, string pSigla)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fpais = pPais;
            Fmoeda = pMoeda;
            Fddi = pDDI;
            Fsigla = pSigla;
        }

        public string Pais
        { get => Fpais; set => Fpais = value; }

        public string Moeda
        { get => Fmoeda; set => Fmoeda = value; }

        public string DDI
        { get => Fddi; set => Fddi = value; }

        public string Sigla
        { get => Fsigla; set => Fsigla = value; }

        public paises ThisPais
        {
            get => new paises(Codigo, CodigoUsu, DataCad, DataUltAlt, Pais, Moeda, DDI, Sigla);
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            var vlUmPais = (paises)pObj;
            Pais = vlUmPais.Pais;
            Moeda = vlUmPais.Moeda;
            Sigla = vlUmPais.Sigla;
            DDI = vlUmPais.DDI;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Pais + ';' +
                   Moeda + ';' +
                   DDI + ';' +
                   Sigla;
        }
        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "pais" + ';' +
                   "moeda" + ';' +
                   "ddi" + ';' +
                   "sigla";
        }
    }
}
