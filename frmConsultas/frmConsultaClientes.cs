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
    public partial class frmConsultaClientes : Projeto_ICI.frmConsultas.frmConsultaPai
    {
        frmCadastros.frmCadastroClientes frmCadCliente;
        Controllers.ctrlClientes umCtrlCliente;
        List<Classes.condicoesPagamento> listaCondPag;
        List<Classes.cidades> listaCidades;
        Classes.clientes umCliente;
        public frmConsultaClientes()
        {
            InitializeComponent();
            frmCadCliente = new frmCadastros.frmCadastroClientes();
            umCtrlCliente = new ctrlClientes();
            umCliente = new Classes.clientes();
            carregarDados(umCtrlCliente);
        }
        public frmConsultaClientes(BancoDados.conexoes pUmaConexao)
        {
            InitializeComponent();
            umCtrlCliente = new ctrlClientes(pUmaConexao);
            umCliente = new Classes.clientes();
            carregarDados(umCtrlCliente);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadCliente = (frmCadastros.frmCadastroClientes)pFrmCad;
        }
        protected override void carregarDados(controllers pCTRL)
        {
            base.carregarDados(pCTRL);
            listaCondPag = umCtrlCliente.CTRLCondPag.PesquisarCollection();
            listaCidades = umCtrlCliente.CTRLCidade.PesquisarCollection();
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umCliente = (Classes.clientes)pOBJ;
        }
        private Classes.clientes dataGridToCliente()
        {
            if (dataGridView.SelectedRows.Count == 0 ||
                dataGridView.SelectedRows[0].Cells[0].Value == null)
            {
                return null;
            }
            else
            {
                var row = dataGridView.SelectedRows[0].Cells;
                var vlCliente = new Classes.clientes((int)row[0].Value, (int)row[14].Value,
                                                      (string)row[15].Value, (string)row[16].Value,
                                                      (string)row[1].Value, (string)row[7].Value,
                                                      (string)row[8].Value, (string)row[9].Value,
                                                      (string)row[6].Value, (string)row[10].Value,
                                                      (string)row[3].Value, (string)row[4].Value,
                                                      (string)row[11].Value, (string)row[12].Value,
                                                      (string)row[13].Value);
                vlCliente.UmaCondPag.Codigo = (int)row[2].Value;
                vlCliente.UmaCidade.Codigo = (int)row[5].Value;
                foreach (Classes.condicoesPagamento vlCondPag in listaCondPag)
                {
                    if (vlCondPag.Codigo == vlCliente.UmaCondPag.Codigo)
                    { vlCliente.UmaCondPag.ThisCondPag = vlCondPag; }
                }
                foreach (Classes.cidades vlCidade in listaCidades)
                {
                    if (vlCidade.Codigo == vlCliente.UmaCidade.Codigo)
                    { vlCliente.UmaCidade.ThisCidade = vlCidade; }
                }
                return vlCliente;
            }
        }
        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadCliente.ClearTxTBox();
            frmCadCliente.ShowDialog();
            carregarDados(umCtrlCliente);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlCliente = dataGridToCliente();
            if (vlCliente == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um cliente");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Alterar, null);
                frmCadCliente.ClearTxTBox();
                var btnName = frmCadCliente.Btn_Acao;
                frmCadCliente.Btn_Acao = "Alterar";
                frmCadCliente.CarregarTxtBox(vlCliente);
                frmCadCliente.ShowDialog();
                frmCadCliente.Btn_Acao = btnName;
                carregarDados(umCtrlCliente);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            var vlCliente = dataGridToCliente();
            if (vlCliente == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um cliente");
                this.dataGridView.Focus();
            }
            else
            {
                errorMSG.SetError(btn_Excluir, null);
                frmCadCliente.ClearTxTBox();
                var btnName = frmCadCliente.Btn_Acao;
                frmCadCliente.BloquearTxtBox();
                frmCadCliente.CarregarTxtBox(vlCliente);
                frmCadCliente.Btn_Acao = "Excluir";
                frmCadCliente.ShowDialog();
                frmCadCliente.Btn_Acao = btnName;
                carregarDados(umCtrlCliente);
            }
        }
        protected override void Sair()
        {
            if (btn_Sair.Text != "Sair")
            {
                var vlCliente = dataGridToCliente();
                if (vlCliente == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um cliente!");
                    this.dataGridView.Focus();
                }
                else
                {
                    errorMSG.SetError(btn_Sair, null);
                    umCliente.ThisCliente = vlCliente;
                }
            }
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar();
            }
            else if (ValidacaoCPF(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("cpf", FormatCPF(txtb_Pesquisa.Text));
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoCNPJ(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("cnpj", FormatCNPJ(txtb_Pesquisa.Text));
                txtb_Pesquisa.Clear();
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("codigo", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("cliente", txtb_Pesquisa.Text);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
        }

        private void frmConsultaClientes_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlCliente);
        }
    }
}
