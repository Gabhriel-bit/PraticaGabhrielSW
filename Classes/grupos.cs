using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class grupos : pai
    {
        private string Fgrupo;

        public grupos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fgrupo = "";
        }
        public grupos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                      string pGrupo)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fgrupo = pGrupo;
        }

        public string Grupo
        { get => Fgrupo; set => Fgrupo = value; }

        public grupos ThisGrupo
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Grupo = ((grupos)pObj).Grupo;
        }
        private grupos Clone()
        {
            var clone = new grupos(Codigo, CodigoUsu, DataCad, DataUltAlt, Grupo);
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Grupo;
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "grupo";
        }
    }
}
