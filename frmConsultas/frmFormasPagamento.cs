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
    public partial class frmConsultasFormasPagamento : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroFormasPagamento frmCadFormPag;
        Controllers.ctrlFormasPagamento umCtrlFormPag;
        Classes.formasPagamento umaFormaPag;

        public frmConsultasFormasPagamento(Controllers.ctrlFormasPagamento pCtrlFormPag)
        {
            InitializeComponent();
            umCtrlFormPag = pCtrlFormPag;
            umaFormaPag = new Classes.formasPagamento();
            carregarDados(umCtrlFormPag);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadFormPag = (frmCadastros.frmCadastroFormasPagamento)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umaFormaPag = (Classes.formasPagamento)pOBJ;
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadFormPag.ClearTxTBox();
            frmCadFormPag.ShowDialog();
            carregarDados(umCtrlFormPag);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {

        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlFormPag = (Classes.formasPagamento)dataGridToObj(umCtrlFormPag, out string vlMsg);
            if (vlFormPag == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione uma e apenas uma forma de pagamento");
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
                frmCadFormPag.ClearTxTBox();
                frmCadFormPag.BloquearTxtBox();
                var btnName = frmCadFormPag.Btn_Acao;
                frmCadFormPag.CarregarTxtBox(vlFormPag);
                frmCadFormPag.Btn_Acao = "Excluir";
                frmCadFormPag.ShowDialog();
                frmCadFormPag.Btn_Acao = btnName;
                carregarDados(umCtrlFormPag);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlFormaPag = (Classes.formasPagamento)dataGridToObj(umCtrlFormPag, out string vlMsg);
                if (vlFormaPag == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione uma e apenas uma forma de pagamento!");
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
                    umaFormaPag.ThisFormPag = vlFormaPag;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlFormPag);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFormPag.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlFormPag.Pesquisar("formaPagamento", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultasFormasPagamento_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlFormPag);
        }
    }
}
