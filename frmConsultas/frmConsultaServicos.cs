using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaServicos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroServicos frmCadServico;
        Controllers.ctrlServicos umCtrlServico;
        Classes.servicos umServico;

        public frmConsultaServicos(Controllers.ctrlServicos pCtrlServico)
        {
            InitializeComponent();
            umCtrlServico = pCtrlServico;
            umServico = new Classes.servicos();
            carregarDados(umCtrlServico);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadServico = (frmCadastros.frmCadastroServicos)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umServico = (Classes.servicos)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadServico.ClearTxTBox();
            frmCadServico.ShowDialog();
            carregarDados(umCtrlServico);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlServico = (Classes.servicos)dataGridToObj(umCtrlServico, out string vlMsg);
            if (vlServico == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um serviço");
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
                frmCadServico.ClearTxTBox();
                var btnName = frmCadServico.Btn_Acao;
                frmCadServico.CarregarTxtBox(vlServico);
                frmCadServico.Btn_Acao = "Alterar";
                frmCadServico.ShowDialog();
                frmCadServico.Btn_Acao = btnName;
                carregarDados(umCtrlServico);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlServico = (Classes.servicos)dataGridToObj(umCtrlServico, out string vlMsg);
            if (vlServico == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um serviço!");
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
                frmCadServico.ClearTxTBox();
                frmCadServico.BloquearTxtBox();
                var btnName = frmCadServico.Btn_Acao;
                frmCadServico.CarregarTxtBox(vlServico);
                frmCadServico.Btn_Acao = "Excluir";
                frmCadServico.ShowDialog();
                frmCadServico.Btn_Acao = btnName;
                carregarDados(umCtrlServico);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlServico = (Classes.servicos)dataGridToObj(umCtrlServico, out string vlMsg);
                if (vlServico == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um serviço!");
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
                    umServico.ThisServico = vlServico;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlServico);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlServico.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlServico.Pesquisar("servico", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaServicos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlServico);
        }
    }
}
