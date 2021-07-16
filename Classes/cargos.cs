using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class cargos : pai
    {
        private bool Fcnh;
        private string Fcargo;
        private string Fdescricao;
        public cargos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fcnh = false;
            Fcargo = "";
            Fdescricao = "";
        }
        public cargos(bool pCNH, string pCargo, string pDescricao)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fcnh = pCNH;
            Fcargo = pCargo;
            Fdescricao = pDescricao;
        }
        public cargos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                      bool pCNH, string pCargo, string pDescricao)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fcnh = pCNH;
            Fcargo = pCargo;
            Fdescricao = pDescricao;
        }
        public bool CNH
        { get => Fcnh; set => Fcnh = value; }
        public string Cargo
        { get => Fcargo; set => Fcargo = value; }
        public string Descricao
        { get => Fdescricao; set => Fdescricao = value; }

        public cargos ThisCargo
        {
            get => new cargos(Codigo, CodigoUsu, DataCad, DataUltAlt, Fcnh, Fcargo, Fdescricao);
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            var vlUmCargo = (cargos)pObj;
            Fcnh = vlUmCargo.CNH;
            Fcargo = vlUmCargo.Cargo;
            Fdescricao = vlUmCargo.Descricao;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   CNH.ToString() + ';' +
                   Cargo + ';' +
                   Descricao;
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "cnh" + ';' +
                   "cargo" + ';' +
                   "descricao";
        }
    }
}
