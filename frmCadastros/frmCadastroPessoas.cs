using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroPessoas : Projeto_ICI.frmCadastros.frmCadastroPai
    {
        protected frmConsultas.frmConsultaCidades frmConsCidade;
        protected List<Classes.cidades> listaCidades;
        protected Classes.cidades umaCidade;
        public frmCadastroPessoas()
        {
            InitializeComponent();
            btn_PesquisarCidade.Image = umImgPesquisaSair;
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            var vlPessoa = (Classes.pessoas)pUmObjeto;
            txtb_Bairro.Text = vlPessoa.Bairro;
            txtb_CEP.Text = vlPessoa.CEP;
            txtb_CodigoCidade.Text = vlPessoa.UmaCidade.Codigo.ToString();
            txtb_Cidade.Text = vlPessoa.UmaCidade.Cidade;
            txtb_Complemento.Text = vlPessoa.Complemento;
            txtb_CPF_CNPJ.Text = vlPessoa.CNPJ_CPF;
            txtb_Email.Text = vlPessoa.Email;
            txtb_Logradouro.Text = vlPessoa.Logradouro;
            txtb_Numero.Text = vlPessoa.Numero;
            txtb_RG_InscEstadual.Text = vlPessoa.InscEst_RG;
            txtb_telCelular.Text = vlPessoa.Tel_celular;
            date_DataNasc_Fund.Text = vlPessoa.DataFund_Nasc;

        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Bairro.Enabled = false;
            txtb_CEP.Enabled = false;
            txtb_CodigoCidade.Enabled = false;
            txtb_Complemento.Enabled = false;
            txtb_CPF_CNPJ.Enabled = false;
            txtb_Email.Enabled = false;
            txtb_Logradouro.Enabled = false;
            txtb_Numero.Enabled = false;
            txtb_RG_InscEstadual.Enabled = false;
            txtb_telCelular.Enabled = false;
            date_DataNasc_Fund.Enabled = false;
            btn_PesquisarCidade.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            txtb_Bairro.Enabled = true;
            txtb_CEP.Enabled = true;
            txtb_CodigoCidade.Enabled = true;
            btn_PesquisarCidade.Enabled = true;
            txtb_Complemento.Enabled = true;
            txtb_CPF_CNPJ.Enabled = true;
            txtb_Email.Enabled = true;
            txtb_Logradouro.Enabled = true;
            txtb_Numero.Enabled = true;
            txtb_RG_InscEstadual.Enabled = true;
            date_DataNasc_Fund.Enabled = true;
            txtb_telCelular.Enabled = true;
        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Bairro.Clear();
            txtb_CEP.Clear();
            txtb_Cidade.Clear();
            txtb_CodigoCidade.Clear();
            txtb_Complemento.Clear();
            txtb_CPF_CNPJ.Clear();
            txtb_Email.Clear();
            txtb_Logradouro.Clear();
            txtb_Numero.Clear();
            txtb_RG_InscEstadual.Clear();
            txtb_telCelular.Clear();
        }

        private void btn_PesquisarCidade_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsCidade.Btn_Sair;
            frmConsCidade.Btn_Sair = "Selecionar";
            frmConsCidade.ConhecaOBJ(umaCidade);
            frmConsCidade.ShowDialog();
            frmConsCidade.Btn_Sair = nomeBtn;
            if (umaCidade.Codigo != 0)
            {
                txtb_CodigoCidade.Text = umaCidade.Codigo.ToString();
                txtb_Cidade.Text = umaCidade.Cidade;
            }
        }

        private void txtb_CodigoCidade_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoCidade.Text == "")
            {
                txtb_Cidade.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoCidade.Text, out int i))
                {
                    bool vlFind = false;
                    foreach (Classes.cidades vlCidade in listaCidades)
                    {
                        if (vlCidade.Codigo == i)
                        {
                            txtb_Cidade.Text = vlCidade.Cidade;
                            umaCidade = vlCidade.ThisCidade;
                            vlFind = true;
                        }
                    }
                    if (!vlFind)
                    { txtb_Cidade.Clear(); }
                }
            }
        }

        protected void date_DataNasc_Validating(object sender, CancelEventArgs e)
        {
            var idade = DateTime.Today.Year - date_DataNasc_Fund.Value.Year;
            if (idade < 16 || idade > 130)
            {
                errorMSG.SetError(lbl_DataNasc_Fund, "Data de nascimento inválida");
                e.Cancel = true;
            }
            else
            {
                errorMSG.SetError(lbl_DataNasc_Fund, null);
                e.Cancel = false;
            }
        }

        private void txtb_telCelular_Validating(object sender, CancelEventArgs e)
        {
            if (validacaoCelularTelefone())
            { e.Cancel = false; }
            else
            { e.Cancel = true; }
        }

        protected virtual bool validacaoCelularTelefone()
        {
            if (txtb_telCelular.Text.Length != 11)
            {
                errorMSG.SetError(lbl_telCelular, "Celular inválido!\nEntre com o DDD e os 9 dígitos");
                return false;
            }
            errorMSG.Clear();
            return true;
        }
        protected void date_Fund_Validating(object sender, CancelEventArgs e)
        {
            var idade = DateTime.Today.Year - date_DataNasc_Fund.Value.Year;
            if (idade < 0)
            {
                errorMSG.SetError(lbl_DataNasc_Fund, $"{lbl_DataNasc_Fund.Text} inválida");
                e.Cancel = true;
            }
            else
            {
                errorMSG.SetError(lbl_DataNasc_Fund, null);
                e.Cancel = false;
            }
        }
        private void txtb_CPF_CNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            formatCPF_CNPJ(e);
        }

        protected virtual void formatCPF_CNPJ(KeyPressEventArgs e)
        {
            string txt = txtb_CPF_CNPJ.Text;
            int len = txtb_CPF_CNPJ.TextLength;
            if (e.KeyChar != (char)Keys.Back)
            {
                switch (len)
                {
                    case 3:
                        txtb_CPF_CNPJ.Text = txt + ".";
                        txtb_CPF_CNPJ.Select(len + 1, 0);
                        break;
                    case 7:
                        txtb_CPF_CNPJ.Text = txt + ".";
                        txtb_CPF_CNPJ.Select(len + 1, 0);
                        break;
                    case 11:
                        txtb_CPF_CNPJ.Text = txt + "-";
                        txtb_CPF_CNPJ.Select(len + 1, 0);
                        break;
                }
            }
        }

        private void txtb_CPF_CNPJ_Validating(object sender, CancelEventArgs e)
        {
            validacaoCPF_CNPJ(sender, e);
        }

        protected virtual void validacaoCPF_CNPJ(object sender, CancelEventArgs e)
        {
            if (ValidacaoCPF(txtb_CPF_CNPJ.Text))
            {
                errorMSG.SetError(lbl_CPF_CNPJ, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_CPF_CNPJ, "CPF inválido!");
                e.Cancel = true;
            }
        }
        private void txtb_Logradouro_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Logradouro.Text))
            {
                errorMSG.SetError(lbl_Logradouro, "Logradouro inválido!");
                e.Cancel = true;
            }
            else
            {
                errorMSG.SetError(lbl_Logradouro, null);
                e.Cancel = false;
            }
        }

        private void txtb_Numero_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Numero.Text))
            {
                errorMSG.SetError(lbl_Numero, "Número inválido!");
                e.Cancel = true;
            }
            else
            {
                errorMSG.SetError(lbl_Numero, null);
                e.Cancel = false;
            }
        }
        private void txtb_Bairro_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Bairro.Text))
            {
                errorMSG.SetError(lbl_Bairro, "Bairro inválido!");
                e.Cancel = true;
            }
            else
            {
                errorMSG.SetError(lbl_Bairro, null);
                e.Cancel = false;
            }
        }

        private void txtb_CodigoCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoCidade, e);
        }

        private void txtb_CPF_CNPJ_Validated(object sender, EventArgs e)
        {
            var txt = txtb_CPF_CNPJ.Text;
            txt = txt.Replace(".", "");
            txt = txt.Replace("-", "");
            txt = txt.Replace("/", "");
            if (txt.Length == 11)
            { txtb_CPF_CNPJ.Text = FormatCPF(txt); }
            else
            { txtb_CPF_CNPJ.Text = FormatCNPJ(txt); }
        }

        private void txtb_Email_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoEmail(txtb_Email.Text))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_Email, "Email inválido!");
                e.Cancel = true;
            }
        }

        private void btn_PesquisarCidade_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarCidade.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarCidade_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarCidade.Image = umImgPesquisaSair;
        }
    }
}
