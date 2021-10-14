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
        Classes.clientes umCliente;

        public frmConsultaClientes(Controllers.ctrlClientes pCtrlCliente)
        {
            InitializeComponent();
            umCtrlCliente = pCtrlCliente;
            umCliente = new Classes.clientes();
            carregarDados(umCtrlCliente);
        }
        public override void SetFrmCad(Form pFrmCad)
        {
            frmCadCliente = (frmCadastros.frmCadastroClientes)pFrmCad;
        }
        public override void ConhecaOBJ(object pOBJ)
        {
            umCliente = (Classes.clientes)pOBJ;
        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            frmCadCliente.ClearTxTBox();
            frmCadCliente.ShowDialog();
            carregarDados(umCtrlCliente);
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var vlCliente = (Classes.clientes)dataGridToObj(umCtrlCliente, out string vlMsg);
            if (vlCliente == null)
            {
                errorMSG.SetError(btn_Alterar, "Selecão inválida!\nSelecione um e apenas um cliente");
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
            var vlCliente = (Classes.clientes)dataGridToObj(umCtrlCliente, out string vlMsg);
            if (vlCliente == null)
            {
                errorMSG.SetError(btn_Excluir, "Selecão inválida!\nSelecione um e apenas um cliente");
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
                var vlCliente = (Classes.clientes)dataGridToObj(umCtrlCliente, out string vlMsg);
                if (vlCliente == null)
                {
                    errorMSG.SetError(btn_Sair, "Selecione um e apenas um cliente!");
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
                    umCliente.ThisCliente = vlCliente;
                }
            }
        }
        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            string vlMsg = "";
            if (txtb_Pesquisa.Text == "")
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("", "", default, out vlMsg);
            }
            else if (ValidacaoCPF(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("cpf", FormatCPF(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoCNPJ(txtb_Pesquisa.Text))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("cnpj", FormatCNPJ(txtb_Pesquisa.Text), default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (int.TryParse(txtb_Pesquisa.Text, out _))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("codigo", txtb_Pesquisa.Text, default, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else if (ValidacaoNome(txtb_Pesquisa.Text, 1, true))
            {
                errorMSG.SetError(lbl_Pesquisa, null);
                dataGridView.DataSource = umCtrlCliente.Pesquisar("cliente", txtb_Pesquisa.Text, false, out vlMsg);
                txtb_Pesquisa.Clear();
            }
            else
            {
                errorMSG.SetError(lbl_Pesquisa, "Valor de pesquisa inválido!");
            }
            showErrorMsg(vlMsg);
            txtb_Pesquisa.Clear();
        }

        private void frmConsultaClientes_Load(object sender, EventArgs e)
        {
            carregarDados(umCtrlCliente);
        }
    }
}
