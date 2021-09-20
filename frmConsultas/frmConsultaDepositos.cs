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
    public partial class frmConsultaDepositos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroDepositos frmCadDeposito;
        Controllers.ctrlDepositos umCtrlDeposito;
        Classes.depositos umDeposito;

        List<Classes.cidades> listaCidades;

        public frmConsultaDepositos(Controllers.ctrlDepositos pCtrlDeposito)
        {
            InitializeComponent();
            umCtrlDeposito = pCtrlDeposito;
            umDeposito = new Classes.depositos();
            carregarDados(umCtrlDeposito);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadDeposito = (frmCadastros.frmCadastroDepositos)pFrmCad;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaCidades = umCtrlDeposito.CTRLCidade.PesquisarCollection(out string vlMsg);
            showErrorMsg(vlMsg);
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadDeposito.ClearTxTBox();
            frmCadDeposito.ShowDialog();
            carregarDados(umCtrlDeposito);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlDeposito = (Classes.depositos)dataGridToObj(umCtrlDeposito, out string vlMsg);
            if (vlDeposito == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um deposito");
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
                frmCadDeposito.ClearTxTBox();
                var btnName = frmCadDeposito.Btn_Acao;
                frmCadDeposito.Btn_Acao = "Alterar";
                frmCadDeposito.CarregarTxtBox(vlDeposito);
                frmCadDeposito.ShowDialog();
                frmCadDeposito.Btn_Acao = btnName;
                carregarDados(umCtrlDeposito);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlDeposito = (Classes.depositos)dataGridToObj(umCtrlDeposito, out string vlMsg);
            if (vlDeposito == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um deposito");
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
                frmCadDeposito.ClearTxTBox();
                var btnName = frmCadDeposito.Btn_Acao;
                frmCadDeposito.BloquearTxtBox();
                frmCadDeposito.CarregarTxtBox(vlDeposito);
                frmCadDeposito.Btn_Acao = "Excluir";
                frmCadDeposito.ShowDialog();
                frmCadDeposito.Btn_Acao = btnName;
                carregarDados(umCtrlDeposito);
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlDeposito);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlDeposito.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlDeposito.Pesquisar("deposito", txtb_Pesquisa.Text, false, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlDeposito = (Classes.depositos)dataGridToObj(umCtrlDeposito, out string vlMsg);
                if (vlDeposito == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um deposito!");
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
                    umDeposito.ThisDeposito = vlDeposito;
                }
            }
        }

        private void frmConsultaDepositos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlDeposito);
        }
    }
}
