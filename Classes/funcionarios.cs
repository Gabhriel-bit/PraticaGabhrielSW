using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ICI.Classes
{
    public class funcionarios : pessoas
    {
        private string Ffuncionario;
        private cargos umCargo;
        private decimal FsalarioBase;
        private decimal FcomissaoVenda;
        private decimal FcomissaoProduto;
        private string Fcnh;
        private string FdataVencCNH;

        public funcionarios()
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Logradouro = "";
            Numero = "";
            Complemento = "";
            Bairro = "";
            CEP = "";
            Tel_celular = "";
            Email = "";
            CNPJ_CPF = "";
            InscEst_RG = "";
            DataFund_Nasc = "";

            Ffuncionario = "";
            Fcnh = "";
            FsalarioBase = 0;
            FcomissaoVenda = 0;
            FcomissaoProduto = 0;
            FdataVencCNH = "";

            UmaCidade = new cidades();
            umCargo = new cargos();
        }
        public funcionarios(string pFuncionario, string pCNH, string pDataVencCnh,
                            decimal pSalarioBase, decimal pComissaoVenda, decimal ComissaoProd)
        {
            Codigo = 0;
            CodigoUsu = 0;
            DataCad = "";
            DataUltAlt = "";

            Logradouro = "";
            Numero = "";
            Complemento = "";
            Bairro = "";
            CEP = "";
            Tel_celular = "";
            Email = "";
            CNPJ_CPF = "";
            InscEst_RG = "";
            DataFund_Nasc = "";

            Ffuncionario = pFuncionario;
            Fcnh = pCNH;
            FsalarioBase = pSalarioBase;
            FcomissaoVenda = pComissaoVenda;
            FcomissaoProduto = ComissaoProd;
            FdataVencCNH = pDataVencCnh;

            UmaCidade = new cidades();
            umCargo = new cargos();
        }

        public funcionarios(int pCodigo, int pCodigoUsu, string pDataCad, string pDataUltAlt,
                            string pFuncionario, string pLograd, string pNumero, string pCpl,
                            string pBairro, string pCEP, string pTel_Celular, string pEmail,
                            string pCNPJ_CPF, string pInscEst_RG, string pDataFund_Nasc,
                            decimal pSalarioBase, decimal pComissaoVenda, decimal ComissaoProd,
                            string pCNH, string pDataVencCnh)
        {
            Codigo = pCodigo;
            CodigoUsu = pCodigoUsu;
            DataCad = pDataCad;
            DataUltAlt = pDataUltAlt;

            Logradouro = pLograd;
            Numero = pNumero;
            Complemento = pCpl;
            Bairro = pBairro;
            CEP = pCEP;
            Tel_celular = pTel_Celular;
            Email = pEmail;
            CNPJ_CPF = pCNPJ_CPF;
            InscEst_RG = pInscEst_RG;
            DataFund_Nasc = pDataFund_Nasc;

            Ffuncionario = pFuncionario;
            Fcnh = pCNH;
            FsalarioBase = pSalarioBase;
            FcomissaoVenda = pComissaoVenda;
            FcomissaoProduto = ComissaoProd;
            FdataVencCNH = pDataVencCnh;

            UmaCidade = new cidades();
            umCargo = new cargos();
        }

        public string Funcionario
        { get => Ffuncionario; set => Ffuncionario = value; }
        public cargos UmCargo
        { get => umCargo; set => umCargo = value; }
        public string CNH
        { get => Fcnh; set => Fcnh = value; }
        public string DataVencCNH
        { get => FdataVencCNH; set => FdataVencCNH = value; }
        public decimal ComissaoVenda
        { get => FcomissaoVenda; set => FcomissaoVenda = Math.Round(value, 4); }
        public decimal ComissaoProduto
        { get => FcomissaoProduto; set => FcomissaoProduto = Math.Round(value, 4); }
        public decimal SalarioBase
        { get => FsalarioBase; set => FsalarioBase = Math.Round(value, 4); }
        public funcionarios ThisFunc
        {
            get => Clone();
            set => SetObj(value);
        }

        protected override void SetObj(object pObj)
        {
            base.SetObj(pObj);
            Ffuncionario = ((funcionarios)pObj).Funcionario;
            Fcnh = ((funcionarios)pObj).CNH;
            FsalarioBase = ((funcionarios)pObj).SalarioBase;
            FcomissaoProduto = ((funcionarios)pObj).ComissaoProduto;
            FcomissaoVenda = ((funcionarios)pObj).ComissaoVenda;
            FdataVencCNH = ((funcionarios)pObj).DataVencCNH;
            UmCargo = ((funcionarios)pObj).UmCargo.ThisCargo;
        }
        private funcionarios Clone()
        {
            var clone = new funcionarios(Codigo, CodigoUsu, DataCad, DataUltAlt, Funcionario,
                                         Logradouro, Numero, Complemento, Bairro, CEP, Tel_celular,
                                         Email, CNPJ_CPF, InscEst_RG, DataFund_Nasc, SalarioBase,
                                         ComissaoVenda, ComissaoProduto, CNH, DataVencCNH);
            clone.UmaCidade = UmaCidade.ThisCidade;
            clone.UmCargo = UmCargo.ThisCargo;
            return clone;
        }

        public override string toString()
        {
            return base.toString() + ';' +
                   Funcionario + ';' +
                   CNH + ';' +
                   SalarioBase.ToString() + ';' +
                   ComissaoVenda.ToString() + ';' +
                   ComissaoProduto.ToString() + ';' +
                   DataVencCNH + ';' +
                   UmCargo.Codigo.ToString();
        }

        public override string toStringAttribute()
        {
            return base.toStringAttribute() + ';' +
                   "funcionario" + ';' +
                   "cnh" + ';' +
                   "salarioBase" + ';' +
                   "comissaoVenda" + ';' +
                   "comissaoProduto" + ';' +
                   "dataVencCNH" + ';' +
                   "codigoCargo";
        }

        public override string[] toStringSearchPesquisa()
        {
            return new string[] { base.toStringSearchPesquisa()[0],
                                  "codigoCargo = cargos.codigo" };
        }
    }
}
