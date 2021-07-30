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

        List<Classes.modelos> listaModelos;
        List<Classes.subgrupos> listaSubgrupos;
        public frmConsultaProdutos()
        {
            InitializeComponent();
            frmCadProduto = new frmCadastros.frmCadastroProdutos();
            umCtrlProduto = new Controllers.ctrlProdutos();
            umProduto = new Classes.produtos();

        }
        public frmConsultaProdutos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlProduto = new Controllers.ctrlProdutos(pUmaConexao);
            umProduto = new Classes.produtos();

            carregarDados(umCtrlProduto);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadProduto = (frmCadastros.frmCadastroProdutos)pFrmCad;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaSubgrupos = umCtrlProduto.CTRLSubgrupo.PesquisarCollection(out string vlMsgSubg);
            listaModelos = umCtrlProduto.CTRLModelo.PesquisarCollection(out string vlMsgMod);
            if (vlMsgMod != "" || vlMsgSubg != "")
            { 
                MessageBox.Show(vlMsgSubg != "" ? "Subgrupos: " + vlMsgSubg : "" +
                                vlMsgMod != "" ? "Modelos: " + vlMsgMod : "",
                                "ERRO --> " + this.Text.ToString());
            }
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
        private Classes.produtos dataGridToProduto()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlProduto = new
                    Classes.produtos((int)row[0].Value, (int)row[9].Value,
                                     (string)row[10].Value, (string)row[11].Value,
                                     (string)row[1].Value, (string)row[5].Value,
                                     (string)row[6].Value,
                                     decimal.Parse(row[2].Value.ToString(), vgEstilo, vgProv),
                                     (int)row[3].Value, (int)row[4].Value);

                vlProduto.ListaFornecedores = umCtrlProduto.PesquisarCollection(vlProduto.Codigo, out string vlMsg);
                if (vlMsg != "")
                { MessageBox.Show(vlMsg, "ERRO"); }
                vlProduto.UmModelo.Codigo = (int)row[7].Value;
                foreach (Classes.modelos vlModelo in listaModelos)
                {
                    if (vlModelo.Codigo == vlProduto.UmModelo.Codigo)
                    { vlProduto.UmModelo.ThisModelo = vlModelo; }
                }
                vlProduto.UmSubgrupo.Codigo = (int)row[8].Value;
                foreach (Classes.subgrupos vlSubgrupo in listaSubgrupos)
                {
                    if (vlSubgrupo.Codigo == vlProduto.UmSubgrupo.Codigo)
                    { vlProduto.UmSubgrupo.ThisSubgrupo = vlSubgrupo; }
                }
                return vlProduto;
            }
        }
        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlProduto = dataGridToProduto();
            if (vlProduto == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um produto");
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
            var vlProduto = dataGridToProduto();
            if (vlProduto == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um produto");
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
                var vlProduto = dataGridToProduto();
                if (vlProduto == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um produto!");
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
                dataGridView.DataSource = umCtrlProduto.Pesquisar("codigo", txtb_Pesquisa.Text, out vlMsg);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlProduto.Pesquisar("produto", txtb_Pesquisa.Text, out vlMsg);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            if (vlMsg != "")
            { MessageBox.Show(vlMsg, "ERRO"); }
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaProdutos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlProduto);
        }
    }
}
