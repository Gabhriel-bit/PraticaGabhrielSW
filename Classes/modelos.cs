using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class modelos : pai
    {
        private string Fmodelo;
        private string Fdescricao;
        private marcas umaMarca;

        public modelos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Fmodelo = "";
            Fdescricao = "";
            umaMarca = new marcas();
        }
        public modelos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                       string pModelo, string pDescricao)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Fmodelo = pModelo;
            Fdescricao = pDescricao;
            umaMarca = new marcas();
        }

        public string Modelo
        { get => Fmodelo; set => Fmodelo = value; }
        public string Descricao
        { get => Fdescricao; set => Fdescricao = value; }
        public marcas UmaMarca
        { get => umaMarca; set => umaMarca = value; }

        public modelos ThisModelo
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Modelo = ((modelos)pObj).Modelo;
            Descricao = ((modelos)pObj).Descricao;
            UmaMarca = ((modelos)pObj).UmaMarca.ThisMarca;
        }
        private modelos Clone()
        {
            var clone = new modelos(Codigo, CodigoUsu, DataCad, DataUltAlt,
                                    Modelo, Descricao);
            clone.UmaMarca = umaMarca.ThisMarca;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Modelo + ';' +
                   Descricao + ';' +
                   UmaMarca.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "modelo" + ';' +
                   "descricao" + ';' +
                   "codigoMarca";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { "codigoMarca = marcas.codigo" };
        }
    }
}
