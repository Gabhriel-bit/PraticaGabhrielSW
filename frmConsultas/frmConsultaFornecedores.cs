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
    public partial class frmConsultaFornecedores : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroFornecedores frmCadForn;
        Controllers.ctrlFornecedores umCtrlForn;
        List<Classes.condicoesPagamento> listaCondPag;
        List<Classes.cidades> listaCidades;
        Classes.fornecedores umForn;

        public frmConsultaFornecedores(Controllers.ctrlFornecedores pCtrlForn)
        {
            InitializeComponent();
            umCtrlForn = pCtrlForn;
            umForn = new Classes.fornecedores();
            carregarDados(umCtrlForn);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadForn = (frmCadastros.frmCadastroFornecedores)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umForn = (Classes.fornecedores)pOBJ;
        }
        protected override void carregarDados(ctrl pCTRL)
        {
            base.carregarDados(pCTRL);
            listaCondPag = umCtrlForn.CTRLCondPag.PesquisarCollection(out string vlMsgConPag);
            listaCidades = umCtrlForn.CTRLCidade.PesquisarCollection(out string vlMsgForn);
            showErrorMsg(new string[] { vlMsgForn, vlMsgConPag });
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadForn.ClearTxTBox();
            frmCadForn.ShowDialog();
            carregarDados(umCtrlForn);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlForn = (Classes.fornecedores)dataGridToObj(umCtrlForn, out string vlMsg);
            if (vlForn == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um fornecedor");
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
                frmCadForn.ClearTxTBox();
                var btnName = frmCadForn.Btn_Acao;
                frmCadForn.Btn_Acao = "Alterar";
                frmCadForn.CarregarTxtBox(vlForn);
                frmCadForn.ShowDialog();
                frmCadForn.Btn_Acao = btnName;
                carregarDados(umCtrlForn);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlForn = (Classes.fornecedores)dataGridToObj(umCtrlForn, out string vlMsg);
            if (vlForn == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um fornecedor");
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
                frmCadForn.ClearTxTBox();
                var btnName = frmCadForn.Btn_Acao;
                frmCadForn.BloquearTxtBox();
                frmCadForn.CarregarTxtBox(vlForn);
                frmCadForn.Btn_Acao = "Excluir";
                frmCadForn.ShowDialog();
                frmCadForn.Btn_Acao = btnName;
                carregarDados(umCtrlForn);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlForn = (Classes.fornecedores)dataGridToObj(umCtrlForn, out string vlMsg);
                if (vlForn == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um cliente!");
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
                    umForn.ThisFornecedor = vlForn;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("", "", default, out vlMsg);
            }
            else if (ValidacaoCPF(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("cpf", FormatCPF(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoCNPJ(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("cnpj", FormatCNPJ(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("fornecedor", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaFornecedores_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlForn);
        }
    }
}
