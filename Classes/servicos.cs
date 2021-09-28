using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class servicos : pai
    {
        private string Fservico;
        private decimal Fpreco;
        private string Fdescricao;
        public servicos()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Servico = "";
            Descricao = "";
            Preco = 0;
        }

        public servicos(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                        string pServico, string pDescricao, decimal pPreco)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Servico = pServico;
            Descricao = pDescricao;
            Preco = pPreco;
        }

        public string Servico
        { get => Fservico; set => Fservico = value; }

        public string Descricao
        { get => Fdescricao; set => Fdescricao = value; }

        public decimal Preco
        { get => Fpreco; set => Fpreco = value; }

        public servicos ThisServico
        {
            get => new servicos(Codigo, CodigoUsu, DataCad, DataUltAlt, Servico, Descricao, Preco);
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            var vlUmPais = (servicos)pObj;
            Servico = vlUmPais.Servico;
            Descricao = vlUmPais.Descricao;
            Preco = vlUmPais.Preco;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Servico + ';' +
                   Descricao + ';' +
                   Preco;
        }
        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "servico" + ';' +
                   "descricao" + ';' +
                   "preco";
        }
    }
}
