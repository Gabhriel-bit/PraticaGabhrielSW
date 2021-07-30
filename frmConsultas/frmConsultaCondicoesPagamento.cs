using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI.frmConsultas
{
    public partial class frmConsultaCondicoesPagamento : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroCondicoesPagamento frmCadCondPag;
        Controllers.ctrlCondicoesPagamento umCtrlCondPag;
        Classes.condicoesPagamento umaCondPag;
        public frmConsultaCondicoesPagamento()
        {
            InitializeComponent();
            frmCadCondPag = new frmCadastros.frmCadastroCondicoesPagamento();
            umCtrlCondPag = new Controllers.ctrlCondicoesPagamento();
            umaCondPag = new Classes.condicoesPagamento();
            carregarDados(umCtrlCondPag);
        }
        public frmConsultaCondicoesPagamento(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlCondPag = new Controllers.ctrlCondicoesPagamento(pUmaConexao);
            umaCondPag = new Classes.condicoesPagamento();
            carregarDados(umCtrlCondPag);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadCondPag = (frmCadastros.frmCadastroCondicoesPagamento)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umaCondPag = (Classes.condicoesPagamento)pOBJ;
        }
        private Classes.condicoesPagamento dataGridToCondPag()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlCondPag = new
                    Classes.condicoesPagamento((int)row[0].Value, (int)row[6].Value,
                                               (string)row[7].Value, (string)row[8].Value,
                                               (string)row[1].Value, (int)row[2].Value,
                                               decimal.Parse(row[3].Value.ToString(), vgEstilo, vgProv),
                                               decimal.Parse(row[4].Value.ToString(), vgEstilo, vgProv),
                                               decimal.Parse(row[5].Value.ToString(), vgEstilo, vgProv));
                vlCondPag.ListaParcelas = umCtrlCondPag.PesquisarCollection(vlCondPag.Codigo, out string vlMsg);
                if (vlMsg != "")
                { MessageBox.Show(vlMsg, "ERRO"); }
                return vlCondPag;
            }
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadCondPag.ClearTxTBox();
            frmCadCondPag.ShowDialog();
            carregarDados(umCtrlCondPag);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlCondPag = dataGridToCondPag();
            if (vlCondPag == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione uma e apenas uma condição de pagamento");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadCondPag.ClearTxTBox();
                var btnName = frmCadCondPag.Btn_Acao;
                frmCadCondPag.Btn_Acao = "Alterar";
                frmCadCondPag.CarregarTxtBox(vlCondPag);
                frmCadCondPag.ShowDialog();
                frmCadCondPag.Btn_Acao = btnName;
                carregarDados(umCtrlCondPag);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlCondPag = dataGridToCondPag();
            if (vlCondPag == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione uma e apenas uma condição de pagamento");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadCondPag.ClearTxTBox();
                var btnName = frmCadCondPag.Btn_Acao;
                frmCadCondPag.BloquearTxtBox();
                frmCadCondPag.CarregarTxtBox(vlCondPag);
                frmCadCondPag.Btn_Acao = "Excluir";
                frmCadCondPag.ShowDialog();
                frmCadCondPag.Btn_Acao = btnName;
                carregarDados(umCtrlCondPag);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlCondPag = dataGridToCondPag();
                if (vlCondPag == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione uma e apenas uma condição de pagamento!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umaCondPag.ThisCondPag = vlCondPag;
                }
            }
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlCondPag);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCondPag.Pesquisar("codigo", txtb_Pesquisa.Text, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCondPag.Pesquisar("condicaoPagamento", txtb_Pesquisa.Text, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            if (vlMsg != "")
            { MessageBox.Show(vlMsg, "ERRO"); }
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaCondicoesPagamento_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlCondPag);
        }
    }
}
