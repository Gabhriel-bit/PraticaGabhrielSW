using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmCadastros
{
    public partial class frmCadastroFuncionarios : Projeto_ICI.frmCadastros.frmCadastroPessoas
    {
        frmConsultas.frmConsultaCargos frmConsCargo;
        Classes.cargos umCargo;

        Controllers.ctrlFuncionarios umCtrlFunc;

        public frmCadastroFuncionarios(Controllers.ctrlFuncionarios pCtrlFunc)
        {
            InitializeComponent();
            umCtrlFunc = pCtrlFunc;
            umCtrlCidade = pCtrlFunc.CTRLCidade;
            obrigatorioGrupoCNH(false);

            umaCidade = new Classes.cidades();
            umCargo = new Classes.cargos();
            btn_PesquisarCargo.Image = umImgPesquisaSair;
        }
        public override void SetFrmCons(Form[] pFrmCad)
        {
            frmConsCidade = (frmConsultas.frmConsultaCidades)pFrmCad[0];
            frmConsCargo = (frmConsultas.frmConsultaCargos)pFrmCad[1];
        }
        public override void CarregarTxtBox(object pUmObjeto)
        {
            base.CarregarTxtBox(pUmObjeto);
            var vlFunc = (Classes.funcionarios)pUmObjeto;
            txtb_Funcionario.Text = vlFunc.Funcionario;
            txtb_ComissaoProd.Text = vlFunc.ComissaoProduto.ToString();
            txtb_ComissaoVenda.Text = vlFunc.ComissaoVenda.ToString();
            txtb_SalarioBase.Text = vlFunc.SalarioBase.ToString();
            txtb_CodigoCargo.Text = vlFunc.UmCargo.Codigo.ToString();
            txtb_Cargo.Text = vlFunc.UmCargo.Cargo;
            obrigatorioGrupoCNH(vlFunc.UmCargo.CNH);
        }
        public override void BloquearTxtBox()
        {
            base.BloquearTxtBox();
            txtb_CodigoCargo.Enabled = false;
            txtb_Funcionario.Enabled = false;
            date_DataVenc.Enabled = false;
            txtb_ComissaoProd.Enabled = false;
            txtb_ComissaoVenda.Enabled = false;
            txtb_CNH.Enabled = false;
            txtb_SalarioBase.Enabled = false;
            btn_PesquisarCargo.Enabled = false;
        }
        public override void DesBloqTxTBox()
        {
            base.DesBloqTxTBox();
            txtb_CodigoCargo.Enabled = true;
            txtb_Funcionario.Enabled = true;
            txtb_ComissaoProd.Enabled = true;
            txtb_ComissaoVenda.Enabled = true;
            txtb_SalarioBase.Enabled = true;
            txtb_CNH.Enabled = true;
            date_DataVenc.Enabled = true;
            btn_PesquisarCargo.Enabled = true;

        }
        public override void ClearTxTBox()
        {
            base.ClearTxTBox();
            txtb_Funcionario.Clear();
            txtb_ComissaoProd.Clear();
            txtb_ComissaoVenda.Clear();
            txtb_SalarioBase.Clear();
            txtb_CNH.Clear();
            txtb_CodigoCargo.Clear();
            txtb_Cargo.Clear();
        }

        private void txtb_SalarioBase_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoDoubleMoeda(txtb_SalarioBase.Text))
            {
                errorMSG.SetError(lbl_SalarioBase, null);
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_SalarioBase, "Salário base inválido!");
                e.Cancel = closing;
            }
        }

        private void btn_Cadastro_Click(object sender, EventArgs e)
        {
            closing = true;
            if (string.IsNullOrEmpty(txtb_Funcionario.Text))
            {
                errorMSG.SetError(lbl_Funcionario, "Campo 'Funcionario' é obrigatório!");
                txtb_Funcionario.Focus();
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
                errorMSG.SetError(lbl_Cidade, "Clique no botão 'Pesquisar' ou digite uma codigo\n" +
                                              "para adicionar uma cidade");
                txtb_CodigoCidade.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_telCelular.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_telCelular, $"Campo '{lbl_telCelular.Text}' é obrigatório!");
                txtb_telCelular.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Email.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_telCelular, $"Campo 'Email' é obrigatório!");
                txtb_Email.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_CPF_CNPJ.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CPF_CNPJ, $"Campo '{lbl_CPF_CNPJ.Text}' é obrigatório!");
                txtb_CPF_CNPJ.Focus();
            }
            else if (date_DataNasc_Fund.Value.Year == DateTime.Today.Year)
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_CPF_CNPJ, $"Campo 'Data de nascimento' é obrigatório!");
                date_DataNasc_Fund.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_SalarioBase.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_SalarioBase, "Campo 'Salário base' é obrigatório!");
                txtb_SalarioBase.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_ComissaoProd.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_ComissaoProd, "Campo 'Comissão Produto' é obrigatório!");
                txtb_ComissaoProd.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_ComissaoVenda.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_ComissaoVenda, "Campo 'Comissão Venda' é obrigatório!");
                txtb_ComissaoVenda.Focus();
            }
            else if (string.IsNullOrEmpty(txtb_Cargo.Text))
            {
                errorMSG.Clear();
                errorMSG.SetError(lbl_Cidade, "Clique no botão 'Pesquisar' ou digite uma codigo\n" +
                                              "para adicionar um cargo");
                txtb_CodigoCidade.Focus();
            }
            else
            {
                errorMSG.Clear();
                var vlFunc = new
                Classes.funcionarios(
                    txtb_Codigo.Text == "" ? 0 : int.Parse(txtb_Codigo.Text),
                    txtb_CodigoUsu.Text == "" ? 0 : int.Parse(txtb_CodigoUsu.Text),
                    txtb_DataCadastro.Text, txtb_DataUltAlt.Text,
                    txtb_Funcionario.Text, txtb_Logradouro.Text,
                    txtb_Numero.Text, txtb_Complemento.Text,
                    txtb_Bairro.Text, txtb_CEP.Text, txtb_telCelular.Text,
                    txtb_Email.Text, txtb_CPF_CNPJ.Text, txtb_RG_InscEstadual.Text,
                    date_DataNasc_Fund.Text,
                    decimal.Parse(txtb_SalarioBase.Text.Replace('.', ','), vgEstilo, vgProv),
                    decimal.Parse((txtb_ComissaoVenda.Text == "") ? "0" :
                        txtb_ComissaoVenda.Text.Replace('.', ','), vgEstilo, vgProv),
                    decimal.Parse((txtb_ComissaoProd.Text == "") ? "0" :
                        txtb_ComissaoProd.Text.Replace('.', ','), vgEstilo, vgProv),
                    txtb_CNH.Text,
                    txtb_CNH.Text == "" ? "" : date_DataVenc.Text);

                vlFunc.UmaCidade.ThisCidade = umaCidade;
                vlFunc.UmCargo.ThisCargo = umCargo;
                ObjToDataBase(vlFunc, umCtrlFunc);
            }

        }

        private void btn_PesquisarCargo_Click(object sender, EventArgs e)
        {
            var nomeBtn = frmConsCargo.Btn_Sair;
            frmConsCargo.Btn_Sair = "Selecionar";
            frmConsCargo.ConhecaOBJ(umCargo);
            frmConsCargo.ShowDialog();
            frmConsCargo.Btn_Sair = nomeBtn;
            if (umCargo.Codigo != 0)
            {
                txtb_Cargo.Text = umCargo.Cargo;
                txtb_CodigoCargo.Text = umCargo.Codigo.ToString();
                obrigatorioGrupoCNH(umCargo.CNH);
            }
        }

        private void obrigatorioGrupoCNH(bool pObg)
        {
            if (pObg)
            {
                lbl_CNH.Text = lbl_CNH.Text.Replace(' ', '*');
                txtb_CNH.Validating += txtb_CNH_Validating;
            }
            else
            {
                lbl_CNH.Text = lbl_CNH.Text.Replace('*', ' ');
                txtb_CNH.Validating -= txtb_CNH_Validating;
            }

        }
        private void txtb_CNH_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_CNH.Text))
            {
                errorMSG.SetError(lbl_CNH, "O campo 'CNH' é obrigatório!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.SetError(lbl_CNH, null);
                e.Cancel = false;
            }
        }

        private void txtb_CodigoCargo_TextChanged(object sender, EventArgs e)
        {
            if (txtb_CodigoCargo.Text == "")
            {
                txtb_Cargo.Clear();
                obrigatorioGrupoCNH(false);
            }
            else
            {
                if (int.TryParse(txtb_CodigoCargo.Text, out int vlCodigo))
                {
                    var vlCargo =
                         (Classes.cargos)umCtrlFunc.CTRLCargo.Pesquisar("codigo",
                                                                         vlCodigo.ToString(),
                                                                         out string vlMsg,
                                                                         false);
                    if (vlCargo != null)
                    {
                        if (vlMsg == "")
                        {
                            txtb_Cargo.Text = vlCargo.Cargo;
                            umCargo.ThisCargo = vlCargo;
                        }
                        else
                        {
                            showErrorMsg(vlMsg);
                            txtb_Cargo.Clear();
                        }
                    }
                    else
                    {
                        txtb_Cargo.Clear();
                    }
                }
            }
        }

        private void txtb_Funcionario_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoNome(txtb_Funcionario.Text, 2, true))
            {
                if (umCtrlFunc.Pesquisar("funcionario", txtb_Funcionario.Text, true, out string vlMsg).Rows.Count != 0)
                {
                    if (vlMsg == "")
                    {
                        errorMSG.SetError(lbl_Funcionario, "Funcionário já cadastrado!");
                        e.Cancel = closing;
                    }
                    else
                    {
                        errorMSG.SetError(lbl_Funcionario, vlMsg);
                        e.Cancel = closing;
                    }
                }
                else
                {
                    errorMSG.SetError(lbl_Funcionario, null);
                    e.Cancel = false;
                }
            }
            else
            {
                errorMSG.SetError(lbl_Funcionario, "Funcionário inválido!");
                e.Cancel = closing;
            }
        }

        private void txtb_ComissaoProd_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoPorcentagem(txtb_ComissaoProd.Text))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_ComissaoProd, "Valor inválido!\nO campo é obrigatório, " +
                                                    "deve ser inserido um valor válido entre 0 e 100!");
                e.Cancel = closing;
            }
        }

        private void txtb_ComissaoVenda_Validating(object sender, CancelEventArgs e)
        {
            if (ValidacaoPorcentagem(txtb_ComissaoVenda.Text))
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
            else
            {
                errorMSG.SetError(lbl_ComissaoVenda, "Valor inválido!\nO campo é obrigatório, " +
                                                    "deve ser inserido um valor válido entre 0 e 100!");
                e.Cancel = closing;
            }
        }

        private void btn_PesquisarCargo_MouseEnter(object sender, EventArgs e)
        {
            btn_PesquisarCargo.Image = umImgPesquisaEntrar;
        }

        private void btn_PesquisarCargo_MouseLeave(object sender, EventArgs e)
        {
            btn_PesquisarCargo.Image = umImgPesquisaSair;
        }

        private void date_DataNasc_Fund_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Now.Year - date_DataNasc_Fund.Value.Year < 16)
            {
                errorMSG.SetError(lbl_DataNasc_Fund, "O funcionário não pode ter menos de 16 anos!");
                e.Cancel = closing;
            }
            else
            {
                errorMSG.Clear();
                e.Cancel = false;
            }
        }
    }
}
