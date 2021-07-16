using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class marcas : pai
    {
        private string Fmarca;

        public marcas()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fmarca = "";
        }
        public marcas(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt, string pMarca)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fmarca = pMarca;
        }

        public string Marca
        { get => Fmarca; set => Fmarca = value; }

        public marcas ThisMarca
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Marca = ((marcas)pObj).Marca;
        }

        private marcas Clone()
        {
            var clone = new marcas(Codigo, CodigoUsu, DataCad, DataUltAlt, Marca);
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Marca;
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "marca";
        }
    }
}
