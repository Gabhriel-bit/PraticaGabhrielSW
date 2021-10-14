using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaModelos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroModelos frmCadModelo;
        Controllers.ctrlModelos umCtrlModelos;
        Classes.modelos umModelo;

        public frmConsultaModelos(Controllers.ctrlModelos pCtrlModelo)
        {
            InitializeComponent();
            umCtrlModelos = pCtrlModelo;
            umModelo = new Classes.modelos();
            carregarDados(umCtrlModelos);
        }

        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadModelo = (frmCadastros.frmCadastroModelos)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umModelo = (Classes.modelos)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadModelo.ClearTxTBox();
            frmCadModelo.ShowDialog();
            carregarDados(umCtrlModelos);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlModelo = (Classes.modelos)dataGridToObj(umCtrlModelos, out string vlMsg);
            if (vlModelo == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um modelo");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadModelo.ClearTxTBox();
                var btnName = frmCadModelo.Btn_Acao;
                frmCadModelo.Btn_Acao = "Alterar";
                frmCadModelo.CarregarTxtBox(vlModelo);
                frmCadModelo.ShowDialog();
                frmCadModelo.Btn_Acao = btnName;
                carregarDados(umCtrlModelos);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlModelo = (Classes.modelos)dataGridToObj(umCtrlModelos, out string vlMsg);
            if (vlModelo == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um modelo");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadModelo.ClearTxTBox();
                var btnName = frmCadModelo.Btn_Acao;
                frmCadModelo.BloquearTxtBox();
                frmCadModelo.CarregarTxtBox(vlModelo);
                frmCadModelo.Btn_Acao = "Excluir";
                frmCadModelo.ShowDialog();
                frmCadModelo.Btn_Acao = btnName;
                carregarDados(umCtrlModelos);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlModelo = (Classes.modelos)dataGridToObj(umCtrlModelos, out string vlMsg);
                if (vlModelo == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um modelo!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umModelo.ThisModelo = vlModelo;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlModelos);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlModelos.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlModelos.Pesquisar("modelo", txtb_Pesquisa.Text, false, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaModelos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlModelos);
        }
    }
}
