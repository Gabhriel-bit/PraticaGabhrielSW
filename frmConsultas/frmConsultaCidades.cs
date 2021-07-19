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
    public partial class frmConsultaCidades : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroCidades frmCadCidade;
        Controllers.ctrlCidades umCtrlCidade;
        List<Classes.estados> listaEstados;
        Classes.cidades umaCidade;
        public frmConsultaCidades()
        {
            InitializeComponent();
            frmCadCidade = new frmCadastros.frmCadastroCidades(new BancoDados.conexoes());
            umCtrlCidade = new Controllers.ctrlCidades(new BancoDados.conexoes());
            umaCidade = new Classes.cidades();
            carregarDados(umCtrlCidade);
        }

        public frmConsultaCidades(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlCidade = new ctrlCidades(pUmaConexao);
            umaCidade = new Classes.cidades();
            carregarDados(umCtrlCidade);
        }

        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadCidade = (frmCadastros.frmCadastroCidades)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umaCidade = (Classes.cidades)pOBJ;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaEstados = umCtrlCidade.CTRLEstado.PesquisarCollection();
        }

        private Classes.cidades dataGridToCidade()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlCidade = new Classes.cidades((int)row[0].Value, (int)row[4].Value,
                                                   (string)row[5].Value, (string)row[6].Value,
                                                   (string)row[1].Value, (string)row[2].Value);
                vlCidade.UmEstado.Estado = (string)row[3].Value;
                foreach (Classes.estados vlEstado in listaEstados)
                {
                    if (vlEstado.Estado == vlCidade.UmEstado.Estado)
                    { vlCidade.UmEstado.ThisEstado = vlEstado; }
                }
                return vlCidade;
            }
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadCidade.ClearTxTBox();
            frmCadCidade.ShowDialog();
            carregarDados(umCtrlCidade);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlCidade = dataGridToCidade();
            if (vlCidade == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione uma e apenas uma cidade");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadCidade.ClearTxTBox();
                var btnName = frmCadCidade.Btn_Acao;
                frmCadCidade.Btn_Acao = "Alterar";
                frmCadCidade.CarregarTxtBox(vlCidade);
                frmCadCidade.ShowDialog();
                frmCadCidade.Btn_Acao = btnName;
                carregarDados(umCtrlCidade);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlCidade = dataGridToCidade();
            if (vlCidade == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione uma e apenas uma cidade");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadCidade.ClearTxTBox();
                var btnName = frmCadCidade.Btn_Acao;
                frmCadCidade.BloquearTxtBox();
                frmCadCidade.CarregarTxtBox(vlCidade);
                frmCadCidade.Btn_Acao = "Excluir";
                frmCadCidade.ShowDialog();
                frmCadCidade.Btn_Acao = btnName;
                carregarDados(umCtrlCidade);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlCidade = dataGridToCidade();
                if (vlCidade == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione uma e apenas uma cidade!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umaCidade.ThisCidade = vlCidade;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlCidade);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCidade.Pesquisar("codigo", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCidade.Pesquisar("cidade", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
        }

        private void frmConsultaCidades_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlCidade);
        }
    }
}
