using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class equipamentos : pai
    {
        private string Fequipamento;
        private string Fvoltagem;
        private string FobsTecnica;
        private modelos FumaModelo;
        public equipamentos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fequipamento = "";
            Fvoltagem = "";
            FobsTecnica = "";
            FumaModelo = new modelos();
        }
        public equipamentos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                            string pEquipamento, string pVolts, string pObsTecnica)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fequipamento = pEquipamento;
            Fvoltagem = pVolts;
            FobsTecnica = pObsTecnica;
            FumaModelo = new modelos();
        }

        public string Equipamento
        { get => Fequipamento; set => Fequipamento = value; }
        public string Voltagem
        { get => Fvoltagem; set => Fvoltagem = value; }
        public string ObsTecnica
        { get => FobsTecnica; set => FobsTecnica = value; }
        public modelos UmModelo
        { get => FumaModelo; set => FumaModelo = value; }

        public equipamentos ThisEquipemanto
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Equipamento = ((equipamentos)pObj).Equipamento;
            Voltagem = ((equipamentos)pObj).Voltagem;
            ObsTecnica = ((equipamentos)pObj).ObsTecnica;
            UmModelo = ((equipamentos)pObj).UmModelo.ThisModelo;
        }

        private equipamentos Clone()
        {
            var clone = new equipamentos(Codigo, CodigoUsu, DataCad, DataUltAlt,
                                         Equipamento, Voltagem, ObsTecnica);
            clone.UmModelo = UmModelo.ThisModelo;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Equipamento + ';' +
                   Voltagem + ';' +
                   ObsTecnica + ';' +
                   UmModelo.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "equipamento" + ';' +
                   "voltagem" + ';' +
                   "obsTecnica" + ';' +
                   "codigoModelo";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoModelo = modelos.codigo" };
        }
    }
}
