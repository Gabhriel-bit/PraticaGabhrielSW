using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class formasPagamento : pai
    {
        private string FformaPag;

        public formasPagamento()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            FformaPag = "";
        }
        public formasPagamento(int pCodigo, int pCodigoUsu, string pDataCad,
                               string pDataUltAlt, string pFormaPag)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            FformaPag = pFormaPag;
        }

        public string FormaPag
        { get => FformaPag; set => FformaPag = value; }

        public formasPagamento ThisFormPag
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            FormaPag = ((formasPagamento)pObj).FormaPag;
        }
        private formasPagamento Clone()
        {
            var clone = new formasPagamento(Codigo, CodigoUsu, DataCad, DataUltAlt, FormaPag);
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   FformaPag;
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "formaPagamento";
        }
    }
}
