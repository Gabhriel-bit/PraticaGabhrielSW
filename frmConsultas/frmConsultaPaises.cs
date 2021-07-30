using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaPaises : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroPaises frmCadPais;
        Controllers.ctrlPaises umCtrlPais;
        Classes.paises umPais;
        public frmConsultaPaises()
        {
            InitializeComponent();
            frmCadPais = new frmCadastros.frmCadastroPaises(new BancoDados.conexoes());
            umCtrlPais = new Controllers.ctrlPaises(new BancoDados.conexoes());
            umPais = new Classes.paises();
            carregarDados(umCtrlPais);
        }

        public frmConsultaPaises(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlPais = new Controllers.ctrlPaises(pUmaConexao);
            umPais = new Classes.paises();
            carregarDados(umCtrlPais);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadPais = (frmCadastros.frmCadastroPaises)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umPais = (Classes.paises)pOBJ;
        }
        private Classes.paises dataGridToPais()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlPais = new Classes.paises((int)row[0].Value, (int)row[5].Value,
                                                (string)row[6].Value, (string)row[7].Value,
                                                (string)row[1].Value, (string)row[3].Value,
                                                (string)row[2].Value, (string)row[4].Value);
                return vlPais;
            }

        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadPais.ClearTxTBox();
            frmCadPais.ShowDialog();
            carregarDados(umCtrlPais);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlPais = dataGridToPais();
            if (vlPais == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um país");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadPais.ClearTxTBox();
                var btnName = frmCadPais.Btn_Acao;
                frmCadPais.CarregarTxtBox(vlPais);
                frmCadPais.Btn_Acao = "Alterar";
                frmCadPais.ShowDialog();
                frmCadPais.Btn_Acao = btnName;
                carregarDados(umCtrlPais);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlPais = dataGridToPais();
            if (vlPais == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um país!");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadPais.ClearTxTBox();
                frmCadPais.BloquearTxtBox();
                var btnName = frmCadPais.Btn_Acao;
                frmCadPais.CarregarTxtBox(vlPais);
                frmCadPais.Btn_Acao = "Excluir";
                frmCadPais.ShowDialog();
                frmCadPais.Btn_Acao = btnName;
                carregarDados(umCtrlPais);
            }
        }

        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlPais = dataGridToPais();
                if (vlPais == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um país!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umPais.ThisPais = vlPais;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlPais);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlPais.Pesquisar("codigo", txtb_Pesquisa.Text, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlPais.Pesquisar("pais", txtb_Pesquisa.Text, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            if (vlMsg != "")
            { MessageBox.Show(vlMsg, "ERRO"); }
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaPaises_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlPais);
        }
    }
}
