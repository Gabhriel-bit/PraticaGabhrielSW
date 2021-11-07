using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroTransportadoras : Projeto_ICI.frmCadastros.frmCadastroPessoas
    {
        private Controllers.ctrlTransportadoras umCtrlTransport;
        public frmCadastroTransportadoras(Controllers.ctrlTransportadoras pCtrlTransport)
        {
            InitializeComponent();
            umCtrlTransport = pCtrlTransport;
            umCtrlCidade = pCtrlTransport.CTRLCidade;
            umaCidade = new Classes.cidades();
        }
        public override void SetFrmCons(Form pFrmCad)
        {
            frmConsCidade = (frmConsultas.frmConsultaCidades)pFrmCad;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Transportadora.Text = ((Classes.transportadoras)pUmObjeto).Transportadora;
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Transportadora.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            base.DesBloqTxTBox();
            txtb_Transportadora.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Transportadora.Clear();
            date_DataNasc_Fund.Value = DateTime.Today;
        }

        private void txtb_CPF_CNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatCPF_CNPJ(e);
        }
        protected override void formatCPF_CNPJ(KeyPressEventArgs e)
        {
            string txt = txtb_CPF_CNPJ.Text;
            int len = txtb_CPF_CNPJ.TextLength;
            if (e.KeyChar != (char)Keys.Back)
            {
                switch (len)
                {
                    case 2:
                        txtb_CPF_CNPJ.Text = txt + ".";
                        txtb_CPF_CNPJ.Select(len + 1, 0);
                        break;
                    case 6:
                        txtb_CPF_CNPJ.Text = txt + ".";
                        txtb_CPF_CNPJ.Select(len + 1, 0);
                        break;
                    case 10:
                        txtb_CPF_CNPJ.Text = txt + "/";
                        txtb_CPF_CNPJ.Select(len + 1, 0);
                        break;
                    case 15:
                        txtb_CPF_CNPJ.Text = txt + "-";
                        txtb_CPF_CNPJ.Select(len + 1, 0);
                        break;
                }
            }
        }

        private void txtb_CPF_CNPJ_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoCNPJ(txtb_CPF_CNPJ.Text))
            {
                errorMSG.SetError(lbl_CPF_CNPJ, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_CPF_CNPJ, "CNPJ inválido!");
                e.Cancel = closing;
            }
        }

        private void txtb_Transpotadora_Validating(object sender, CancelEventArgs e)
        {
            ValidarNome(txtb_Transportadora, lbl_Transportadora, "transportadora", umCtrlTransport, e);

        }
        protected override bool validacaoCelularTelefone()
        {
            if (txtb_telCelular.Text.Length != 10)
            {
                errorMSG.SetError(lbl_telCelular, "Telefone inválido!");
                return false;
            }
            else
            {
                errorMSG.SetError(lbl_telCelular, null);
                return closing;
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Transportadora.Text))
            {
                errorMSG.SetError(lbl_Transportadora, "Campo 'Transportadora' é obrigatório!");
                txtb_Transportadora.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Logradouro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Logradouro, "Campo 'Logradouro' é obrigatório!");
                txtb_Logradouro.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Numero.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Numero, "Campo 'Número' é obrigatório!");
                txtb_Numero.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Bairro.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Bairro, "Campo 'Bairro' é obrigatório!");
                txtb_Bairro.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Cidade.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Cidade, "Clique no botão 'Pesquisar' para adicionar uma cidade");
                btn_PesquisarCidade.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_telCelular.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_telCelular, $"Campo '{lbl_telCelular.Text}' é obrigatório!");
                txtb_telCelular.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_CPF_CNPJ.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CPF_CNPJ, $"Campo '{lbl_CPF_CNPJ.Text}' é obrigatório!");
                closing = true;
                txtb_CPF_CNPJ.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_RG_InscEstadual.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_RG_InscEstadual, $"Campo 'Incrição Estadual' é obrigatório!");
                txtb_RG_InscEstadual.Focus();
            }
            else if (date_DataNasc_Fund.Value > DateTime.Today)
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_DataNasc_Fund, $"Campo 'Data de nascimento' é obrigatório!");
                date_DataNasc_Fund.Focus();
            }
            else
            {
                errorMSG.Clear();
                var vlForn = new
                Classes.transportadoras(
                    txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                    txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                    txtb_DataCadastro.Text, txtb_DataUltAlt.Text,
                    txtb_Transportadora.Text, txtb_Logradouro.Text,
                    txtb_Numero.Text, txtb_Complemento.Text,
                    txtb_Bairro.Text, txtb_CEP.Text, txtb_telCelular.Text,
                    txtb_Email.Text, txtb_CPF_CNPJ.Text, txtb_RG_InscEstadual.Text,
                    date_DataNasc_Fund.Text);

                vlForn.UmaCidade.ThisCidade = umaCidade;
                ObjToDataBase(vlForn, umCtrlTransport);
            }
        }
    }
}
