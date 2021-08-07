using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaCargos : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroCargos frmCadCargo;
        Controllers.ctrlCargos umCtrlCargos;
        Classes.cargos umCargo;
        public frmConsultaCargos()
        {
            InitializeComponent();
            frmCadCargo = new frmCadastros.frmCadastroCargos();
            umCtrlCargos = new Controllers.ctrlCargos();
            umCargo = new Classes.cargos();
            carregarDados(umCtrlCargos);
        }
        public frmConsultaCargos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlCargos = new Controllers.ctrlCargos(pUmaConexao);
            umCargo = new Classes.cargos();
            carregarDados(umCtrlCargos);
        }

        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadCargo = (frmCadastros.frmCadastroCargos)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umCargo = (Classes.cargos)pOBJ;
        }
        private Classes.cargos dataGridToCargo()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlCargo = new Classes.cargos((int)row[0].Value, (int)row[4].Value,
                                                 (string)row[5].Value, (string)row[6].Value,
                                                 bool.Parse((string)row[3].Value),
                                                 (string)row[1].Value, (string)row[2].Value);
                return vlCargo;
            }
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadCargo.ClearTxTBox();
            frmCadCargo.ShowDialog();
            carregarDados(umCtrlCargos);
        }
        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlCargo = dataGridToCargo();
            if (vlCargo == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um cargo");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadCargo.ClearTxTBox();
                var btnName = frmCadCargo.Btn_Acao;
                frmCadCargo.CarregarTxtBox(vlCargo);
                frmCadCargo.Btn_Acao = "Alterar";
                frmCadCargo.ShowDialog();
                frmCadCargo.Btn_Acao = btnName;
                carregarDados(umCtrlCargos);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlCargo = dataGridToCargo();
            if (vlCargo == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um cargo!");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadCargo.ClearTxTBox();
                frmCadCargo.BloquearTxtBox();
                var btnName = frmCadCargo.Btn_Acao;
                frmCadCargo.CarregarTxtBox(vlCargo);
                frmCadCargo.Btn_Acao = "Excluir";
                frmCadCargo.ShowDialog();
                frmCadCargo.Btn_Acao = btnName;
                carregarDados(umCtrlCargos);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlCargo = dataGridToCargo();
                if (vlCargo == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um cargo!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umCargo.ThisCargo = vlCargo;
                }
            }
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlCargos);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCargos.Pesquisar("codigo", txtb_Pesquisa.Text, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCargos.Pesquisar("cargo", txtb_Pesquisa.Text, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaCargos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlCargos);
        }
    }
}
