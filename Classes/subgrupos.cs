using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class subgrupos : pai
    {
        private string Fsubgrupo;
        private grupos umGrupo;

        public subgrupos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fsubgrupo = "";
            umGrupo = new grupos();
        }
        public subgrupos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                         string pSubgrupo)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fsubgrupo = pSubgrupo;
            umGrupo = new grupos();
        }

        public string Subgrupo
        { get => Fsubgrupo; set => Fsubgrupo = value; }
        public grupos UmGrupo
        { get => umGrupo; set => umGrupo = value; }

        public subgrupos ThisSubgrupo
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Fsubgrupo = ((subgrupos)pObj).Subgrupo;
            umGrupo = ((subgrupos)pObj).UmGrupo.ThisGrupo;
        }
        private subgrupos Clone()
        {
            var clone = new subgrupos(Codigo, CodigoUsu, DataCad, DataUltAlt, Subgrupo);
            clone.UmGrupo = UmGrupo.ThisGrupo;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Subgrupo + ';' +
                   UmGrupo.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "subgrupo" + ';' +
                   "codigoGrupo";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoGrupo = grupos.codigo" };
        }
    }
}
