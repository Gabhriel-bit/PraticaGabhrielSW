using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroClientes : Projeto_ICI.frmCadastros.frmCadastroPessoas
    {
        private frmConsultas.frmConsultaCondicoesPagamento frmConsCondPag;
        Classes.condicoesPagamento umCondPag;

        Controllers.ctrlClientes umCtrlCliente;

        public frmCadastroClientes(Controllers.ctrlClientes pCtrlCliente)
        {
            InitializeComponent();
            umCtrlCliente = pCtrlCliente;
            umCtrlCidade = pCtrlCliente.CTRLCidade;

            umCondPag = new Classes.condicoesPagamento();
            umaCidade = new Classes.cidades();
            rb_Fisica.Checked = true;

            btn_PesquisarCondPag.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form[] pFrmCad)
        {
            frmConsCondPag = (frmConsultas.frmConsultaCondicoesPagamento)pFrmCad[0];
            frmConsCidade = (frmConsultas.frmConsultaCidades)pFrmCad[1];
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            txtb_Cliente.Text = ((Classes.clientes)pUmObjeto).Cliente;
            txtb_CodigoCondPag.Text = ((Classes.clientes)pUmObjeto).UmaCondPag.Codigo.ToString();
            txtb_CondicaoPag.Text = ((Classes.clientes)pUmObjeto).UmaCondPag.CondicaoPag;
            if (ValidacaoCPF(((Classes.clientes)pUmObjeto).CNPJ_CPF))
            { rb_Fisica.Checked = true; }
            else
            { rb_Juridica.Checked = true; }
        }

        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_Cliente.Enabled = false;
            txtb_CodigoCondPag.Enabled = false;
            txtb_CondicaoPag.Enabled = false;
            rb_Fisica.Enabled = false;
            rb_Juridica.Enabled = false;
            btn_PesquisarCondPag.Enabled = false;

        }

        public override void DesBloqTxTBox()
        {
            base.DesBloqTxTBox();
            txtb_Cliente.Enabled = true;
            txtb_CodigoCondPag.Enabled = true;
            txtb_CondicaoPag.Enabled = true;
            rb_Fisica.Enabled = true;
            rb_Juridica.Enabled = true;
            date_DataNasc_Fund.Enabled = true;
            btn_PesquisarCondPag.Enabled = true;
        }

        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Cliente.Clear();
            txtb_CodigoCondPag.Clear();
            txtb_CondicaoPag.Clear();
            date_DataNasc_Fund.Value = DateTime.Today;
        }
        private void rb_Fisica_CheckedChanged(object sender, EventArgs e)
        {
            lbl_telCelular.Text = "Celular*";
            lbl_RG_InscEstadual.Text = "RG";
            lbl_CPF_CNPJ.Text = "CPF*";
            lbl_DataNasc_Fund.Text = "Data nascimento";
            txtb_CPF_CNPJ.Clear();
            txtb_CPF_CNPJ.MaxLength = 14;
            date_DataNasc_Fund.Validating += date_DataNasc_Validating;
            errorMSG.Clear();
        }
        private void rb_Juridica_CheckedChanged(object sender, EventArgs e)
        {
            lbl_telCelular.Text = "Telefone*";
            lbl_RG_InscEstadual.Text = "Incrição Estadual*";
            lbl_DataNasc_Fund.Text = "Data fundação";
            lbl_CPF_CNPJ.Text = "CNPJ*";
            txtb_CPF_CNPJ.Clear();
            txtb_CPF_CNPJ.MaxLength = 18;
            date_DataNasc_Fund.Validating += date_Fund_Validating;
            errorMSG.Clear();
        }

        protected override void formatCPF_CNPJ(KeyPressEventArgs e)
        {
            string txt = txtb_CPF_CNPJ.Text;
            int len = txtb_CPF_CNPJ.TextLength;
            if (e.KeyChar != (char)Keys.Back)
            {
                //XXX. XXX. XXX- XX
                if (rb_Fisica.Checked == true)
                {
                    base.formatCPF_CNPJ(e);
                }
                else
                {
                    //XX. XXX. XXX/0001-XX
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
        }
        protected override void validacaoCPF_CNPJ(object sender, CancelEventArgs e)
        {
            errorMSG.Clear();
            if (rb_Fisica.Checked == true)
            {
                if (ValidacaoCPF(txtb_CPF_CNPJ.Text))
                {
                    errorMSG.Clear();
                    e.Cancel = false;
                }
                else
                {
                    errorMSG.SetError(lbl_CPF_CNPJ, "CPF inválido!");
                    e.Cancel = closing;
                }
            }
            else
            {
                if (ValidacaoCNPJ(txtb_CPF_CNPJ.Text))
                {
                    errorMSG.Clear();
                    e.Cancel = false;
                }
                else
                {
                    errorMSG.SetError(lbl_CPF_CNPJ, "CNPJ inválido!");
                    e.Cancel = closing;
                }
            }
        }

        private void txtb_Cliente_Validating(object sender, CancelEventArgs e)
        {
            ValidarNome(txtb_Cliente, lbl_Cliente, "cliente", umCtrlCliente, e);
        }

        protected override bool validacaoCelularTelefone()
        {
            if (lbl_telCelular.Text == "Celular*")
            {
                return base.validacaoCelularTelefone();
            }
            else
            {
                if (txtb_telCelular.Text.Length != 10)
                {
                    errorMSG.SetError(lbl_telCelular, "Telefone inválido!");
                    return false;
                }
                else
                {
                    errorMSG.SetError(lbl_telCelular, null);
                    return true;
                }
            }
        }
        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Cliente.Text))
            {
                errorMSG.SetError(lbl_Cliente, "Campo 'Funcionario' é obrigatório!");
                txtb_Cliente.Focus();
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
            else if (string.IsNullOrEmpty(txtb_CondicaoPag.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CondicaoPag, "Clique no botão 'Pesquisar' para adicionar uma condição pagamento");
                btn_PesquisarCondPag.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_CPF_CNPJ.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CPF_CNPJ, $"Campo '{lbl_CPF_CNPJ.Text}' é obrigatório!");
                closing = true;
                txtb_CPF_CNPJ.Focus();
            }
            else if (rb_Juridica.Checked == true && string.IsNullOrEmpty(txtb_RG_InscEstadual.Text))
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
                var vlCliente = new
                Classes.clientes(
                    txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                    txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                    txtb_DataCadastro.Text, txtb_DataUltAlt.Text,
                    txtb_Cliente.Text, txtb_Logradouro.Text,
                    txtb_Numero.Text, txtb_Complemento.Text,
                    txtb_Bairro.Text, txtb_CEP.Text, txtb_telCelular.Text,
                    txtb_Email.Text, txtb_CPF_CNPJ.Text, txtb_RG_InscEstadual.Text,
                    date_DataNasc_Fund.Text);

                vlCliente.UmaCidade.ThisCidade = umaCidade;
                vlCliente.UmaCondPag.ThisCondPag = umCondPag;
                ObjToDataBase(vlCliente, umCtrlCliente);
            }
        }

        private void btn_PesuisarCondPag_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsCondPag.Btn_Sair;
            frmConsCondPag.Btn_Sair = "Selecionar";
            frmConsCondPag.ConhecaOBJ(umCondPag);
            frmConsCondPag.ShowDialog();
            frmConsCondPag.Btn_Sair = nomeBtn;
            if (umCondPag.Codigo != 0)
            {
                txtb_CodigoCondPag.Text = umCondPag.Codigo.ToString();
                txtb_CondicaoPag.Text = umCondPag.CondicaoPag;
            }
        }

        private void txtb_CodigoCondPag_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoCondPag.Text == "")
            {
                txtb_CondicaoPag.Clear();
            }
            else
            {
                if (int.TryParse(txtb_CodigoCondPag.Text, out int vlCodigo))
                {
                    var vlCondPag =
                    (Classes.condicoesPagamento)umCtrlCliente.CTRLCondPag.Pesquisar("codigo",
                                                                            vlCodigo.ToString(),
                                                                            out string vlMsg,
                                                                            false);
                    if (vlCondPag != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_CondicaoPag.Text = vlCondPag.CondicaoPag;
                            umCondPag.ThisCondPag = vlCondPag;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_CondicaoPag.Clear();
                        }
                    }
                    else
                    {
                        txtb_CondicaoPag.Clear();
                    }
                }
            }
        }

        private void txtb_CodigoCondPag_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidacaoCodigo(txtb_CodigoCondPag, e);
        }

        private void btn_PesquisarCondPag_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarCondPag.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarCondPag_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarCondPag.Image = umImgPesquisaSair;
        }
    }
}
