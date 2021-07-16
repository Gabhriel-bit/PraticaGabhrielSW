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
        public frmConsultaDepositos()
        {
            InitializeComponent();
            frmCadDeposito = new frmCadastros.frmCadastroDepositos();
            umCtrlDeposito = new ctrlDepositos();
            umDeposito = new Classes.depositos();
            listaCidades = new List<Classes.cidades>();
        }
        public frmConsultaDepositos(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlDeposito = new ctrlDepositos(pUmaConexao);
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
            listaCidades = umCtrlDeposito.CTRLCidade.PesquisarCollection();
        }

        private Classes.depositos dataGridToDeposito()
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
                    Classes.depositos((int)row[0].Value, (int)row[8].Value,
                                     (string)row[9].Value, (string)row[10].Value,
                                     (string)row[1].Value, (string)row[2].Value,
                                     (string)row[3].Value, (string)row[4].Value,
                                     (string)row[5].Value, (string)row[6].Value);
                vlProduto.UmaCidade.Codigo = (int)row[7].Value;
                foreach (Classes.cidades vlCidade in listaCidades)
                {
                    if (vlCidade.Codigo == vlProduto.UmaCidade.Codigo)
                    { vlProduto.UmaCidade.ThisCidade = vlCidade; }
                }
                vlProduto.ListaProd = umCtrlDeposito.PesquisarCollection(vlProduto.Codigo);
                return vlProduto;
            }
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadDeposito.ClearTxTBox();
            frmCadDeposito.ShowDialog();
            carregarDados(umCtrlDeposito);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlDeposito = dataGridToDeposito();
            if (vlDeposito == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um deposito");
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
            var vlDeposito = dataGridToDeposito();
            if (vlDeposito == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um deposito");
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
                frmCadDeposito.DesBloqTxTBox();
                frmCadDeposito.Btn_Acao = btnName;
                carregarDados(umCtrlDeposito);
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                carregarDados(umCtrlDeposito);
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlDeposito.Pesquisar("codigo", txtb_Pesquisa.Text);
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlDeposito.Pesquisar("deposito", txtb_Pesquisa.Text);
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            txtb_Pesquisa.Clear();
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlProduto = dataGridToDeposito();
                if (vlProduto == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um deposito!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umDeposito.ThisDeposito = vlProduto;
                }
            }
        }

        private void frmConsultaDepositos_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlDeposito);
        }
    }
}
