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
    public partial class frmConsultaEstados : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroEstados frmCadEstado;
        Controllers.ctrlEstados umCtrlEstado;
        List<Classes.paises> listaPaises;
        Classes.estados umEstado;
        public frmConsultaEstados()
        {
            InitializeComponent();
            frmCadEstado = new frmCadastros.frmCadastroEstados();
            umCtrlEstado = new Controllers.ctrlEstados();
            umEstado = new Classes.estados();
            carregarDados(umCtrlEstado);
        }

        public frmConsultaEstados(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlEstado = new Controllers.ctrlEstados(pUmaConexao);
            umEstado = new Classes.estados();
            carregarDados(umCtrlEstado);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadEstado = (frmCadastros.frmCadastroEstados)pFrmCad;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaPaises = umCtrlEstado.CTRLPais.PesquisarCollection(out string vlMsg);
            if (vlMsg != "")
            { MessageBox.Show(vlMsg, "ERRO --> " + this.Text.ToString()); }
        }

        public override void ConhecaOBJ(object pOBJ)
        {
            umEstado = (Classes.estados)pOBJ;
        }

        private Classes.estados dataGridToEstado()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlEstado = new Classes.estados((int)row[0].Value, (int)row[4].Value,
                                                   (string)row[5].Value, (string)row[6].Value,
                                                   (string)row[1].Value, (string)row[2].Value);
                vlEstado.UmPais.Pais = (string)row[3].Value;
                foreach (Classes.paises vlPais in listaPaises)
                {
                    if (vlPais.Pais == vlEstado.UmPais.Pais)
                    { vlEstado.UmPais.ThisPais = vlPais; }
                }
                return vlEstado;
            }
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadEstado.ClearTxTBox();
            frmCadEstado.ShowDialog();
            carregarDados(umCtrlEstado);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlEstado = dataGridToEstado();
            if (vlEstado == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um estado");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadEstado.ClearTxTBox();
                var btnName = frmCadEstado.Btn_Acao;
                frmCadEstado.Btn_Acao = "Alterar";
                frmCadEstado.CarregarTxtBox(vlEstado);
                frmCadEstado.ShowDialog();
                frmCadEstado.Btn_Acao = btnName;
                carregarDados(umCtrlEstado);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlEstado = dataGridToEstado();
            if (vlEstado == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um estado");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadEstado.ClearTxTBox();
                var btnName = frmCadEstado.Btn_Acao;
                frmCadEstado.BloquearTxtBox();
                frmCadEstado.CarregarTxtBox(vlEstado);
                frmCadEstado.Btn_Acao = "Excluir";
                frmCadEstado.ShowDialog();
                frmCadEstado.Btn_Acao = btnName;
                carregarDados(umCtrlEstado);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlEstado = dataGridToEstado();
                if (vlEstado == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um estado!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umEstado.ThisEstado = vlEstado;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlEstado);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlEstado.Pesquisar("codigo", txtb_Pesquisa.Text, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlEstado.Pesquisar("estado", txtb_Pesquisa.Text, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            if (vlMsg != "")
            { MessageBox.Show(vlMsg, "ERRO"); }
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaEstados_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlEstado);
        }
    }
}
