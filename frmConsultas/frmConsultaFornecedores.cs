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
    public partial class frmConsultaFornecedores : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroFornecedores frmCadForn;
        Controllers.ctrlFornecedores umCtrlForn;
        List<Classes.condicoesPagamento> listaCondPag;
        List<Classes.cidades> listaCidades;
        Classes.fornecedores umForn;
        public frmConsultaFornecedores()
        {
            InitializeComponent();
            frmCadForn = new frmCadastros.frmCadastroFornecedores();
            umCtrlForn = new ctrlFornecedores();
            umForn = new Classes.fornecedores();
            carregarDados(umCtrlForn);
        }
        public frmConsultaFornecedores(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlForn = new ctrlFornecedores(pUmaConexao);
            umForn = new Classes.fornecedores();
            carregarDados(umCtrlForn);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadForn = (frmCadastros.frmCadastroFornecedores)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umForn = (Classes.fornecedores)pOBJ;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaCondPag = umCtrlForn.CTRLCondPag.PesquisarCollection();
            listaCidades = umCtrlForn.CTRLCidade.PesquisarCollection();
        }
        private Classes.fornecedores dataGridToForn()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlForn = new Classes.fornecedores((int)row[0].Value, (int)row[14].Value,
                                                        (string)row[15].Value, (string)row[16].Value,
                                                        (string)row[1].Value, (string)row[7].Value,
                                                        (string)row[8].Value, (string)row[9].Value,
                                                        (string)row[6].Value, (string)row[10].Value,
                                                        (string)row[3].Value, (string)row[4].Value,
                                                        (string)row[11].Value, (string)row[12].Value,
                                                        (string)row[13].Value);
                vlForn.UmaCondPag.Codigo = (int)row[2].Value;
                vlForn.UmaCidade.Codigo = (int)row[5].Value;
                foreach (Classes.condicoesPagamento vlCondPag in listaCondPag)
                {
                    if (vlCondPag.Codigo == vlForn.UmaCondPag.Codigo)
                    { vlForn.UmaCondPag.ThisCondPag = vlCondPag; }
                }
                foreach (Classes.cidades vlCidade in listaCidades)
                {
                    if (vlCidade.Codigo == vlForn.UmaCidade.Codigo)
                    { vlForn.UmaCidade.ThisCidade = vlCidade; }
                }
                return vlForn;
            }
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadForn.ClearTxTBox();
            frmCadForn.ShowDialog();
            carregarDados(umCtrlForn);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlForn = dataGridToForn();
            if (vlForn == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um fornecedor");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadForn.ClearTxTBox();
                var btnName = frmCadForn.Btn_Acao;
                frmCadForn.Btn_Acao = "Alterar";
                frmCadForn.CarregarTxtBox(vlForn);
                frmCadForn.ShowDialog();
                frmCadForn.Btn_Acao = btnName;
                carregarDados(umCtrlForn);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlForn = dataGridToForn();
            if (vlForn == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um fornecedor");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadForn.ClearTxTBox();
                var btnName = frmCadForn.Btn_Acao;
                frmCadForn.BloquearTxtBox();
                frmCadForn.CarregarTxtBox(vlForn);
                frmCadForn.Btn_Acao = "Excluir";
                frmCadForn.ShowDialog();
                frmCadForn.DesBloqTxTBox();
                frmCadForn.Btn_Acao = btnName;
                carregarDados(umCtrlForn);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlForn = dataGridToForn();
                if (vlForn == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um cliente!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umForn.ThisFornecedor = vlForn;
                }
            }
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar();
            }
            else if (ValidacaoCPF(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("cpf", FormatCPF(txtb_Pesquisa.Text));
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoCNPJ(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("cnpj", FormatCNPJ(txtb_Pesquisa.Text));
                txtb_Pesquisa.Clear();
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("codigo", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlForn.Pesquisar("fornecedor", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
        }

        private void frmConsultaFornecedores_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlForn);
        }
    }
}
