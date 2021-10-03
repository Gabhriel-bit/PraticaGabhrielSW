using Projeto_ICI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaFuncionarios : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroFuncionarios frmCadFunc;
        Controllers.ctrlFuncionarios umCtrlFunc;
        List<Classes.cargos> listaCargos;
        List<Classes.cidades> listaCidades;
        Classes.funcionarios umFunc;

        public frmConsultaFuncionarios(Controllers.ctrlFuncionarios pCtrlFunc)
        {
            InitializeComponent();
            umCtrlFunc = pCtrlFunc;
            umFunc = new Classes.funcionarios();
            carregarDados(umCtrlFunc);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadFunc = (frmCadastros.frmCadastroFuncionarios)pFrmCad;
        }
        protected override void carregarDados(ctrl pCTRL)
        {
            base.carregarDados(pCTRL);
            listaCargos = umCtrlFunc.CTRLCargo.PesquisarCollection(out string vlMsgCargo);
            listaCidades = umCtrlFunc.CTRLCidade.PesquisarCollection(out string vlMsgCidade);
            showErrorMsg(new string[] { vlMsgCargo, vlMsgCidade });
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umFunc = (Classes.funcionarios)pOBJ;
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadFunc.ClearTxTBox();
            frmCadFunc.ShowDialog();
            carregarDados(umCtrlFunc);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlFunc = (Classes.funcionarios)dataGridToObj(umCtrlFunc, out string vlMsg);
            if (vlFunc == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um funcionário");
                this.dataGridView.Focus();
            }
            else if (vlMsg != "")
            {
                errorMSG.SetError(btn_Alterar, "Erro ao carregar!\n" + vlMsg);
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadFunc.ClearTxTBox();
                var btnName = frmCadFunc.Btn_Acao;
                frmCadFunc.Btn_Acao = "Alterar";
                frmCadFunc.CarregarTxtBox(vlFunc);
                frmCadFunc.ShowDialog();
                frmCadFunc.Btn_Acao = btnName;
                carregarDados(umCtrlFunc);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlFunc = (Classes.funcionarios)dataGridToObj(umCtrlFunc, out string vlMsg);
            if (vlFunc == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um funcionário");
                this.dataGridView.Focus();
            }
            else if (vlMsg != "")
            {
                errorMSG.SetError(btn_Alterar, "Erro ao carregar!\n" + vlMsg);
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadFunc.ClearTxTBox();
                var btnName = frmCadFunc.Btn_Acao;
                frmCadFunc.BloquearTxtBox();
                frmCadFunc.CarregarTxtBox(vlFunc);
                frmCadFunc.Btn_Acao = "Excluir";
                frmCadFunc.ShowDialog();
                frmCadFunc.Btn_Acao = btnName;
                carregarDados(umCtrlFunc);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlFunc = (Classes.funcionarios)dataGridToObj(umCtrlFunc, out string vlMsg);
                if (vlFunc == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um funcionário!");
                    this.dataGridView.Focus();
                }
                else if (vlMsg != "")
                {
                    errorMSG.SetError(btn_Alterar, "Erro ao carregar!\n" + vlMsg);
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umFunc.ThisFunc = vlFunc;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("", "", default, out vlMsg);
            }
            else if (ValidacaoCPF(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("cpf", FormatCPF(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoCNPJ(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("cnpj", FormatCNPJ(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFunc.Pesquisar("funcionario", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaFuncionarios_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlFunc);
        }
    }
}
