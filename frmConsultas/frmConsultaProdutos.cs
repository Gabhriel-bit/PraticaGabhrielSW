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
    public partial class frmConsultaProdutos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroProdutos frmCadProduto;
        Controllers.ctrlProdutos umCtrlProduto;
        Classes.produtos umProduto;

        public frmConsultaProdutos(Controllers.ctrlProdutos pCtrlProduto)
        {
            InitializeComponent();
            umCtrlProduto = pCtrlProduto;
            umProduto = new Classes.produtos();

            carregarDados(umCtrlProduto);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadProduto = (frmCadastros.frmCadastroProdutos)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umProduto = (Classes.produtos)pOBJ;
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadProduto.ClearTxTBox();
            frmCadProduto.ShowDialog();
            carregarDados(umCtrlProduto);
        }
        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlProduto = (Classes.produtos)dataGridToObj(umCtrlProduto, out string vlMsg);
            if (vlProduto == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um produto");
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
                frmCadProduto.ClearTxTBox();
                var btnName = frmCadProduto.Btn_Acao;
                frmCadProduto.Btn_Acao = "Alterar";
                frmCadProduto.CarregarTxtBox(vlProduto);
                frmCadProduto.ShowDialog();
                frmCadProduto.Btn_Acao = btnName;
                carregarDados(umCtrlProduto);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlProduto = (Classes.produtos)dataGridToObj(umCtrlProduto, out string vlMsg);
            if (vlProduto == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um produto");
                this.dataGridView.Focus();
            }
            else if (vlMsg != "")
            {
                errorMSG.SetError(btn_Excluir, "Erro ao carregar!\n" + vlMsg);
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadProduto.ClearTxTBox();
                var btnName = frmCadProduto.Btn_Acao;
                frmCadProduto.BloquearTxtBox();
                frmCadProduto.CarregarTxtBox(vlProduto);
                frmCadProduto.Btn_Acao = "Excluir";
                frmCadProduto.ShowDialog();
                frmCadProduto.Btn_Acao = btnName;
                carregarDados(umCtrlProduto);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlProduto = (Classes.produtos)dataGridToObj(umCtrlProduto, out string vlMsg);
                if (vlMsg != "")
                {
                    errorMSG.SetError(btn_Alterar, "Erro ao carregar!\n" + vlMsg);
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umProduto.ThisProduto = vlProduto;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlProduto);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlProduto.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlProduto.Pesquisar("produto", txtb_Pesquisa.Text, false, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaProdutos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlProduto);
        }
    }
}
