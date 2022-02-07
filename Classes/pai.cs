using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class pai
    {
        private int Fcodigo;
        private int FCodigoUsu;
        private string FdataCad;
        private string FultAlt;
        public pai()
        {
            Fcodigo = 0;
            FCodigoUsu = 0;
            FdataCad = "";
            FultAlt = "";
        }
        public pai(int pCodigo, int pCodigoUsu, string pDataCad, string pUltAlt)
        {
            Fcodigo = pCodigo;
            FCodigoUsu = pCodigoUsu;
            FdataCad = pDataCad;
            FultAlt = pUltAlt;
        }
        public int Codigo
        {
            set => Fcodigo = value;
            get => Fcodigo;
        }
        public string DataCad
        {
            set => FdataCad = value;
            get => FdataCad;
        }
        public string DataUltAlt
        {
            set => FultAlt = value;
            get => FultAlt;
        }
        public int CodigoUsu
        {
            set => FCodigoUsu = value;
            get => FCodigoUsu;
        }

        protected virtual void SetObj(object pObj)
        {
            var obj = (pai)pObj;
            Codigo = obj.Codigo;
            CodigoUsu = obj.CodigoUsu;
            DataCad = obj.DataCad;
            DataUltAlt = obj.DataUltAlt;
        }

        /// <summary>
        /// Retorna um vetor de strings referente a cada atributo da classe
        /// </summary>
        public string[] arrayStringValores()
        {
            return toString().Split(';');
        }

        public string[] arrayStringCampos()
        {
            return toStringAttribute().Split(';');
        }
        /// <summary>
        /// Retorna uma string referente a cada atributo da classe com o separador ';'
        /// </summary>
        public virtual string toString()
        {
            return Codigo.ToString() + ';' +
                   CodigoUsu.ToString() + ';' +
                   DataCad + ';' +
                   DataUltAlt;
        }

        public virtual string toStringAttribute()
        {
            return "codigo" + ';' +
                   "codigoUsu" + ';' +
                   "dataCad" + ';' +
                   "dataUltAlt";
        }

        public virtual string[] toStringSearchPesquisa()
        {
            return new string[] { };
        }
    }
}
